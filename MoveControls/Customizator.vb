Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms



Namespace WindowsApplication1
    Public Class Customizator
        Inherits Component


#Region "Fields"

        Private designerHost As IDesignerHost
        Private rootDesignControl As Control
        Private surface As DesignSurface
        Private parentControl As Control
        Private designPanel As Control


#End Region

#Region "Propeties"
        Private _SelectedControl As Control
        Public Property SelectedControl() As Control
            Get
                Return _SelectedControl
            End Get
            Set(ByVal value As Control)
                IsCustomization = False
                _SelectedControl = value
                OnChanged()
            End Set
        End Property

        Private _DesignContainer As Control
        Public Property DesignContainer() As Control
            Get
                Return _DesignContainer
            End Get
            Set(ByVal value As Control)
                _DesignContainer = value
                OnChanged()
            End Set
        End Property

        Private _IsCustomization As Boolean
        Public Property IsCustomization() As Boolean
            Get
                Return _IsCustomization
            End Get
            Set(ByVal value As Boolean)
                If value AndAlso (Not CanCustomize(value)) Then
                    Return
                End If
                _IsCustomization = value
                OnChanged()
            End Set
        End Property


#End Region

#Region "Methods"

        Private Sub CopyBounds(ByVal target As Control, ByVal source As Control)
            Dim p As Point = source.PointToScreen(New Point(0, 0))
            If target.Parent IsNot Nothing Then
                p = target.Parent.PointToClient(p)
            End If
            target.Location = p
            target.Width = source.Width
            target.Height = source.Height
        End Sub

        Private Shared Function IsNull(ByVal obj As Object) As Boolean
            Return obj Is Nothing
        End Function



        Private Sub AddToList(ByVal list As IList, ByVal c As Control)
            If c.Dock <> DockStyle.None Then
                Return
            End If
            If c.Parent Is Nothing Then
                Return
            End If
            If c.Name = String.Empty Then
                Return
            End If
            list.Add(c)
        End Sub



        Private Sub TraverseControls(ByVal list As IList, ByVal c As Control)
            AddToList(list, c)
            For Each control As Control In c.Controls
                TraverseControls(list, control)
            Next control
        End Sub



        Public Function GetAvailableControls() As List(Of Control)
            Dim list As New List(Of Control)()
            TraverseControls(list, DesignContainer)
            Return list
        End Function


        Private Function NeedDestroyCustomization() As Boolean
            Return (Not IsNull(rootDesignControl)) AndAlso Not IsNull(designPanel.Parent)
        End Function



        Private Function CanCustomize(ByVal isCutomization As Boolean) As Boolean
            Return Not (IsNull(DesignContainer) OrElse DesignMode OrElse IsNull(SelectedControl) OrElse ((Not isCutomization)) OrElse IsNull(SelectedControl.Parent))
        End Function


        Private paMainDesigner As System.ComponentModel.Design.IDesigner
        Private Function CreateDesignPanel() As Control
            Dim designPanel As Control = TryCast(designerHost.CreateComponent(GetType(Control)), Control)
            paMainDesigner = designerHost.GetDesigner(designPanel)
            designPanel.Padding = New Padding(20)
            Return designPanel
        End Function




        Private Sub CreateDesignSurface()

            surface = New DesignSurface()
            designerHost = TryCast(surface.GetService(GetType(IDesignerHost)), IDesignerHost)
            rootDesignControl = TryCast(designerHost.CreateComponent(GetType(UserControl)), Control)
            rootDesignControl.Dock = DockStyle.Fill
            rootDesignControl.BackColor = Color.AliceBlue


            Dim c As Control = TryCast(surface.View, Control)
            c.Dock = DockStyle.Fill
            c.BackColor = Color.White
            c.Location = New Point(15, 25)
            c.Parent = Me.DesignContainer


        End Sub


        Public Class DisablePanel
            Inherits Panel

            Public Sub New()
                Me.Dock = DockStyle.Fill
                Me.Padding = New Padding(0)
                Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            End Sub


            Private Class ChildWindowTarget
                Implements IWindowTarget

                Public Property OldWindowTarget As IWindowTarget
                Public Property Control As Control



                Public Sub New(ByVal ctrl As Control)
                    Me.OldWindowTarget = ctrl.WindowTarget
                    Me.Control = ctrl
                End Sub


                Public Sub OnHandleChange(ByVal newHandle As IntPtr) Implements IWindowTarget.OnHandleChange
                    OldWindowTarget.OnHandleChange(newHandle)
                End Sub



                Public Const WM_NCHITTEST As Int32 = &H84
                Public Const WM_SETCURSOR As Int32 = &H20

                Private Function IsMouseMessage(ByVal msg As Integer) As Boolean
                    If ((msg >= &H200) AndAlso (msg <= &H20A)) Then
                        Return True
                    End If
                    Select Case msg
                        Case 160, &HA1, &HA2, &HA3, &HA4, &HA5, &HA6, &HA7, &HA8, &HA9, &HAB, &HAC, &HAD, &H2A0, &H2A1, &H2A2, &H2A3, WM_NCHITTEST, WM_SETCURSOR
                            Return True
                    End Select
                    Return False
                End Function


                Public Sub OnMessage(ByRef m As Message) Implements IWindowTarget.OnMessage
                    If Not IsMouseMessage(m.Msg) Then
                        Me.OldWindowTarget.OnMessage(m)
                    Else
                        If Me.Control.Parent IsNot Nothing AndAlso Me.Control.Parent.Parent IsNot Nothing Then
                            Me.Control.Parent.Parent.WindowTarget.OnMessage(m)
                        End If
                    End If
                End Sub


                Public Sub Restore()
                    Me.Control.WindowTarget = OldWindowTarget
                End Sub
            End Class



            Protected Overrides Sub OnControlRemoved(ByVal e As ControlEventArgs)
                MyBase.OnControlRemoved(e)
                Me.Restore(e.Control)
            End Sub


            Public Sub Restore(ByVal ctrl As Control)
                If TypeOf ctrl.WindowTarget Is ChildWindowTarget Then
                    DirectCast(ctrl.WindowTarget, ChildWindowTarget).Restore()
                End If
                For Each subItem As Control In ctrl.Controls
                    Me.Restore(subItem)
                Next
            End Sub



            Protected Overrides Sub OnControlAdded(ByVal e As ControlEventArgs)
                'MyBase.OnControlAdded(e)
                Me.Disable(e.Control)
            End Sub



            Public Sub Disable(ByVal ctrl As Control)
                Dim newItem As New ChildWindowTarget(ctrl)
                ctrl.WindowTarget = newItem
                For Each subControl As Control In ctrl.Controls
                    Me.Disable(subControl)
                Next
            End Sub



            Protected Overrides Sub Dispose(ByVal disposing As Boolean)
                MyBase.Dispose(disposing)
            End Sub
        End Class




        Private Sub StartControlCustomization()
            designPanel = CreateDesignPanel()

            rootDesignControl.Controls.Add(designPanel)

            CopyBounds(designPanel, SelectedControl)

            parentControl = SelectedControl.Parent

            designPanel.Parent = Nothing
            rootDesignControl.Controls.Add(designPanel)

            Dim panel As New DisablePanel()
            panel.Parent = designPanel

            SelectedControl.Parent = panel
            SelectedControl.Dock = DockStyle.Fill


        End Sub



        Private Sub StartCustomiztion()
            If (Not CanCustomize(IsCustomization)) Then
                Return
            End If
            CreateDesignSurface()
            StartControlCustomization()
        End Sub


        Private Sub FinishControlCustomization()

            SelectedControl.Parent = parentControl
            SelectedControl.Dock = DockStyle.None
            SelectedControl.Enabled = True
            CopyBounds(SelectedControl, designPanel)

        End Sub



        Private Sub EndCustomization()
            If (Not NeedDestroyCustomization()) Then
                Return
            End If
            FinishControlCustomization()
            DestroyDesignSurface()
        End Sub


        Private Sub DestroyDesignSurface()
            For Each lControl As Control In rootDesignControl.Controls
                lControl.Dispose()
            Next

            rootDesignControl.Dispose()
            surface.Dispose()
        End Sub



        Private Sub OnChanged()
            If IsCustomization Then
                StartCustomiztion()
            Else
                EndCustomization()
            End If
        End Sub
#End Region
    End Class
End Namespace
