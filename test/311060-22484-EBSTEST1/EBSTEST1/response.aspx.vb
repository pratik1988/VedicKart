Imports System.Data
Imports System.IO
Imports System.Text

Namespace EBS
    Public Class WebForm1

        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private responsecode As String = String.Empty
        Private ResponseMessage As String = String.Empty
        Private Datecreated As String = String.Empty
        Private Paymentid As String = String.Empty
        Private transationid As String = String.Empty
        Private merchandid As String = String.Empty


        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here

            Dim sQS As String
            Dim aQs() As String
            Dim lsDetail As String
            Dim lsDetail1 As String
            Dim lsDetail2 As String
            Dim pwd As String = "6828fa624797de42c61fa352ea9a8f5f"
            Dim DR As String = "ByRBg/Of8M63oouIt5kFj0qHiPc9c/DYqytODiD5vHTmLN+zBVCVwUXFyds+lTsl5BbjOZ3+9Djd3h2T5XXyLyjaELBv5Gy7SRpQ9pS67YVn+AyZsVO4NBFlefv33niNQcD/Ps7ODfZrGGuIrO4k8MjTesbhPh9uzUzuQ70fC16J+7B6JF0Md7a25Z7OiRqkNwo3ssGPq2JmB6Z16da/+R8E1OICx18JkrITy+4Q7/f0UA9W8jNnL6s/jwVtI5sYfq07mMpn7nIM" 'Request.QueryString("DR").ToString()
            DR = DR.Replace(" "c, "+"c)
            sQS = Base64Decode(DR)
            DR = RC4.Decrypt(pwd, sQS, False)
            aQs = DR.Split("&"c)
            For Each param As String In aQs
                Dim aParam As Array = param.Split("="c)
                If aParam(0) = "ResponseCode" Then
                    responsecode = aParam(1)
                End If
                If aParam(0) = "ResponseMessage" Then
                    ResponseMessage = aParam(1)
                End If

                If aParam(0) = "DateCreated" Then
                    Datecreated = aParam(1)
                End If

                If aParam(0) = "PaymentID" Then
                    Paymentid = aParam(1)

                End If

                If aParam(0) = "MerchantRefNo" Then
                    merchandid = aParam(1)
                End If

                If aParam(0) = "TransactionID" Then
                    transationid = aParam(1)
                End If

            Next
            If merchandid = "SGSDomaincreate" Then
                If (responsecode = "0") Then
                    ' Response.Write("<form name=""myForm"" method=""post"" action=""" & strSuccessurl & "/frmPaymentSuccess.aspx"">")
                    Response.Write("<form name=""myForm"" method=""post"" action=""http:\\netandhost.com\frmPaymentSuccess.aspx"">")
                    Response.Write("<input type=""hidden"" name=""Params"" value=""" + DR + """>")
                    Response.Write("</form>")
                    PostToForm()
                Else
                    'If (Checksum = "true") AndAlso (AuthDesc = "N") Then
                    '  Response.Write("<form name=""myForm"" method=""post"" action=""" & strSuccessurl & "/frmPaymentFailed.aspx"">")
                    Response.Write("<form name=""myForm"" method=""post"" action=""http:\\netandhost.com\frmPaymentFailed.aspx "">")
                    Response.Write("<input type=""hidden"" name=""Params"" value=""" + DR + """>")
                    Response.Write("</form>")
                    PostToForm()
                End If
            Else
                If (responsecode = "0") Then
                    ' Response.Write("<form name=""myForm"" method=""post"" action=""" & strSuccessurl & "/frmPaymentSuccess.aspx"">")
                    Response.Write("<form name=""myForm"" method=""post"" action=""frmsuccess.aspx"">")
                    Response.Write("<input type=""hidden"" name=""Params"" value=""" + DR + """>")
                    Response.Write("</form>")
                    PostToForm()
                Else
                    'If (Checksum = "true") AndAlso (AuthDesc = "N") Then
                    '  Response.Write("<form name=""myForm"" method=""post"" action=""" & strSuccessurl & "/frmPaymentFailed.aspx"">")
                    Response.Write("<form name=""myForm"" method=""post"" action="" frmfail.aspx "">")
                    Response.Write("<input type=""hidden"" name=""Params"" value=""" + DR + """>")
                    Response.Write("</form>")
                    PostToForm()

                    'Else
                    '    If (Checksum = "true") AndAlso (AuthDesc = "B") Then
                    '        Response.Write("<form name=""myForm"" method=""post"" action=""" & strSuccessurl & "/frmPaymentSuccess.aspx"">")
                    '        Response.Write("<input type=""hidden"" name=""Params"" value=""" + Merchant_Param + """>")
                    '        Response.Write("</form>")
                    '        PostToForm()
                    '    Else
                    '        Response.Write("<form name=""myForm"" method=""post"" action=""" & strSuccessurl & "/frmPaymentSuccess.aspx"">")
                    '        Response.Write("<input type=""hidden"" name=""Params"" value=""" + Merchant_Param + """>")
                    '        Response.Write("</form>")
                    '        PostToForm()
                    '    End If
                    'End If
                End If
            End If

        End Sub
        Private Sub PostToForm()
            Response.Write("<script language=""javascript"">")
            Response.Write("document.myForm.submit()")
            Response.Write("</script>")
        End Sub
        Private Function Base64Decode(ByVal sBase64String As String) As String
            Dim sBase64String_bytes As Byte() = Convert.FromBase64String(sBase64String)
            'return UnicodeEncoding.ASCII.GetString(sBase64String_bytes); 
            Return UnicodeEncoding.[Default].GetString(sBase64String_bytes)
        End Function

    End Class
End Namespace



