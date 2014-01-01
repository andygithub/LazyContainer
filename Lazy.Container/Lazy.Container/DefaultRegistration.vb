Imports Microsoft.Practices.Unity

Public Class DefaultRegistration

    <Fact()>
    Public Sub SimpleTest()
        'arrange
        Using _container As New UnityContainer
            _container.AddNewExtension(Of InstallerExtensionDefault)()
            'act
            Dim _controller As IController
            Dim _repository As IRepository
            _controller = _container.Resolve(Of IController)(GetType(ControllerFour).FullName)
            _repository = _container.Resolve(Of IRepository)(GetType(RepositoryFour).FullName)
            Console.WriteLine("Resolve Completed")
            'assert
            Assert.IsType(Of ControllerFour)(_controller)
            Assert.IsType(Of RepositoryFour)(_repository)
            Assert.Equal(_controller.ExeceuteMethod(False), False)
            Assert.Equal(_repository.ExeceuteMethod(False), False)
        End Using
        
    End Sub


End Class
