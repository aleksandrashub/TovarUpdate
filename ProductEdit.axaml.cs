using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tovar;

public partial class ProductEdit : Window
{

    public string codeUs;
    public TextBlock textblock = new TextBlock();
    public TextBox textbox = new TextBox();
    public TextBox textbox2 = new TextBox();
    public TextBox textbox3 = new TextBox();
    public List<Product> productsCopied = new List<Product>();
    public List<Product> selectedPr = new List<Product>();
    public Button btnInsertOk = new Button();
    public ListBox list = new ListBox();

    public ProductEdit()
    {
        InitializeComponent();
    }
    public ProductEdit(List<Product> products, string code, List<Product> selected)
    {
        InitializeComponent();
        ProdList.SelectionMode = SelectionMode.Multiple;
        ProdList.Items = products.ToList();
        codeUs = code;
        if (code == "1")
        {
            AddElementBtn.IsVisible = false;
            GoToKorzinaBtn.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;

        }
        this.textblock.Text = "Введите наименование и цену товара";
        this.btnInsertOk.Content = "Ok";
        this.textbox.Text = "";
        this.textbox2.Text = "";
        this.textbox3.Text = "";
        this.textbox.Watermark = "Наименование";
        this.textbox2.Watermark = "Цена";
        this.textbox3.Watermark = "Количество";
        editing.Children.Add(this.textblock);
        editing.Children.Add(this.textbox);
        editing.Children.Add(this.textbox2);
        editing.Children.Add(this.textbox3);
        editing.Children.Add(this.btnInsertOk);
        btnInsertOk.Click += new EventHandler<RoutedEventArgs>(this.BtnInsertOk_OnClick);
        textblock.IsVisible = false;
        textbox.IsVisible = false;
        textbox2.IsVisible = false;
        textbox3.IsVisible = false;
        btnInsertOk.IsVisible = false;
        productsCopied = products;
        selectedPr = selected;
    }
    public ProductEdit(List<Product> products, string code)
    {
        InitializeComponent();
        ProdList.SelectionMode = SelectionMode.Multiple;
        ProdList.Items = products.ToList();
        codeUs = code;
        if (code == "1")
        {
            AddElementBtn.IsVisible = false;
            GoToKorzinaBtn.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;

        }

        this.textblock.Text = "Введите наименование, цену и количество товара в магазине";
        this.btnInsertOk.Content = "Ok";
        editing.Children.Add(this.textblock);
        editing.Children.Add(this.textbox);
        editing.Children.Add(this.textbox2);
        editing.Children.Add(this.textbox3);
        this.textbox.Watermark = "Наименование";
        this.textbox2.Watermark = "Цена";
        this.textbox3.Watermark = "Количество";
        editing.Children.Add(this.btnInsertOk);
        btnInsertOk.Click += new EventHandler<RoutedEventArgs>(this.BtnInsertOk_OnClick);
        textblock.IsVisible = false;
        textbox.IsVisible = false;
        textbox2.IsVisible = false;
        textbox3.IsVisible = false;
        btnInsertOk.IsVisible = false;
        productsCopied = products;
    }

    public void BtnInsert_OnClick(object? sender, RoutedEventArgs e)
    {
        textblock.IsVisible = true;
        textbox.IsVisible = true;
        textbox2.IsVisible = true;
        textbox3.IsVisible = true;
        btnInsertOk.IsVisible = true;
    }

    public void GetList(List<Product> products)
    {
        products.Add(new Product()
        {
            nameProd = textbox.Text,
            priceProd = Convert.ToInt32(textbox2.Text),
            quantityProd = Convert.ToInt32(textbox3.Text)
        });
        ProdList.Items = products.ToList();
    }


    public void BtnInsertOk_OnClick(object? sender, RoutedEventArgs e)
    {

        GetList(productsCopied);
        this.textbox.Text = "";
        this.textbox2.Text = "";
        this.textbox3.Text = "";
        textblock.IsVisible = false;
        textbox.IsVisible = false;
        textbox2.IsVisible = false;
        textbox3.IsVisible = false;
        btnInsertOk.IsVisible = false;
    }


    public void BtnKorzina_OnClick(object? sender, RoutedEventArgs e)
    {
        List<int> repeat = new List<int>();

        List<Product> prodListSelected = new List<Product>();
        prodListSelected = ProdList.SelectedItems.Cast<Product>().ToList();
        selectedPr.AddRange(prodListSelected);
        Korzina korzina = new Korzina(selectedPr, productsCopied, codeUs);
        korzina.Show();
        this.Close();
    
    }
    public void BtnVyhod_OnClick(object? sender, RoutedEventArgs e)
    {
        
        if (productsCopied.Count > 0)
        {
            MainWindow mainWindow = new MainWindow(productsCopied);
            mainWindow.Show();
        }
        else
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
       
        this.Close();
       
    }

}
