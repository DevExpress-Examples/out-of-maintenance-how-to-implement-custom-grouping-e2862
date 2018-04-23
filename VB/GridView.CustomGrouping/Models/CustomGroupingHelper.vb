Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Collections

Namespace GridView.CustomGrouping.Models
	Public NotInheritable Class CustomGroupingHelper
		Private Sub New()
		End Sub
		Public Shared Function Compare(ByVal columnName As String, ByVal value1 As Object, ByVal value2 As Object) As Integer
			Dim res As Integer = 0
			If columnName = "UnitPrice" Then
				Dim x As Double = Math.Floor(Convert.ToDouble(value1) / 10)
				Dim y As Double = Math.Floor(Convert.ToDouble(value2) / 10)
				res = Comparer.Default.Compare(x, y)
				If x > 9 AndAlso y > 9 Then
					res = 0
				End If
			End If

			Return res
		End Function
		Public Shared Function GetUnitPriceColumnText(ByVal value As Object) As String
			Dim d As Double = Math.Floor(Convert.ToDouble(value) / 10)
			Dim displayText As String = String.Format("{0:c} - {1:c} ", d * 10, (d + 1) * 10)
			If d > 9 Then
				displayText = String.Format(">= {0:c} ", 100)
			End If
			Return displayText
		End Function
	End Class
End Namespace