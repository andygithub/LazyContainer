Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.InterceptionExtension

Public Class LazyRegistration

    <Fact()>
    Public Sub SimpleConcretee()
        'arrange
        Using _container As New UnityContainer
            _container.RegisterType(GetType(ControllerFour), GetType(ControllerFour))
            'act
            Dim _lazycontainer As Lazy(Of ControllerFour) = _container.Resolve(Of Lazy(Of ControllerFour))()
            Console.WriteLine("Resolve Completed")
            'assert
            Assert.False(_lazycontainer.IsValueCreated)
            Assert.IsType(Of ControllerFour)(_lazycontainer.Value)
            Assert.Equal(_lazycontainer.Value.ExeceuteMethod(False), False)
            Assert.True(_lazycontainer.IsValueCreated)
        End Using

    End Sub

    <Fact()>
    Public Sub SimpleInterface()
        'arrange
        Using _container As New UnityContainer
            _container.RegisterType(GetType(IController), GetType(ControllerFour))
            'act
            Dim _lazycontainer As Lazy(Of IController) = _container.Resolve(Of Lazy(Of IController))()
            Console.WriteLine("Resolve Completed")
            'assert
            Assert.False(_lazycontainer.IsValueCreated)
            Assert.IsType(Of ControllerFour)(_lazycontainer.Value)
            Assert.Equal(_lazycontainer.Value.ExeceuteMethod(False), False)
            Assert.True(_lazycontainer.IsValueCreated)
        End Using

    End Sub


    'http://msdn.microsoft.com/en-us/library/dn178463%28v=pandp.30%29.aspx#sec33
    'For more information about Lazy<T>, see the topic Lazy<T> Class on MSDN.
    'You can also use the Resolve method to resolve registered types by using Func<T> in a similar way.

    <Fact()>
    Public Sub ReflectionLoadWithInterception()
        'arrange
        Using _container As New UnityContainer
            _container.AddNewExtension(Of Interception)()
            _container.AddNewExtension(Of InstallerExtensionDefaultWithInterception)()
            'act
            Dim _lazycontainer As Lazy(Of IController) = _container.Resolve(Of Lazy(Of IController))(GetType(ControllerFour).FullName)
            Console.WriteLine("Resolve Completed")
            'assert
            Assert.False(_lazycontainer.IsValueCreated)
            Assert.IsNotType(Of ControllerFour)(_lazycontainer.Value)
            Assert.NotEqual(_lazycontainer.Value.ExeceuteMethod(False), False)
            Assert.True(_lazycontainer.IsValueCreated)
        End Using

    End Sub
End Class
