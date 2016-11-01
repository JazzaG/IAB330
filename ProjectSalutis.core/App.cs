using MvvmCross.Platform.IoC;

namespace ProjectSalutis.core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.NavigationViewModel>();
        }
    }
}
