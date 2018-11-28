**Main Pattern Used**
<br>
![Class](https://raw.githubusercontent.com/StuckInTheCode/I_have_a_plan/master/documents/uml_diagrams/ClassDiagram/ClassDiagramPatterns.png)
</br>
1.MVVM - The MVVM pattern is one of the most commonly used patterns. MVVM means the separation of program code into modules view, viewmodel, model.
<br>
![MVVM](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/mvvm-images/mvvm.png)
</br>
1.1.View<br>
The view is responsible for defining the structure, layout, and appearance of what the user sees on screen. Ideally, each view is defined in XAML, with a limited code-behind that does not contain business logic.</br>
1.2.ViewModel<br>
View is associated with the ViewModel using a binding that is supported by this framework. The view model implements properties and commands to which the view can data bind to, and notifies the view of any state changes through change notification events. The properties and commands that the view model provides define the functionality to be offered by the UI, but the view determines how that functionality is to be displayed.</br>
1.3 Model <br>
Model classes are non-visual classes that encapsulate the app's data. The model interacts with the viewmodel directly.
All pages of the application are implemented using this pattern. Views are represented by -pages classes. ViewModels are represeted by -viewModels classes.</br><br>
2.Dependency Service - To use the same services on different platforms, all services interfaces are implemented in the platform specific solutions and connected to the DependencyService. This functionality enables Xamarin.Forms apps to do anything that a native app can do. 
The structure of the application is explained by the following diagram in the microsoft documentation:
<br>
[!DependencyService] (https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/introduction-images/overview-diagram.png)
<br>
3.Dependency Injection - The main class of the application - App - acts as Dependency injector. Dependency injection is a specialized version of the Inversion of Control (IoC) pattern, where the concern being inverted is the process of obtaining the required dependency. With dependency injection, another class is responsible for injecting dependencies into an object at runtime. Commonly and in my implementation, dependency injector create a new instance of a class and pass the dependency through the constructor to add it to the instance. For example, Navigation of the page and project manager instance are injected to the mainappviewmodel by the app class. <br>
4.Composite - Xamarin supports page creation with xaml markup language, that based on the composite pattern. XAML allows developers to define user interfaces in Xamarin.Forms applications using markup rather than code. XAML is often more visually coherent and more succinct than equivalent code. XAML is particularly well suited for use with the popular Model-View-ViewModel (MVVM) application architecture: XAML defines the View that is linked to ViewModel code through XAML-based data bindings.<br>
5.Command - Xamarin also supports command binding, that means that function of the view element will be execute directly from the viewModel. This pattern is a part of the MVVM. <br>
6.Observer - ObservableCollections allow submission of view elements directly to viewModel resources. Then View will be able to observe all changes occurring with the connected collection. <br>
