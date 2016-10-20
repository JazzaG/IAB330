using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class AddtoJourneyViewModel
        : MvxViewModel
    {
        private readonly IProjectDatabase journeyDatabase;

        private List<string> entryCategories = new List<string> { "Happiness", "Exercise", "Nutrition" };
        public List<string> EntryCategories
        {
            get
            {
                return entryCategories;
            }
        }

        private string categorySelection;
        public string CategorySelection
        {
            get {
                return categorySelection;
            }
            set
            {
                SetProperty(ref categorySelection, value);
            }
        }

        private int sliderValue;
        public int SliderValue
        {
            get {
                return sliderValue;
            }
            set
            {
                SetProperty(ref sliderValue, value);
            }
        }

        public ICommand CancelJourneyCommand { get; private set; }
        public ICommand AddJourneyCommand { get; private set; }
        public AddtoJourneyViewModel(IProjectDatabase journeyDatabase)
        {
            this.journeyDatabase = journeyDatabase;
            CancelJourneyCommand = new MvxCommand(() => Close(this));
            AddJourneyCommand = new MvxCommand(() => AddEntry(CategorySelection, SliderValue));
        }

        public async void AddEntry(string category, int rating)
        {
            await journeyDatabase.InsertJourneyEntry(category, rating);
            Close(this);
        }

    }
}