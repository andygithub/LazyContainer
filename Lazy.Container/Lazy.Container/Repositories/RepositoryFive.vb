Public Class RepositoryFive
    Implements IRepository

    Sub New()
        Console.WriteLine("Constructor:" & GetType(RepositoryFive).FullName)
    End Sub


    Public Function ExeceuteMethod(value As Boolean) As Boolean Implements IRepository.ExeceuteMethod
        Return value
    End Function

End Class
