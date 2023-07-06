using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

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
