using Paperboy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paperboy
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        public void OnClickListView(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewPage1());
        }

    }
}
