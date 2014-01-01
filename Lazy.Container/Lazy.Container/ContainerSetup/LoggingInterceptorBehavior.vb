Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.InterceptionExtension

Public Class LoggingInterceptorBehavior
    Implements IInterceptionBehavior

    ''' <summary>
    ''' Implementation of required method for interface.
    ''' </summary>
    ''' <returns>Returns a list of types that are required for this invoke method to be part of the interception chain.</returns>
    ''' <remarks></remarks>
    Public Function GetRequiredInterfaces() As System.Collections.Generic.IEnumerable(Of System.Type) Implements Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior.GetRequiredInterfaces
        Return New List(Of Type)(New Type() {GetType(IController)}) ' Type.EmptyTypes
    End Function

    ''' <summary>
    ''' Implementation of the invoke method which does some simple logging of the defined interface parameters.
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="getNext"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Invoke(input As Microsoft.Practices.Unity.InterceptionExtension.IMethodInvocation, getNext As Microsoft.Practices.Unity.InterceptionExtension.GetNextInterceptionBehaviorDelegate) As Microsoft.Practices.Unity.InterceptionExtension.IMethodReturn Implements Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior.Invoke
        Console.WriteLine("Starting Execute: " & input.Target.ToString & "-" & input.MethodBase.Name)
        'LoggingFacade.LogInformationMessage(String.Format(Resources.UIMessages.ExecutingTransform, input.Target.ToString, input.MethodBase.Name))
        Dim result = getNext.Invoke(input, getNext)
        'LoggingFacade.LogInformationMessage(result.ReturnValue.ToString)
        Console.WriteLine("Ending Execute: " & input.Target.ToString & "-" & input.MethodBase.Name)
        result.ReturnValue = Not CType(result.ReturnValue, Boolean)
        Return result
    End Function

    ''' <summary>
    ''' Method to determine if the behavior will execute.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WillExecute As Boolean Implements Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior.WillExecute
        Get
            Return True
        End Get
    End Property


End Class
