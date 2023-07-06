using System.Globalization;

namespace XamarinApp.Models
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado
        {
            get
            {
                return Preco.ToString("C2", CultureInfo.CurrentCulture);
            }
        }
    }
}
