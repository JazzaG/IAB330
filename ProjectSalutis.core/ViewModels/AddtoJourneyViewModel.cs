using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class AddtoJourneyViewModel
        : MvxViewModel
    {

        private double sliderValue;
        public double SliderValue
        {
            get { return sliderValue; }
            set
            {
                SetProperty(ref sliderValue, value);
            }
        }

        public ICommand CancelJourneyCommand { get; private set; }
        public ICommand AddJourneyCommand { get; private set; }
        public AddtoJourneyViewModel()
        {
            AddJourneyCommand = new MvxCommand(() => ShowViewModel<JourneyViewModel>());
            CancelJourneyCommand = new MvxCommand(() => ShowViewModel<JourneyViewModel>());
        }

    }
}