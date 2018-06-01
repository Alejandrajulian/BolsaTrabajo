using BolsaDeTrabajo.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BolsaDeTrabajo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            btnExito.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new Registro());
            };
		}
	}
}
