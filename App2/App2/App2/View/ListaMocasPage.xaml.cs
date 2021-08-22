using App2.Api;
using App2.Cell;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaMocasPage : ContentPage
    {
        private List<Moca> ListaMoca;

        public ListaMocasPage()
        {
            InitializeComponent();

            ListViewMoca.ItemTemplate = new DataTemplate(typeof(MocaCell));
            ListViewMoca.RowHeight = 120;
            ListViewMoca.ItemSelected += ListViewMoca_ItemSelected;
        }

        public async Task CarregarMocas()
        {
            ListaMoca = await ApiService.ObterMocas();
            ListViewMoca.ItemsSource = ListaMoca.ToList().OrderBy(x => x.Guerra);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await CarregarMocas();
        }

        private void ListViewMoca_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PesquisaNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoPesquisa = PesquisaNome.Text;
            ListViewMoca.ItemsSource = ListaMoca.Where(x => x.Guerra.ToLower().Contains(textoPesquisa.ToLower()));
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            CarregarMocas();
        }
    }
}