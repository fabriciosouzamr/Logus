'Imports Oracle.DataAccess
Imports System.Data.OracleClient
Imports System.Runtime.InteropServices
Imports GrFingerXLib
Imports Microsoft.VisualBasic
Imports System.io

' Template data
Public Class TTemplate
	' Template itself
    Public tpt As System.Array = Array.CreateInstance(GetType(Byte), GrFingerXLib.GRConstants.GR_MAX_SIZE_TEMPLATE)
    ' Template size
	Public Size As Long
End Class

' Template list
Public Structure TTemplates
	' ID
	Public ID As Integer
	' Template itself
	Public template As TTemplate
End Structure

Public Class Biometria
    Public Function AddTemplate(ByRef template As TTemplate) As Integer
        Dim SqlText As String

        Dim fs As New FileStream(Application.StartupPath + "\temp.dat", FileMode.Open)
        Dim arbyte(fs.Length) As Byte
        fs.Read(arbyte, 0, arbyte.Length)
        fs.Close()

        SqlText = DBMontar_Insert("AGC.SEC_USUARIO_DIGITAL", TipoCampoFixo.Nenhum, "SQ_USUARIO_DIGITAL", ":SQ_USUARIO_DIGITAL", _
                                                                                   "CD_USUARIO", ":CD_USUARIO", _
                                                                                   "IM_DIGITAL", ":IM_DIGITAL", _
                                                                                   "NU_DIGITAL", ":NU_DIGITAL")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQ_USUARIO_DIGITAL", DBNumeroMaisUm("AGC.SEC_USUARIO_DIGITAL", "SQ_USUARIO_DIGITAL")), _
                                   DBParametro_Montar("CD_USUARIO", sAcesso_UsuarioLogado), _
                                   DBParametro_Montar("IM_DIGITAL", arbyte, DbType.Binary, , arbyte.Length), _
                                   DBParametro_Montar("NU_DIGITAL", template.tpt, DbType.Binary, ParameterDirection.Input, template.Size)) Then GoTo erro

        Return 1

        Exit Function

Erro:
        TratarErro()
    End Function

    '' Event procedure for OnRowUpdated
    'Private Sub OnRowUpdated(ByVal sender As Object, ByVal args As OleDbRowUpdatedEventArgs)
    '    ' Include a variable and a command to retrieve identity value
    '    ' from Access database.
    '    Dim newID As Integer = 0
    '    Dim idCMD As OleDbCommand = New OleDbCommand("SELECT @@IDENTITY", connection)

    '    If args.StatementType = StatementType.Insert Then
    '        ' Retrieve identity value and store it in column
    '        newID = CInt(idCMD.ExecuteScalar())
    '        args.Row("ID") = newID
    '    End If
    'End Sub

    ' Returns a DataTable with all enrolled templates from database.
    Public Function getTemplates() As TTemplates()
        Dim ttpts As TTemplates()
        Dim tpts As DataTable
        Dim i As Integer

        tpts = DBQuery("SELECT SQ_USUARIO_DIGITAL, CD_USUARIO , NU_DIGITAL  FROM AGC.SEC_USUARIO_DIGITAL")

        'Cria um arrey
        ReDim ttpts(tpts.Rows.Count)
        'caso o select retorn nada
        If tpts.Rows.Count = 0 Then Return ttpts

        'inseri digitais no array
        For i = 1 To tpts.Rows.Count
            ttpts(i).template = New TTemplate
            ttpts(i).ID = tpts.Rows(i - 1).Item("SQ_USUARIO_DIGITAL")
            ttpts(i).template.tpt = tpts.Rows(i - 1).Item("NU_DIGITAL")
            ttpts(i).template.Size = ttpts(i).template.tpt.Length
        Next
        Return ttpts
    End Function

    ' Returns template with supplied ID.
    Public Function getTemplate(ByVal id As Long) As Byte()
        Dim tptVazio(0) As Byte
        Dim tpt As New TTemplate
        Dim oData As DataTable

        oData = DBQuery("SELECT * FROM AGC.SEC_USUARIO_DIGITAL WHERE SQ_USUARIO_DIGITAL = " & id)

        Dim tpts As DataRowCollection = oData.Rows
        ' No results?
        If tpts.Count <> 1 Then Return tptVazio
        ' Deserialize template and return it
        Return tpts.Item(0).Item("nu_digital")
    End Function

