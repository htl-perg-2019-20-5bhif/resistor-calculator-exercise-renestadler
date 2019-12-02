using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public ColorLists Lists { get; set; }

        public long Value { get; set; }
        private void GetColors(object sender, EventArgs e)
        {
            long curValue = Value;
            int count = 0;
            //Count how many zeros are in our Value
            while (curValue % 10 != 0)
            {
                count++;
                curValue /= 10;
            }
            ColorValue first = null;
            ColorValue second = null;
            ColorValue third = null;
            long secondVal = curValue % 10;
            long firstVal = curValue / 10;

            if (Lists.FirstBandList.Count < firstVal)
            {
                first = Lists.FirstBandList[(int)firstVal];
            }
            second = Lists.SecondBandList[(int)secondVal];
            if (Lists.ThirdBandList.Count < count)
            {
                third = Lists.ThirdBandList[count];
            }

            if (first != null && second != null && third != null)
            {
                
            }
            else
            {
                //Display Error
            }

        }
    }
}