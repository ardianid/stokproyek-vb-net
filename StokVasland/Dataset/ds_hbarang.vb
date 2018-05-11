

Partial Public Class ds_hbarang
    Partial Class DataTable1DataTable

        Private Sub DataTable1DataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.qty2Column.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
