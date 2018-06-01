using BolsaTrabajo.COMMON.Entidades;
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
        RegistroUsuario usuario; //Variable de tipo RegistroUsuario para utilizar los datos que vienen del constructor
		public ViewTrabajo (RegistroUsuario u) //Constructor de tipo RegistroUsuario, donde obtenemos los datos que vienen de ViewRegistro, mediante la variable u
		{

			InitializeComponent ();
            usuario = u; //Asignación de los datos a la variable Usuario, para poder utilizarlos en esta vista.
            Listas(); //Método de listas de empleos.
            DatosUsuario(); //Metodo para obtener los datos del usuario

		}

        private void DatosUsuario() //Metodo que obtiene de vuelta los datos del usuario actual, para mostrarle resultados personalizados
        {
            txtNombreUsuario.Text = usuario.Nombre; //Llenamos cada txt con un valor que viene de la entidad RegistroUsuario, mediante el contructor u, mediante la propiedad .Text de cada label.
            txtEdad.Text = usuario.Edad;
            txtEscolaridad.Text = usuario.Escolaridad;
            txtUbicacion.Text = usuario.Ubicacion;
        }

        private void Listas() //Listas de los empleos en base a los valores de Edad, Escolaridad y ubicación del usuario
        {
            int Edad = Convert.ToInt32(usuario.Edad);
            string Escolaridad = usuario.Escolaridad;
            string Ubicacion = usuario.Ubicacion;

            if ((Edad >= 11 && Edad <= 15) && (Escolaridad == "Secundaria") && (Ubicacion == "Huichapan")) //Si el usuario tiene una edad entre 11 y 15 años, y además su escolaridad es secundaria, y además su ubicación es Huichapan, se muestran los datos de esta lista.
            {
                //Se pueden añadir más empleos a la lista, mediante la estructura new Datos{TituloEmpresa = "", Empleo = "", DescripcionEmpleo = ""},
                List<Datos> Empleos = new List<Datos> //Creamos una lista llamada empleos que utiliza una clase generica llamada Datos, que guarda datos del tipo TituloEmpresa, Empleo, y DescripcionEmpleo
                {
                    new Datos{TituloEmpresa = "Microsoft", Empleo = "Ing. en Sistemas Computacionales", DescripcionEmpleo = "Requerimos un Ing. para el desarrollo del IDE Visual Studio"},
                    new Datos{TituloEmpresa = "Google", Empleo = "Diseñador Gráfico", DescripcionEmpleo = "Requerimos de personal creativo para el diseño de un nuevo logotipo"},
                    new Datos{TituloEmpresa = "Oracle", Empleo = "Tester", DescripcionEmpleo = "Requerimos un tester para probar el nuevo gestor de base de datos de oracle"},
                };
                 //Llenamos la listview del XAML con los items de la lista actual llamada empleos
                lstTrabajos.ItemsSource = Empleos;
            }

            if ((Edad >= 16 && Edad <= 20) && (Escolaridad == "Bachillerato") && (Ubicacion == "Nopala"))
            {
                List<Datos> Empleos = new List<Datos>
                {
                    new Datos{TituloEmpresa = "Samsung", Empleo = "Ing. en Sistemas Computacionales", DescripcionEmpleo = "Requerimos un Ing. para el desarrollo del IDE Visual Studio"},
                    new Datos{TituloEmpresa = "Nvidia", Empleo = "Diseñador Gráfico", DescripcionEmpleo = "Requerimos de personal creativo para el diseño de un nuevo logotipo"},
                    new Datos{TituloEmpresa = "Intel", Empleo = "Tester", DescripcionEmpleo = "Requerimos un tester para probar el nuevo gestor de base de datos de oracle"},
                };

                lstTrabajos.ItemsSource = Empleos;
            }

        }

        private void LstTrabajos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Datos datos) //Si seleccionamos un elemento de la lista, nos aparece un popup, con una descripción del empleo.
            {
                DisplayAlert(datos.TituloEmpresa,datos.DescripcionEmpleo,"OK");
            }
        }

        public class Datos //Clase generica implementada para el control de los datos de la lista
        {
            public string TituloEmpresa
            {
                get;
                set;
            }

            public string Empleo
            {
                get;
                set;
            }
            public string DescripcionEmpleo
            {
                get;
                set;
            }
        }
    }
}