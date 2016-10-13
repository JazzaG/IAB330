using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    class JourneyViewModel
        : MvxViewModel
    {
        public ICommand AddJourneyCommand { get; private set; }
        public JourneyViewModel()
        {
            AddJourneyCommand = new MvxCommand(() => ShowViewModel<AddtoJourneyViewModel>());
        }
    }
}
