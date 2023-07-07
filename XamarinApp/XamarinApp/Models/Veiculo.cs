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
        public bool TemFreioABS { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemDispositivoMultimidia { get; set; }
        public string ValorTotal
        {
            get
            {
                decimal valorTotal = Preco;

                valorTotal += TemFreioABS ? FREIO_ABS : 0;

                valorTotal += TemArCondicionado ? AR_CONDICIONADO : 0;

                valorTotal += TemDispositivoMultimidia ? DISPOSITIVO_MULTIMIDIA : 0;

                return $"Total: {valorTotal.ToString("C2", CultureInfo.CurrentCulture)}";
            }
        }
    }
}
