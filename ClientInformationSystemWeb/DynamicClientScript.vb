Public Class DynamicClientScript

    Public Overloads Sub OpenWindow(ByRef ctrl As Control, ByVal pageName As String, ByVal winName As String, _
            ByVal winTop As Integer, ByVal winLeft As Integer, ByVal winWidth As Integer, _
            ByVal winHeight As Integer, ByVal isResizable As Boolean, ByVal hasScrollbars As Boolean, _
            ByVal hasToolbar As Boolean, ByVal hasLocation As Boolean, ByVal hasStatus As Boolean, _
            ByVal hasMenuBar As Boolean)

        Dim script As New StringBuilder
        Dim top As String
        Dim left As String
        Dim width As String
        Dim height As String
        Dim resizable As String
        Dim scrollbars As String
        Dim menubar As String
        Dim toolbar As String
        Dim location As String
        Dim status As String

        top = "top=" & winTop.ToString
        left = "left=" & winLeft.ToString
        width = "width=" & winWidth.ToString
        height = "height=" & winHeight.ToString

        If isResizable Then
            resizable = "resizable=yes"
        Else
            resizable = "resizable=no"
        End If

        If hasScrollbars Then
            scrollbars = "scrollbars=yes"
        Else
            scrollbars = "scrollbars=no"
        End If

        If hasToolbar Then
            toolbar = "toolbar=yes"
        Else
            toolbar = "toolbar=no"
        End If

        If hasMenuBar Then
            menubar = "menubar=yes"
        Else
            menubar = "menubar=no"
        End If

        If hasLocation Then
            location = "location=yes"
        Else
            location = "location=no"
        End If

        If hasStatus Then
            status = "status=yes"
        Else
            status = "status=no"
        End If

        script.Append(vbNewLine)
        script.Append("<script language='javascript'>" & vbNewLine)
        script.Append("<!--" & vbNewLine)
        script.Append(" if(document.getElementById('" & ctrl.ClientID & "')!=null){" & vbNewLine)
        script.Append(" document.getElementById('" & ctrl.ClientID & "').onclick = " & ctrl.ClientID & "_OnClick;}" & vbNewLine)
        script.Append(" function " & ctrl.ClientID & "_OnClick(){" & vbNewLine)
        script.Append("     var returnValue;" & vbNewLine)
        script.Append("     returnValue = window.open('" & pageName & "','" & winName & "','" & top & "," & left & "," & _
                                            width & "," & height & "," & resizable & "," & scrollbars & "," & toolbar & "," & _
                                            menubar & "," & location & "," & status & "');" & vbNewLine)
        script.Append("     event.returnValue = false;" & vbNewLine)
        script.Append("     event.cancel = true;" & vbNewLine)
        script.Append(" }" & vbNewLine)
        script.Append("//-->" & vbNewLine)
        script.Append("</script>" & vbNewLine)

        If Not ctrl.Page.ClientScript.IsStartupScriptRegistered(ctrl.ClientID & "OpenWindow") Then
            ctrl.Page.ClientScript.RegisterStartupScript(ctrl.GetType, ctrl.ClientID & "OpenWindow", script.ToString)
        End If

    End Sub

    Public Sub ConfirmSave(ByRef ctrl As Control, ByVal message As String, _
         ByVal returnValueTextboxId As String, _
         Optional ByVal changeTextboxId As String = "", _
         Optional ByVal SRPChangeTextboxId As String = "", _
         Optional ByVal changeTrueValue As String = "changed", _
         Optional ByVal listItemStr As String = "")

        Dim script As New StringBuilder

        If Not ctrl.Page.ClientScript.IsClientScriptBlockRegistered("ClientScriptBin") Then
            ctrl.Page.ClientScript.RegisterClientScriptBlock(ctrl.GetType, "ClientScriptBin", "<script language='javascript' src='js/ClientGenericScripts.js'></script>")
        End If
        If Not ctrl.Page.ClientScript.IsClientScriptBlockRegistered("ClientScriptBinVarsConfirmSave") Then
            ctrl.Page.ClientScript.RegisterClientScriptBlock(ctrl.GetType, "ClientScriptBinVarsConfirmSave", "<script language='javascript'>var confirmSaveMessage = '" & message & "';</script>")
        End If

        script.Append("<script language='javascript' ")

        ''  Create the event
        If listItemStr = "" Then
            script.Append("for='")
            script.Append(ctrl.ClientID)
            script.Append("' event='onclick'>return(ConfirmSaveClient(")
        Else
            script.Append("for='")
            script.Append(ctrl.ClientID)
            script.Append("' event='onchange'>return(ConfirmSaveClient(")
        End If
        ''  Parameters: eventControl,messageText,returnValueTextbox,changeTextbox,srpChangeTextbox,changeTrueValue,listItemValue
        ''  eventControl
        script.Append("MyGet('")
        script.Append(ctrl.ClientID)
        'script.Append("'),'")
        ''  messageText
        script.Append("'),")
        script.Append("confirmSaveMessage,")
        'script.Append(message)
        'script.Append("',")
        ''  returnValueTextbox
        script.Append("MyGet('")
        script.Append(returnValueTextboxId)
        script.Append("'),")
        ''  changeTextbox
        If changeTextboxId <> "" Then
            script.Append("MyGet('")
            script.Append(changeTextboxId)
            script.Append("'),")
        Else
            script.Append("null,")
        End If
        ''  srpChangeTextbox
        If SRPChangeTextboxId <> "" Then
            script.Append("MyGet('")
            script.Append(SRPChangeTextboxId)
            script.Append("'),")
        Else
            script.Append("null,")
        End If
        ''  changeTrueValue
        script.Append("'")
        script.Append(changeTrueValue)
        script.Append("',")
        ''  listItemValue
        If listItemStr <> "" Then
            script.Append("'")
            script.Append(listItemStr)
            script.Append("'")
        Else
            script.Append("null")
        End If
        script.Append("));")
        script.Append("</script>")

        If Not ctrl.Page.ClientScript.IsStartupScriptRegistered(ctrl.ClientID & "ConfirmSave") Then
            ctrl.Page.ClientScript.RegisterStartupScript(ctrl.GetType, ctrl.ClientID & "ConfirmSave", script.ToString)
        End If

    End Sub

    Public Sub OpenMD(ByRef button As LinkButton, ByVal framePageName As String, _
                    ByVal pageName As String, ByVal winTitle As String, _
                    ByRef hdnBtn As Button, _
                    Optional ByVal dialogHeight As Integer = Nothing, _
                    Optional ByVal dialogWidth As Integer = Nothing, _
                    Optional ByVal dialogTop As Integer = Nothing, _
                    Optional ByVal dialogLeft As Integer = Nothing, _
                    Optional ByVal isCentered As Boolean = True, _
                    Optional ByVal isScrollable As Boolean = True, _
                    Optional ByVal hasStatus As Boolean = True, _
                    Optional ByVal hasHelp As Boolean = True, _
                    Optional ByVal dialogArguments As String = "null", _
                    Optional ByVal query As String = "")


        Dim hdnBtnId As String
        hdnBtnId = hdnBtn.ClientID

        Dim script As New StringBuilder
        Dim height As String
        Dim width As String
        Dim top As String
        Dim left As String
        Dim center As String
        Dim scroll As String
        Dim status As String
        Dim help As String
        Dim passQuery As String = ""

        If query <> "" Then
            query = query.Replace("?", "|")
            query = query.Replace("&", ":")
        End If

        passQuery &= "?query=" & query & "&pageName=" & pageName & "&winTitle=" & winTitle

        If Not IsNothing(dialogHeight) Then
            height = "dialogHeight:" & dialogHeight.ToString & "px;"
        Else
            height = ""
        End If

        If Not IsNothing(dialogWidth) Then
            width = "dialogWidth:" & dialogWidth.ToString & "px;"
        Else
            width = ""
        End If

        If Not IsNothing(dialogTop) Then
            top = "dialogTop:" & dialogTop.ToString & "px;"
        End If

        If Not IsNothing(dialogLeft) Then
            left = "dialogLeft:" & dialogLeft.ToString & "px;"
        End If

        If isCentered Then
            center = "center:yes;"
        Else
            center = "center:no;"
        End If

        If isScrollable Then
            scroll = "scroll:yes;"
        Else
            scroll = "scroll:no;"
        End If

        If hasStatus Then
            status = "status:yes;"
        Else
            status = "status:no;"
        End If

        If hasHelp Then
            help = "help:yes;"
        Else
            help = "help:no;"
        End If

        script.Append("<script language='javascript' for='")
        script.Append(button.ClientID)
        script.Append("' event='onclick'>")
        script.Append("var returnValue;")
        ''script.Append("returnValue = window.showModalDialog('" & framePageName & passQuery & "'," & dialogArguments & ",'" & height & width & top & left & center & scroll & status & help & "');")
        script.Append("if(document.getElementById('" & button.ClientID & "').disabled==false){")
        script.Append("returnValue = window.showModalDialog('" & framePageName & passQuery & "'," & dialogArguments & ",'" & height & width & center & scroll & status & help & "');")
        script.Append("event.returnValue = false;")
        script.Append("event.cancel = true;")
        script.Append("Form1." & hdnBtnId & ".click();}")
        script.Append("</script>")

        If Not button.Page.ClientScript.IsStartupScriptRegistered(button.ClientID & "OpenMD") Then
            button.Page.ClientScript.RegisterStartupScript(button.GetType, button.ClientID & "OpenMD", script.ToString)
        End If
    End Sub

    Public Sub ShowMessage(ByVal curPage As Page, ByVal message As String,
             Optional ByVal messageNumber As Integer = 0)

        curPage.ClientScript.RegisterStartupScript(curPage.GetType, "ShowMessage" & CStr(messageNumber),
                "<script>alert(""" & message & """)</script>")

    End Sub

    Public Sub RegisterConfirmMessage(ByVal targetControl As Control, ByVal Message As String)

        Dim script As New StringBuilder
        script.Append("<script language='javascript'> ")
        script.Append("</script>")
        targetControl.Page.ClientScript.RegisterClientScriptBlock(targetControl.GetType, "ConfirmButtonScript", "")
    End Sub

End Class
