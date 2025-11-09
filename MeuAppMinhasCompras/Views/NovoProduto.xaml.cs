using MeuAppMinhasCompras.Models; // Professor Argeli! Segue o código da atividade da Agenda 05.
using System.Threading.Tasks;

namespace MeuAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
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
            await Navigation.PopAsync();

        }   catch (Exception ex) 
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}