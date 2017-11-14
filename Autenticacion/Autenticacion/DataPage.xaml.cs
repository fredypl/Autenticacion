using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;

namespace Autenticacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public ObservableCollection<_13090301> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090301> Tabla;
        public static MobileServiceUser usuario;
       

        public DataPage()
        {
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.URLAzure);
            Tabla = Cliente.GetTable<_13090301>();
           
        }
        //public static MobileServiceClient CurrentClient
        //{
        //    get { return Cliente; }
        //}

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new SelectPage(e.SelectedItem as _13090301));
        }


        private void Insertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertPage());
        }
        private async void LeerTabla()
        {
            IEnumerable<_13090301> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<_13090301>(elementos);
            BindingContext = this;
            Lista.ItemsSource = Items;
            
        }
        private void Recuperar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Recuperados(usuario));

        }
        private async void Login_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                if(App.Authenticator != null)
                {
                    usuario = await App.Authenticator.Authenticate();
                    
                    if(usuario!= null)
                    {
                        await DisplayAlert("USUARIO AUTENTICADO", usuario.UserId, "OK");
                        LeerTabla();
                    }
                    if (usuario == null)

                    {
                        //Boton_Insertar.IsVisible = false;
                        //Boton_Insertar.IsEnabled = false;
                        //Boton_Recuperar.IsVisible = false;
                        //Boton_Recuperar.IsEnabled = false;                   
                    }
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(usuario !=null)
            {
                LeerTabla();
            }
        }


    }

}