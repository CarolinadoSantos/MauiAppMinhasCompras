using MauiAppMinhasCompras.Models;
using System;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async Task ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Produto p = new Produto 
			{
				Descricao = txt_descricao.Text,
				Quantidade = Converter.ToDouble (txt_quantidade.Text),
				Preco = Converter.ToDouble(txt_preco.Text),
            };

			await App.Db.Insert(p);
			await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

		}catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {

    }
}