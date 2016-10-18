using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.droid.Database;
using ProjectSalutis.core.Database;

namespace ProjectSalutis.droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new ProjectSalutis.core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SqliteDroid>();
            
            Mvx.LazyConstructAndRegisterSingleton<IProjectDatabase, ProjectDatabase>();
            base.InitializeFirstChance();
        }
    }
}
