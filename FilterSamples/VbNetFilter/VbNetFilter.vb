Public Module VbNetFilter

	Sub Main()
		FilterException()
	End Sub

	Sub FilterException()
		Try
			Dim exception As New Exception
			exception.Data.Add("foo", "bar1")

			Console.WriteLine("Throwing")
			Throw exception
		Catch ex As Exception When Filter(ex) ' здесь фильтр
			Console.WriteLine("Caught")
		Finally
			Console.WriteLine("Finally")
		End Try

	End Sub

	Function Filter(exception As Exception) As Boolean
		Console.WriteLine("Filtering")
		Return exception.Data.Item("foo").Equals("bar")
	End Function

End Module
