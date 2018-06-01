using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BolsaDeTrabajo.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewTrabajo : ContentPage
	{
		public ViewTrabajo ()
		{
			InitializeComponent ();
		}

        private void LstTrabajos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}