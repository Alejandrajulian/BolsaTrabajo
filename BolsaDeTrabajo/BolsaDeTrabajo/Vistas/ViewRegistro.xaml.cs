using BolsaTrabajo.BIZ;
using BolsaTrabajo.COMMON.Entidades;
using BolsaTrabajo.COMMON.Interfaces;
using BolsaTrabajo.DAL;
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
	public partial class ViewRegistro : ContentPage
	{
		public ViewRegistro ()
		{
			InitializeComponent ();
            btnBuscar.Clicked += BtnBuscar_Clicked;
		}

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            IRegistroUsuario manager = new RegistroUsuarioManager(new GenericRepository<RegistroUsuario>()); //Asignamos espacios definidos para guardarlos en la BD mediante una variable de tipo IRegistrousuario denominada manager.

            RegistroUsuario usuario = manager.Registro(txbNombre.Text, txbEdad.Text, txbUbicacion.Text, txbEmail.Text, txbTelefono.Text, picEscolaridad.SelectedItem as string, DateTime.Now); //Llenamos la entidad RegistroUsuario, con los espacios creados anteriormente, y los subimos a la BD de MongoDB

            if (usuario != null) //Si el usuario se creo, avanzamos a la siguiente pantalla, y mandamos los datos mediante un constructor, para leerlos en la vista siguiente.
            {
                Navigation.PushAsync(new ViewTrabajo(usuario));
            }
            else
            {
                DisplayAlert("Bolsa de Trabajo", "Los datos no se han podido cargar correctamente", "Aceptar"); //Si el usuario existe o se pierde la conexión, envia un error.
            }

        }
    }
}