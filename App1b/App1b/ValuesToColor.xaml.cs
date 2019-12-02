using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1b
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ValuesToColor : ContentPage
    {
        public ValuesToColor()
        {
            Lists = new ColorLists();
            InitializeComponent();
            BindingContext = this;
        }

        public ColorLists Lists { get; set; }

        private long ValueValue = 0;
        public long Value
        {
            get => ValueValue;
            set
            {
                ValueValue = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        private ColorValue FirstColorValue;

        public ColorValue FirstColor
        {
            get => FirstColorValue;
            set
            {
                this.FirstColorValue = value;
                OnPropertyChanged(nameof(FirstColor));
            }
        }

        private ColorValue SecondColorValue;

        public ColorValue SecondColor
        {
            get => SecondColorValue;
            set
            {
                this.SecondColorValue = value;
                OnPropertyChanged(nameof(SecondColor));
            }
        }

        private ColorValue ThirdColorValue;

        public ColorValue ThirdColor
        {
            get => ThirdColorValue;
            set
            {
                this.ThirdColorValue = value;
                OnPropertyChanged(nameof(ThirdColor));
            }
        }

        public Color FourthColor { get; set; } = Color.Black;

        private string DisplayValueValue = "No action executed until now!\n";

        public string DisplayValue
        {
            get => DisplayValueValue;
            set
            {
                this.DisplayValueValue = value;
                OnPropertyChanged(nameof(DisplayValue));
            }
        }


        private void GetColors(object sender, EventArgs e)
        {
            long curValue = Value;
            int count = 0;
            //Count how many zeros are in our Value
            while (curValue % 10 == 0)
            {
                count++;
                curValue /= 10;
            }

            long secondVal = curValue % 10;
            long firstVal = curValue / 10;

            if (curValue < 10)
            {
                firstVal = secondVal;
                secondVal = 0;
                count--;
            }

            if (Lists.FirstBandList.Count > firstVal - 1 && firstVal >= 0)
            {
                FirstColor = Lists.FirstBandList[(int)firstVal - 1];
            }
            else
            {
                FirstColor = null;
            }

            if (Lists.SecondBandList.Count > secondVal && secondVal >= 0)
            {
                SecondColor = Lists.SecondBandList[(int)secondVal];
            }
            else
            {
                SecondColor = null;
            }

            if (Lists.ThirdBandList.Count > count && count >= 0)
            {
                ThirdColor = Lists.ThirdBandList[count];
            }
            else
            {
                ThirdColor = null;
            }

            if (FirstColor == null || SecondColor == null || ThirdColor == null)
            {
                DisplayValue = "Unable to find correct colors!\n";
            }
            else
            {
                DisplayValue = "Color 1: " + FirstColor.Color + "\nColor 2: " + SecondColor.Color + "\nColor 3: " + ThirdColor.Color + "\n";
            }

        }
    }
}