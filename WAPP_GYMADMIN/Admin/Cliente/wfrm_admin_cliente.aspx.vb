﻿Imports System.Data
Imports System.Data.OleDb
Public Class wfrm_admin_cliente

    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGuardar.Click
        Dim query As String = "INSERT INTO Cliente (Nombre,Apellido,Edad,Cedula) VALUES (@Nombre,@Apellido,@Edad,@Cedula)"
        Using conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\R4FI3L\Desktop\GymAdmin\WAPP_GYMADMIN\App_Data\GymData.mdb;Persist Security Info=True")
            Using comand As New OleDbCommand()
                With comand
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@Nombre", TxtNombre.Text)
                    .Parameters.AddWithValue("@Apellido", TxtApellido.Text)
                    .Parameters.AddWithValue("@Edad", TxtEdad.Text)
                    .Parameters.AddWithValue("@Cedula", TxtCedula.Text)
                End With
                Try
                    conn.Open()
                    comand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "Error")
                End Try
            End Using
        End Using
    End Sub
End Class