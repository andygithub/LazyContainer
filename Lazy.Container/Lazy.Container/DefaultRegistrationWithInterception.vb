Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.InterceptionExtension

Public Class DefaultRegistrationWithInterception

    <Fact()>
    Public Sub SimpleTest()
        'arrange
        Using _container As New UnityContainer
            _container.AddNewExtension(Of Interception)()
            _container.AddNewExtension(Of InstallerExtensionDefaultWithInterception)()
            'act
            Dim _controller As IController = _container.Resolve(Of IController)(GetType(ControllerFour).FullName)
            Dim _repository As IRepository = _container.Resolve(Of IRepository)(GetType(RepositoryFour).FullName)
            Console.WriteLine("Resolve Completed")
            'assert
            'the proxy type will be returned for this
            Assert.IsNotType(Of ControllerFour)(_controller)
            Assert.IsNotType(Of RepositoryFour)(_repository)
            'interception is hooked up and modifying only return value
            Assert.NotEqual(_controller.ExeceuteMethod(False), False)
            Assert.NotEqual(_repository.ExeceuteMethod(False), False)
        End Using
    End Sub


End Class
