using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.Abstractions;
using SoS.Models;
using SoS.ViewModels;

namespace SoS.Views
{
    public partial class CourseTypePage : ViewModelBasedContentPage<CourseTypeViewModel>
    {
        private int _currentIndex;

        public CourseTypePage()
        {
            InitializeComponent();
            ViewModel.Title = "Course Types";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Need to start somewhere...
            page.BackgroundColor = ViewModel.BackgroundColors.First();
        }

        public void Handle_PositionSelected(object sender, PositionSelectedEventArgs e)
        {
            _currentIndex = e.NewValue;
            ViewModel.SlidePosition = 0;
        }

        public void Handle_Scrolled(object sender, ScrolledEventArgs e)
        {
            int position = 0;

            if (e.Direction == ScrollDirection.Right)
                position = (int)((_currentIndex * 100) + e.NewValue);
            else if (e.Direction == ScrollDirection.Left)
                position = (int)((_currentIndex * 100) - e.NewValue);

            // Set the background color of our page to the item in the color gradient array, matching the current scrollindex.
            if (position > ViewModel.BackgroundColors.Count - 1)
                page.BackgroundColor = ViewModel.BackgroundColors.Last();
            else if (position < 0)
                page.BackgroundColor = ViewModel.BackgroundColors.First();
            else
                page.BackgroundColor = ViewModel.BackgroundColors[position];

            // Save the current scroll position
            ViewModel.SlidePosition = e.NewValue;

            if (e.Direction == ScrollDirection.Right)
            {
                // When scrolling right, we offset the current item and the next one.
                ViewModel.CarouselItems[_currentIndex].Position = -ViewModel.SlidePosition;

                if (_currentIndex < ViewModel.CarouselItems.Count - 1)
                {
                    ViewModel.CarouselItems[_currentIndex + 1].Position = 100 - ViewModel.SlidePosition;
                }
            }
            else if (e.Direction == ScrollDirection.Left)
            {
                // When scrolling left, we offset the current item and the previous one.
                ViewModel.CarouselItems[_currentIndex].Position = ViewModel.SlidePosition;

                if (_currentIndex > 0)
                {
                    ViewModel.CarouselItems[_currentIndex - 1].Position = -100 + ViewModel.SlidePosition;
                }
            }
        }
    }
}
