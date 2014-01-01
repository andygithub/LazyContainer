Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.InterceptionExtension

''' <summary>
''' The class is used to bootstrap the container with defined components.
''' </summary>
''' <remarks>This was necessary because unity doesn't support fluent registration and the UnityContainerExtension was used becuase that was equivalent to IWindsorInstaller.</remarks>
Public Class InstallerExtensionDefaultWithInterception
    Inherits UnityContainerExtension

    ''' <summary>
    ''' This is the method that builds the components in the container.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Initialize()
        Me.Container.RegisterTypes(AllClasses.FromLoadedAssemblies().Where(Function(x) Not x.IsInterface AndAlso
                                                                               (GetType(IController).IsAssignableFrom(x) OrElse GetType(IRepository).IsAssignableFrom(x))),
                                            Function(x) WithMappings.FromAllInterfacesInSameAssembly(x),
                                            Function(x) x.FullName,
                                            Function(x) WithLifetime.Transient(x),
                                            getInjectionMembers:=Function(x) New InjectionMember() {New Interceptor(Of InterfaceInterceptor)(), New InterceptionBehavior(Of LoggingInterceptorBehavior)()}
                                            )
        'System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes.Where(Function(x)
        '                                                                             Return Not x.IsInterface AndAlso GetType(IController).IsAssignableFrom(x)
        '                                                                         End Function).ToList.ForEach(Sub(y)
        '                                                                                                          Me.Container.RegisterType(GetType(IController), y, y.FullName, New TransientLifetimeManager, New Interceptor(Of InterfaceInterceptor)(), New InterceptionBehavior(Of LoggingInterceptorBehavior)())
        '                                                                                                      End Sub)
        'System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes.Where(Function(x)
        '                                                                             Return Not x.IsInterface AndAlso GetType(IRepository).IsAssignableFrom(x)
        '                                                                         End Function).ToList.ForEach(Sub(y)
        '                                                                                                          Me.Container.RegisterType(GetType(IRepository), y, y.FullName, New TransientLifetimeManager, New Interceptor(Of InterfaceInterceptor)(), New InterceptionBehavior(Of LoggingInterceptorBehavior)())
        '                                                                                                      End Sub)
    End Sub

End Class

Public Class InstallerExtensionDefault
    Inherits UnityContainerExtension

    ''' <summary>
    ''' This is the method that builds the components in the container.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Initialize()
        Me.Container.RegisterTypes(AllClasses.FromLoadedAssemblies().Where(Function(x) Not x.IsInterface AndAlso
                                                                               (GetType(IController).IsAssignableFrom(x) OrElse GetType(IRepository).IsAssignableFrom(x))),
                                            Function(x) WithMappings.FromAllInterfacesInSameAssembly(x),
                                            Function(x) x.FullName,
                                            Function(x) WithLifetime.Transient(x)
                                            )
        'WithMappings.FromMatchingInterace(x)
        'WithName.TypeNam(x)
        'System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes.Where(Function(x)
        '                                                                             Return Not x.IsInterface AndAlso GetType(IController).IsAssignableFrom(x)
        '                                                                         End Function).ToList.ForEach(Sub(y)
        '                                                                                                          Me.Container.RegisterType(GetType(IController), y, y.FullName)
        '                                                                                                      End Sub)
        'System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes.Where(Function(x)
        '                                                                             Return Not x.IsInterface AndAlso GetType(IRepository).IsAssignableFrom(x)
        '                                                                         End Function).ToList.ForEach(Sub(y)
        '                                                                                                          Me.Container.RegisterType(GetType(IRepository), y, y.FullName)
        '                                                                                                      End Sub)
        'AllClasses.FromLoadedAssemblies().Where(Function(x) Not x.IsInterface AndAlso GetType(IController).IsAssignableFrom(x)).ToList.ForEach(Sub(y)
        '                                                                                                                                           Me.Container.RegisterType(GetType(IController), y, y.FullName)
        '                                                                                                                                       End Sub)
        'AllClasses.FromLoadedAssemblies().Where(Function(x) Not x.IsInterface AndAlso GetType(IRepository).IsAssignableFrom(x)).ToList.ForEach(Sub(y)
        '                                                                                                                                           Me.Container.RegisterType(GetType(IRepository), y, y.FullName)
        '                                                                                                                                       End Sub)
    End Sub

End Class

Public Class InstallerFactoryInline
    Inherits UnityContainerExtension

    ''' <summary>
    ''' This is the method that builds the components in the container.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Initialize()
        System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes.Where(Function(x)
                                                                                     Return Not x.IsInterface AndAlso GetType(IController).IsAssignableFrom(x)
                                                                                 End Function).ToList.ForEach(Sub(y)
                                                                                                                  Me.Container.RegisterType(GetType(IController), y, y.FullName)
                                                                                                              End Sub)
        System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes.Where(Function(x)
                                                                                     Return Not x.IsInterface AndAlso GetType(IRepository).IsAssignableFrom(x)
                                                                                 End Function).ToList.ForEach(Sub(y)
                                                                                                                  Me.Container.RegisterType(GetType(IRepository), y, y.FullName)
                                                                                                              End Sub)
    End Sub

End Class