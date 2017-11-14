using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks; //ejecuta tareas sincronas y asincronas
using Windows.UI.Popups; //ventanas emergentes(Display Alert)
using Autenticacion;

namespace Autenticacion.UWP
{
    public sealed partial class MainPage : ISQLAzure
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            try
            { 
                usuario = await Autenticacion.DataPage.Cliente.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount, "tesh.azurewebsites.net");
                if (usuario != null)
                {
                    await new MessageDialog(usuario.UserId, "Bienvenido").ShowAsync();
                    //await new MessageDialog(usuario.MobileServiceAuthenticationToken, "Token").ShowAsync();
                }
            }

            catch (Exception ex)
            {
                await new MessageDialog(ex.Message, "Error message").ShowAsync();
            }
            return usuario;
        }
            public MainPage()
        {
            this.InitializeComponent();
            Autenticacion.App.Init((ISQLAzure)this); //inicializar la aplicacion
            LoadApplication(new Autenticacion.App());
        }
     
    }
}