End Class

'-------------------------------------------------------------------------------
'GrFinger Sample
'(c) 2005 Griaule Tecnologia Ltda.
'http://www.griaule.com
'-------------------------------------------------------------------------------
'
'This sample is provided with "GrFinger Fingerprint Recognition Library" and
'can't run without it. It's provided just as an example of using GrFinger
'Fingerprint Recognition Library and should not be used as basis for any
'commercial product.
'
'Griaule Tecnologia makes no representations concerning either the merchantability
'of this software or the suitability of this sample for any particular purpose.
'
'THIS SAMPLE IS PROVIDED BY THE AUTHOR "AS IS" AND ANY EXPRESS OR
'IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
'OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
'IN NO EVENT SHALL GRIAULE BE LIABLE FOR ANY DIRECT, INDIRECT,
'INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
'NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
'DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
'THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
'(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
'THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'
'You can download the free version of GrFinger directly from Griaule website.
'
'These notices must be retained in any copies of any part of this
'documentation and/or sample.
'
'-------------------------------------------------------------------------------

' -----------------------------------------------------------------------------------
' Support and fingerprint management routines
' -----------------------------------------------------------------------------------

' Raw image data type.
Public Structure RawImage
	' Image data.
	Public img As Object
	' Image width.
	Public width As Long
	' Image height.
	Public height As Long
	' Image resolution.
	Public res As Long
End Structure

