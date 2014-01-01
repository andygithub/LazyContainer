Public Class RepositoryOne
    Implements IRepository

    Sub New()
        Console.WriteLine("Constructor:" & GetType(RepositoryOne).FullName)
    End Sub

    Public Function ExeceuteMethod(value As Boolean) As Boolean Implements IRepository.ExeceuteMethod
        Return value
    End Function

End Class
