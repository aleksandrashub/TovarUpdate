using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace Tovar
{
    public partial class MainWindow : Window
    {
        public List <Product> products = new List <Product> ();

        public const string codeAdm="0", codeUser="1";
        public MainWindow(List <Product> products)
        {
            InitializeComponent();
            this.products = products;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void BtnVhod_OnClick(object? sender, RoutedEventArgs e)
        {
           string code = CodeInput.Text;
            if (code == "0")
            {
                ProductEdit productEdit = new ProductEdit(products, code); 
                productEdit.Show();

            }
            else if (code == "1") 
            {
                ProductEdit productEdit = new ProductEdit(products, code);
                productEdit.Show();

            }
          
           this.Close();
                    
        }
    }
}