Public Class Util

	' Some constants to make our code cleaner
    Public Const ERR_CANT_OPEN_BD As Integer = -999
    Public Const ERR_INVALID_ID As Integer = -998
    Public Const ERR_INVALID_TEMPLATE As Integer = -997

	' Importing necessary HDC functions
    Private Declare Function GetDC Lib "user32" (ByVal hwnd As Int32) As Int32
    Private Declare Function ReleaseDC Lib "user32" (ByVal hwnd As Int32, ByVal hdc As Int32) As Int32

	' The last acquired image.
	Public raw As RawImage
	' The template extracted from last acquired image.
	Public template As New TTemplate
	' Database class.
    Public Bio As Biometria
	' Reference to main form log.
	Private _lbLog As ListBox
	' Reference to main form Image.
	Private _pbPic As PictureBox
	' GrFingerX component
	Private _GrFingerX As AxGrFingerXLib.AxGrFingerXCtrl

	' -----------------------------------------------------------------------------------
	' Support functions
	' -----------------------------------------------------------------------------------

	' This class creates an Util class with some functions
	' to help us to develop our GrFinger Application

    Public Sub New(ByRef lbLog As ListBox, ByRef pbPic As PictureBox, ByRef GrFingerX As AxGrFingerXLib.AxGrFingerXCtrl)
        _lbLog = lbLog
        _pbPic = pbPic
        _GrFingerX = GrFingerX
    End Sub


	' Write a message in box.
	Public Sub WriteLog(ByVal message As String)
		_lbLog.Items.Add(message)
		_lbLog.SelectedIndex = _lbLog.Items.Count - 1
		_lbLog.ClearSelected()
	End Sub

	' Write and describe an error.
	Public Sub WriteError(ByVal errorCode As Integer)
		Select Case errorCode
			Case GRConstants.GR_ERROR_INITIALIZE_FAIL
				WriteLog("Fail to Initialize GrFingerX. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_NOT_INITIALIZED
				WriteLog("The GrFingerX Library is not initialized. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_FAIL_LICENSE_READ
				WriteLog("License not found. See manual for troubleshooting. (Error:" + errorCode + ")")
				MessageBox.Show("License not found. See manual for troubleshooting.")
			Case GRConstants.GR_ERROR_NO_VALID_LICENSE
				WriteLog("The license is not valid. See manual for troubleshooting. (Error:" + errorCode + ")")
				MessageBox.Show("The license is not valid. See manual for troubleshooting.")
			Case GRConstants.GR_ERROR_NULL_ARGUMENT
				WriteLog("The parameter have a null value. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_FAIL
				WriteLog("Fail to create a GDI object. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_ALLOC
				WriteLog("Fail to create a context. Cannot allocate memory. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_PARAMETERS
				WriteLog("One or more parameters are out of bound. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_WRONG_USE
				WriteLog("This function cannot be called at this time. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_EXTRACT
				WriteLog("Template Extraction failed. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_SIZE_OFF_RANGE
				WriteLog("Image is too larger or too short.  (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_RES_OFF_RANGE
				WriteLog("Image have too low or too high resolution. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_CONTEXT_NOT_CREATED
				WriteLog("The Context could not be created. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_INVALID_CONTEXT
				WriteLog("The Context does not exist. (Error:" + errorCode + ")")

				' Capture error codes

			Case GRConstants.GR_ERROR_CONNECT_SENSOR
				WriteLog("Error while connection to sensor. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_CAPTURING
				WriteLog("Error while capturing from sensor. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_CANCEL_CAPTURING
				WriteLog("Error while stop capturing from sensor. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_INVALID_ID_SENSOR
				WriteLog("The idSensor is invalid. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_SENSOR_NOT_CAPTURING
				WriteLog("The sensor is not capturing. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_INVALID_EXT
				WriteLog("The File have a unknown extension. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_INVALID_FILENAME
				WriteLog("The filename is invalid. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_INVALID_FILETYPE
				WriteLog("The file type is invalid. (Error:" + errorCode + ")")
			Case GRConstants.GR_ERROR_SENSOR
				WriteLog("The sensor raise an error. (Error:" + errorCode + ")")

				' Our error codes

			Case ERR_INVALID_TEMPLATE
				WriteLog("Invalid Template. (Error:" + errorCode + ")")
			Case ERR_INVALID_ID
				WriteLog("Invalid ID. (Error:" + errorCode + ")")
			Case ERR_CANT_OPEN_BD
				WriteLog("Unable to connect to DataBase. (Error:" + errorCode + ")")
			Case Else
				WriteLog("Error:" + errorCode)
		End Select
	End Sub

	' Check if we have a valid template
	Private Function TemplateIsValid() As Boolean
		' Check template size
		Return template.Size > 0
	End Function

	' -----------------------------------------------------------------------------------
	' Main functions for fingerprint recognition management
	' -----------------------------------------------------------------------------------

	' Initializes GrFinger ActiveX and all necessary utilities.
	Public Function InitializeGrFinger() As Integer
		Dim err As Integer

        Bio = New Biometria
        '' Open DataBase
        'If DB.OpenDB() = False Then Return ERR_CANT_OPEN_BD
		' Create a new Template
		template.Size = 0
		' Create a new raw image
		raw.img = Nothing
		raw.width = 0
		raw.height = 0
		' Initializing library
		err = _GrFingerX.Initialize()
		If err < 0 Then Return err
		Return _GrFingerX.CapInitialize()
	End Function

	' Finalizes and close the DB.
	Public Sub FinalizeGrFinger()
		' finalize library
		_GrFingerX.Finalize()
		_GrFingerX.CapFinalize()
		' close DB
        'DB.closeDB()
        Bio = Nothing
	End Sub

	' Display fingerprint image on screen
    ' Display fingerprint image on screen
    Public Sub PrintBiometricDisplay(ByVal biometricDisplay As Boolean, ByVal context As Integer)

        ' handle to finger image
        Dim handle As System.Drawing.Image = Nothing

        ' screen HDC
        Dim hdc As Integer = GetDC(0)

        If biometricDisplay Then
            ' get image with biometric info
            _GrFingerX.BiometricDisplay(template.tpt, raw.img, raw.width, raw.height, raw.res, hdc, handle, context)
        Else
            ' get raw image
            _GrFingerX.CapRawImageToHandle(raw.img, raw.width, raw.height, hdc, handle)
        End If

        ' draw image on picture box
        If Not (handle Is Nothing) Then
            _pbPic.Image = handle
            _pbPic.Update()

            '_pbPic.SizeMode = PictureBoxSizeMode.StretchImage
            _pbPic.Image.Save(Application.StartupPath + "\temp.dat", Imaging.ImageFormat.Jpeg)
        End If
        ' release screen HDC
        ReleaseDC(0, hdc)
    End Sub



    ' Add a fingerprint template to database
    Public Function Enroll() As Integer
        ' Checking if template is valid.
        If TemplateIsValid() Then
            ' Adds template to database and gets ID.
            Return Bio.AddTemplate(template)
        Else
            Return -1
        End If
    End Function

    ' Extract a fingerprint template from current image
    Function ExtractTemplate() As Integer
        Dim ret As Integer

        ' set current buffer size for extract template
        template.Size = template.tpt.Length

        ret = _GrFingerX.Extract(raw.img, raw.width, raw.height, raw.res, template.tpt, template.Size, GRConstants.GR_DEFAULT_CONTEXT)
        ' if error, set template size to 0
        ' Result < 0 => extraction problem
        If ret < 0 Then template.Size = 0
        Return ret
    End Function

    ' Identify current fingerprint on our database
    Public Function Identify(ByRef score As Integer) As Integer
        Dim ret As Integer
        Dim i As Integer

        ' Checking if template is valid.
        If Not TemplateIsValid() Then Return ERR_INVALID_TEMPLATE

        ' Starting identification process and supplying query template.

        Dim tmpTpt As Array = Array.CreateInstance(GetType(Byte), template.Size)
        Array.Copy(template.tpt, tmpTpt, template.Size)
        ret = _GrFingerX.IdentifyPrepare(tmpTpt, GRConstants.GR_DEFAULT_CONTEXT)
        ' error?
        If ret < 0 Then Return ret
        ' Getting enrolled templates from database.
        Dim templates As TTemplates() = Bio.getTemplates()
        ' Iterate over all templates in database
        For i = 1 To templates.Length
            ' Comparing the current template.
            If Not (templates(i - 1).template Is Nothing) Then
                Dim tempTpt As Array = Array.CreateInstance(GetType(Byte), templates(i - 1).template.Size)
                Array.Copy(templates(i - 1).template.tpt, tempTpt, templates(i - 1).template.Size)
                ret = _GrFingerX.Identify(tempTpt, score, GRConstants.GR_DEFAULT_CONTEXT)
            End If
            ' Checking if query template and reference template match.
            If ret = GRConstants.GR_MATCH Then
                Return templates(i - 1).ID
            End If
            If ret < 0 Then Return ret
        Next
        ' end of database, return "no match" code
        Return GRConstants.GR_NOT_MATCH
    End Function

  

    ' Check current fingerprint against another one in our database
    Public Function Verify(ByVal id As Integer, ByRef score As Integer) As Integer
        Dim tptref As System.Array

        ' Checking if template is valid.
        If Not (TemplateIsValid()) Then Return ERR_INVALID_TEMPLATE
        ' Getting template with the supplied ID from database.
        tptref = Bio.getTemplate(id)
        ' Checking if ID was found.
        If tptref Is Nothing Then Return ERR_INVALID_ID
        ' Comparing templates.
        Dim tempTpt As Array = Array.CreateInstance(GetType(Byte), template.Size)
        Array.Copy(template.tpt, tempTpt, template.Size)
        Return _GrFingerX.Verify(tempTpt, tptref, score, GRConstants.GR_DEFAULT_CONTEXT)
    End Function


End Class