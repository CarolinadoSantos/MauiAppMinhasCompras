using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
        public ListaProduto()
    {
        InitializeComponent();

        lst_produtos.ItemsSource = lista;
    }
        protected override async void OnAppearing()
    {
        lista.Clear();

        List<Produto> tmp = await App.Db.GetAll();

        tmp.ForEach(i => lista.Add(i));
    }
       private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.NovoProduto());
    }
        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total);

        string msg = $"O total é {soma:c}";

        DisplayAlert("Total de Produtos", msg, "OK");
    }
    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;

        lista.Clear();

        List<Produto> tmp = await App.Db.Search(q);

        tmp.ForEach(i => lista.Add(i));
    }
    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}
