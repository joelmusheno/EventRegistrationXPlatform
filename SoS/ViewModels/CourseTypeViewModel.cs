using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SoS.Models;
using Xamarin.Forms;

namespace SoS.ViewModels
{
    public class CourseTypeViewModel : BaseViewModel
    {
        public List<CarouselItem> CarouselItems { get; private set; }

        private List<Color> _backgroundColors;
        public List<Color> BackgroundColors
        {
            get => _backgroundColors;
            private set => _ = _backgroundColors;
        }

        private double _slidePosition;
        public double SlidePosition
        {
            get => _slidePosition;
            set { SetProperty(ref _slidePosition, value); }
        }
        

        public CourseTypeViewModel()
        {
            _backgroundColors = new List<Color>();
            CarouselItems = new List<CarouselItem>()
            {
                new CarouselItem{ Position=0, Type="JUICY AND ORANGE", ImageSrc="oranges.png", Name = "ORANGE AWESOMENESS", Price = 120, Title = "ORANGE AWESOMENESS", BackgroundColor= Color.FromHex("#9866d5"), StartColor=Color.FromHex("#f3463f"),  EndColor=Color.FromHex("#fece49")},
                new CarouselItem{ Position=0, Type="NOT A TYPICAL FRUIT", ImageSrc="tomato.png", Name = "TERRIBLE TOMATO", Price = 129, Title = "TERRIBLE TOMATO", BackgroundColor= Color.FromHex("#fab62a"), StartColor=Color.FromHex("#42a7ff"),  EndColor=Color.FromHex("#fab62a")},
                new CarouselItem{ Position=0, Type="SWEET AND GREEN", ImageSrc="pear.png", Name = "PEAR PARTY", Price = 140, Title = "PEAR PARTY", BackgroundColor= Color.FromHex("#425cfc"), StartColor=Color.FromHex("#33ccf3"),  EndColor=Color.FromHex("#ccee44")}
            };

            // Create out a list of background colors based on 
            // our items colors so we can do a gradient on scroll.
            for (int i = 0; i < CarouselItems.Count; i++)
            {
                var current = CarouselItems[i];
                var next = CarouselItems.Count > i + 1 ? CarouselItems[i + 1] : null;

                if (next != null)
                    CreateColors.SetGradients(current.BackgroundColor, next.BackgroundColor, 100).ToList().ForEach(x => _backgroundColors.Add(x));
                else
                    _backgroundColors.Add(current.BackgroundColor);
            }
        }
    }
}
