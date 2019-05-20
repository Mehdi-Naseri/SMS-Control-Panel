
Partial Class VB
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sms As New WebService.Send()
        Dim rec As Long() = Nothing
        Dim status As Byte() = Nothing

        'retval :
        ' InvalidUserPass=0,
        ' Successfull = 1,
        ' NoCredit = 2,
        ' DailyLimit = 3,
        ' SendLimit = 4,
        ' InvalidNumber = 5

        'Status :
        ' Sent=0,
        ' Failed=1

        Dim retval As Integer = sms.SendSms("demo", "demo", New String() {"9122838...", "9374659..."}, "1000...", "سلام", False, _
         "", rec, status)

        Response.Write(retval)
        Response.Write("<br>")
        For i As Integer = 0 To status.Length - 1
            Response.Write(status(i))
        Next

    End Sub
End Class
