using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autenticacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPage : ContentPage
    {
        public ObservableCollection<_13090301> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090301> Tabla;
        public static MobileServiceUser usuario;
        public SelectPage(object selectedItem)
        {
            InitializeComponent();
           
            //if (DataPage.usuario == null)
            //{              
            //    Entry_Matricula.IsEnabled = false;
                
            //}

            var dato = selectedItem as _13090301;
            BindingContext = dato;
            string[] semestre = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            Picker_Semestre.ItemsSource = semestre;
            Picker_Semestre.SelectedItem = dato.Semestre;
            string[] carrera = { "Ing.Sistemas Computacionales", "Ing.Civil", "Ing.Industrial", "Ing.Mecatronica", "Lic.Administracion", "Lic.Biologia", "Lic.Gastronomia", };
            Picker_Carrera.ItemsSource = carrera;
            Picker_Carrera.SelectedItem = dato.Carrera;
        }

        private async void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090301
            {
                Id = Entry_Id.Text,
                Nombre = Entry_Nombre.Text,
                Apellido = Entry_Apellido.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Convert.ToString(Picker_Carrera.SelectedItem),
                Semestre = Convert.ToString(Picker_Semestre.SelectedItem),
                Matricula = Entry_Matricula.Text,
                Correo = Entry_Correo.Text,
                GitHub = Entry_GitHub.Text

            };
            await DataPage.Tabla.UpdateAsync(datos);

            await Navigation.PopAsync();
        }
        private async void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            {

                var datos = new _13090301
                {
                    Id = Entry_Id.Text,
                    Nombre = Entry_Nombre.Text,
                    Apellido = Entry_Apellido.Text,
                    Direccion = Entry_Direccion.Text,
                    Telefono = Entry_Telefono.Text,
                    Carrera = Convert.ToString(Picker_Carrera.SelectedItem),
                    Semestre = Convert.ToString(Picker_Semestre.SelectedItem),
                    Matricula = Entry_Matricula.Text,
                    Correo = Entry_Correo.Text,
                    GitHub = Entry_GitHub.Text
                };
                await DataPage.Tabla.DeleteAsync(datos);

                await Navigation.PopAsync();


            }
        }
    }
}