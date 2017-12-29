using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Paperboy.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestingPage : ContentPage
	{
		public TestingPage ()
		{
			InitializeComponent ();
		}
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                //outerStack.Orientation = StackOrientation.Horizontal;
            }
            else
            {
               // outerStack.Orientation = StackOrientation.Vertical;
            }

        }
    }
}