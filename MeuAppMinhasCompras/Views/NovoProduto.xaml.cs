using MeuAppMinhasCompras.Models;
using System.Threading.Tasks;

namespace MeuAppMinhasCompras.Views;

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
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            await App.Db.insert(p);
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

        }
        catch (Exception ex) 
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}