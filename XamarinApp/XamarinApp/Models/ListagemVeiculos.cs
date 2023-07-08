using System.Collections.Generic;

namespace XamarinApp.Models
{
    public class ListagemVeiculos
    {
        public List<Veiculo> Veiculos { get; set; }
        public ListagemVeiculos()
        {
            Veiculos = new List<Veiculo>
            {
                new Veiculo
                {
                    Nome = "Azera V6",
                    Preco = 60000
                },
                new Veiculo
                {
                    Nome = "Fiesta 2.0",
                    Preco = 50000
                },
                new Veiculo
                {
                    Nome = "HB20 S",
                    Preco = 32000
                },
                 new Veiculo
                {
                    Nome = "Hillux",
                    Preco = 100000
                }
            };
        }
    }
}
