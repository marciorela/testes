using App2.Api;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;

namespace App2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        List<Moca> listMocas;

        public LoginPage()
        {
            InitializeComponent();
            listMocas = new List<Moca>();
        }

        public async void Logar()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var mocas = await ApiService.ObterMocas();

                //var moca = mocas.Where(x => x.Codigo == txtEmal.Text && txtSenha.Text == "1").ToList();
                var moca = mocas.Where(x => x.Codigo == mocas.First().Codigo).ToList();
                if (moca.Count > 0)
                {
                    await Navigation.PushAsync(new ListaMocasPage());
                }
                else
                {
                    await DisplayAlert("titulo", "Login e senha inválidos.", "Cancel");
                }
            }
            else
            {
                await DisplayAlert("titulo", "Sem conexão com a internet.", "Cancel");
            }
        }


        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Logar();
        }
    }
}