using System.Globalization;

namespace XamarinApp.Models
{
    public class Veiculo
    {
        public const decimal FREIO_ABS = 800.00M;
        public const decimal AR_CONDICIONADO = 1000.00M;
        public const decimal DISPOSITIVO_MULTIMIDIA = 550.00M;
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
