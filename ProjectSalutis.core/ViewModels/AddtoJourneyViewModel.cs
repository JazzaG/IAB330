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

        public ICommand ButtonCommand { get; private set; }
        public AddtoJourneyViewModel()
        {
            ButtonCommand = new MvxCommand(() =>
            {
                //do nothing
            });
        }

    }
}