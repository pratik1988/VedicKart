Imports System
Imports System.Web
Imports System.Text
Imports System.Data
Imports System.IO
Imports System.Int32

Namespace EBS
    Public Class RC4
        '* 
        ' * Get ASCII Integer Code 
        ' * 
        ' * @param char ch Character to get ASCII value for 
        ' * @access private 
        ' * @return int 
        ' 

        Private Shared Function ord(ByVal ch As Char) As Integer
            Return CInt((Encoding.GetEncoding(1252).GetBytes(ch & "")(0)))
        End Function
        '* 
        ' * Get character representation of ASCII Code 
        ' * 
        ' * @param int i ASCII code 
        ' * @access private 
        ' * @return char 
        ' 

        Private Shared Function chr(ByVal i As Integer) As Char
            Dim bytes As Byte() = New Byte(0) {}
            bytes(0) = CByte(i)
            '  Return 'Encoding.GetEncoding(1252).GetString(bytes)(0)
        End Function
        '* 
        ' * Convert Hex to Binary (hex2bin) 
        ' * 
        ' * @param string packtype Rudimentary in this implementation 
        ' * @param string datastring Hex to be packed into Binary 
        ' * @access private 
        ' * @return string 
        ' 

        Private Shared Function pack(ByVal packtype As String, ByVal datastring As String) As String
            Dim i As Integer, j As Integer, datalength As Integer, packsize As Integer
            Dim bytes As Byte()
            Dim hex As Char()
            Dim tmp As String

            datalength = datastring.Length
            packsize = (datalength / 2) + (datalength Mod 2)
            bytes = New Byte(packsize - 1) {}
            hex = New Char(1) {}

            'For i = InlineAssignHelper(j, 0) To datalength - 1 Step 2
            '    hex(0) = datastring(i)
            '    If datalength - i = 1 Then
            '        hex(1) = "0"c
            '    Else
            '        hex(1) = datastring(i + 1)
            '    End If
            '    tmp = New String(hex, 0, 2)
            '    Try
            '        bytes(System.Math.Max(System.Threading.Interlocked.Increment(j), j - 1)) = Byte.Parse(tmp, System.Globalization.NumberStyles.HexNumber)
            '    Catch
            '        ' grin 
            '    End Try
            'Next
            Return Encoding.GetEncoding(1252).GetString(bytes)
        End Function
        '* 
        ' * Convert Binary to Hex (bin2hex) 
        ' * 
        ' * @param string bindata Binary data 
        ' * @access public 
        ' * @return string 
        ' 

        Public Shared Function bin2hex(ByVal bindata As String) As String
            Dim i As Integer
            Dim bytes As Byte() = Encoding.GetEncoding(1252).GetBytes(bindata)
            Dim hexString As String = ""
            For i = 0 To bytes.Length - 1
                hexString += bytes(i).ToString("x2")
            Next
            Return hexString
        End Function
        '* 
        ' * The symmetric encryption function 
        ' * 
        ' * @param string pwd Key to encrypt with (can be binary of hex) 
        ' * @param string data Content to be encrypted 
        ' * @param bool ispwdHex Key passed is in hexadecimal or not 
        ' * @access public 
        ' * @return string 
        ' 

        Public Shared Function Encrypt(ByVal pwd As String, ByVal data As String, ByVal ispwdHex As Boolean) As String
            Dim a As Integer, i As Integer, j As Integer, k As Integer, tmp As Integer, pwd_length As Integer, _
            data_length As Integer
            Dim key As Integer(), box As Integer()
            Dim cipher As Byte()
            'string cipher; 

            If ispwdHex Then
                pwd = pack("H*", pwd)
            End If
            ' valid input, please! 
            pwd_length = pwd.Length
            data_length = data.Length
            key = New Integer(255) {}
            box = New Integer(255) {}
            cipher = New Byte(data.Length - 1) {}
            'cipher = ""; 

            For i = 0 To 255
                key(i) = ord(pwd.Substring((i Mod pwd_length)))
                box(i) = i
            Next
            j = InlineAssignHelper(256, 0)
            i = 0
            While i < 256
                j = (j + box(i) + key(i)) Mod 256
                tmp = box(i)
                box(i) = box(j)
                box(j) = tmp
                i += 1
            End While
            a = InlineAssignHelper(j, InlineAssignHelper(i, 0))
            While i < data_length
                a = (a + 1) Mod 256
                j = (j + box(a)) Mod 256
                tmp = box(a)
                box(a) = box(j)
                box(j) = tmp
                k = box(((box(a) + box(j)) Mod 256))
                ' cipher += chr(ord(data[i]) ^ k); 
                cipher(i) = CByte((ord(data.Substring(i)) Xor k))
                i += 1
            End While
            'return cipher; 
            Return Encoding.GetEncoding(1252).GetString(cipher)
        End Function
        '* 
        ' * Decryption, recall encryption 
        ' * 
        ' * @param string pwd Key to decrypt with (can be binary of hex) 
        ' * @param string data Content to be decrypted 
        ' * @param bool ispwdHex Key passed is in hexadecimal or not 
        ' * @access public 
        ' * @return string 
        ' 

        Public Shared Function Decrypt(ByVal pwd As String, ByVal data As String, ByVal ispwdHex As Boolean) As String
            Return Encrypt(pwd, data, ispwdHex)
        End Function
        Private Shared Function InlineAssignHelper(ByRef target As Integer, ByVal value As Integer) As Integer
            target = value
            Return value
        End Function
    End Class
End Namespace