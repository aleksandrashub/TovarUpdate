using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tovar
{
    public class ProductSelect
    {
        public string nameProd { get; set; }
        public int priceProd { get; set; }
        public int quantityProd { get; set; }
        public TextBox selectQuantityProd { get; set; }
        public Button selectProd { get; set; }
    }
}
