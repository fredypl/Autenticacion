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
    public partial class Recuperados : ContentPage
    {
        public ObservableCollection<_13090301> Items { get; set; }
        //public static MobileServiceClient Cliente;
        //public static IMobileServiceTable<_13090301> Tabla;
        public MobileServiceUser user;

        public Recuperados(MobileServiceUser usuario)
        {
            InitializeComponent();
            //Cliente = new MobileServiceClient(AzureConnection.URLAzure);
            //Tabla = Cliente.GetTable<_13090301>();
            user = usuario;
            LeerTabla();
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new Recuperaciones(e.SelectedItem as _13090301));

        }
        private async void LeerTabla()
        {
            if(user != null)
            {
                await DisplayAlert("USUARIO AUTENTICADO", user.UserId, "ok");
            IEnumerable<_13090301> elementos = await DataPage.Tabla.IncludeDeleted().ToEnumerableAsync();
            Items = new ObservableCollection<_13090301>(elementos);
            BindingContext = this;
            Lista.ItemsSource = Items.Where(dato => dato.Deleted == true);
            }
            else
            {
                await DisplayAlert("USERID VACIO", user.UserId, "ok");
            }
        }


       
    }
}