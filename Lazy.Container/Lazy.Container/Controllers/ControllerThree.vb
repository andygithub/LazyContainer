﻿Public Class ControllerThree
    Implements IController

    Sub New()
        Console.WriteLine("Constructor:" & GetType(ControllerThree).FullName)
    End Sub

    Public Function ExeceuteMethod(value As Boolean) As Boolean Implements IController.ExeceuteMethod
        Return value
    End Function

End Class
