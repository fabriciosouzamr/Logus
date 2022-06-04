Imports System.DirectoryServices
Imports System.Configuration

Public Class User
    Public UserEmail As String
    Public UserADID As String
    Public UserDSUID As String
    Public UserFirstName As String
    Public UserLastName As String
    Public UserBusinessUnit As String
End Class

Public Class DS
    Private Shared _LDAP_Path As String = "LDAP://ldap.ds.cargill.com/ou=People,o=Cargill" 'ConfigurationSettings.AppSettings("LDAP_PATH")

    Public Shared Function getDSUID(ByVal pDSID As String) As Integer
        Dim de As New DirectoryEntry(_LDAP_Path, Nothing, Nothing, DirectoryServices.AuthenticationTypes.ServerBind)
        Dim ds As New DirectorySearcher(de)
        Dim sr As SearchResult

        ds.PropertiesToLoad.Add("uniqueid")
        ds.Filter = "(pensid=" & pDSID & ")"
        sr = ds.FindOne()

        Return CInt(sr.Properties("uniqueid")(0))

        de.Dispose()
        ds.Dispose()
    End Function

    Public Shared Function getUser(ByVal pDSUID As Integer) As User
        Dim lUser As New User
        Dim de As New DirectoryEntry(_LDAP_Path, Nothing, Nothing, DirectoryServices.AuthenticationTypes.ServerBind)
        Dim ds As New DirectorySearcher(de)
        Dim sr As SearchResult

        ds.Filter = "(uniqueid=" & pDSUID & ")"
        sr = ds.FindOne()

        If sr Is Nothing Then
            With lUser
                .UserEmail = "no_employee@cargill.com"
                .UserADID = "noemployee"
                .UserDSUID = pDSUID
                .UserFirstName = "No Longer"
                .UserLastName = "With Cargill"
                .UserBusinessUnit = "unknown"
            End With
        Else
            If sr.Properties("mail") Is Nothing Then
                If sr.Properties("preferredRfc822Originator") Is Nothing Then
                    lUser.UserEmail = "unkown@cargill.com"
                Else
                    lUser.UserEmail = CStr(sr.Properties("preferredRfc822Originator")(0))
                End If
            Else
                lUser.UserEmail = CStr(sr.Properties("mail")(0))
            End If
            lUser.UserADID = CStr(sr.Properties("pensid")(0))
            lUser.UserDSUID = CInt(sr.Properties("uniqueid")(0))
            lUser.UserFirstName = CStr(sr.Properties("givenname")(0))
            lUser.UserLastName = CStr(sr.Properties("sn")(0))
            If sr.Properties("businesssector") Is Nothing Then
                lUser.UserBusinessUnit = "unknown"
            Else
                lUser.UserBusinessUnit = CStr(sr.Properties("businesssector")(0))
            End If
        End If

        Return lUser
    End Function

    Public Shared Function findUser(ByVal pFirstName As String, ByVal pLastName As String) As User()
        Dim lUser As User
        Dim lreturn As New ArrayList
        Dim de As New DirectoryEntry(_LDAP_Path, Nothing, Nothing, DirectoryServices.AuthenticationTypes.ServerBind)
        Dim ds As New DirectorySearcher(de)
        Dim src As SearchResultCollection
        Dim sr As SearchResult

        ds.Filter = "(&(&(givenname=" & pFirstName & "*)(sn=" & pLastName & "*))(mail=*))"
        src = ds.FindAll()
        For Each sr In src
            lUser = New User
            lUser.UserADID = CStr(sr.Properties("pensid")(0))
            lUser.UserDSUID = CInt(sr.Properties("uniqueid")(0))
            lUser.UserFirstName = CStr(sr.Properties("givenname")(0))
            lUser.UserLastName = CStr(sr.Properties("sn")(0))
            lUser.UserEmail = CStr(sr.Properties("mail")(0))
            lUser.UserBusinessUnit = CStr(sr.Properties("businesssector")(0))
            lreturn.Add(lUser)
        Next

        Return CType(lreturn.ToArray(GetType(User)), User())
    End Function
End Class