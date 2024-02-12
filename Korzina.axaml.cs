using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tovar;

public partial class Korzina : Window
{
    public List<Button> delBtns = new List<Button>();
    public List<Product> allSelected = new List<Product>();
    public string codeUs;
    public ListBox quantitylistBox = new ListBox();
    public List<Product> products = new List<Product>();
    public List<TextBox> selectedQuantity = new List<TextBox>();
    public List<ProductSelect> productSelects = new List<ProductSelect>();
    public Korzina()
    {
        InitializeComponent();
    }
    public Korzina(List<Product> selected, List<Product> prods, string code)
    {
        codeUs = code;
       List<int> repeats = new List<int>();
       
        products = prods;
       

        allSelected.AddRange(selected.Cast<Product>().ToList());
        foreach (Product prod in allSelected)
        {
            productSelects.Add(
            new ProductSelect()
            {
                nameProd = prod.nameProd,
                priceProd = prod.priceProd,
                quantityProd = prod.quantityProd,
                selectQuantityProd = new TextBox(),
                selectProd = new Button()
            });
        }
        foreach (ProductSelect prodSel in productSelects)
        {
            selectedQuantity.Add(prodSel.selectQuantityProd);
            prodSel.selectProd.Click += DelBtn_Click;
            prodSel.selectProd.Width = 90;
            prodSel.selectProd.Height = 30;
            prodSel.selectProd.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center;
            prodSel.selectProd.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
            prodSel.selectProd.Content = "Удалить";
            prodSel.selectProd.HorizontalContentAlignment = Avalonia.Layout.HorizontalAlignment.Center;
            prodSel.selectProd.VerticalContentAlignment = Avalonia.Layout.VerticalAlignment.Center;
            delBtns.Add(prodSel.selectProd);

        }
        InitializeComponent();
        ProdListInKorz.Items = productSelects.ToList();
    }

    public void DelBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var button = sender as Button;
        int ind = delBtns.IndexOf(button);
        allSelected.RemoveAt(ind);
        productSelects.RemoveAt(ind);
        selectedQuantity.RemoveAt(ind);
        ProdListInKorz.Items = productSelects.ToList();
        delBtns.RemoveAt(ind);
        
    }

    public void ReturnProdEdit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ProductEdit productEdit = new ProductEdit(products, codeUs, allSelected);
        productEdit.Show();
        this.Close();
    }

    public void PodschetOrderBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool checkDataCorrect = true;
        int allprice = 0;
        for (int i = 0; i < ProdListInKorz.ItemCount; i++)
        {
            int selQua = Convert.ToInt32(selectedQuantity[i].Text);
            if (selQua > 0 && selQua <= allSelected[i].quantityProd)
            {
                allprice += selQua * allSelected[i].priceProd;
            }
            else
            {
                checkDataCorrect = false;
            }

        }
        if (checkDataCorrect == false)
        {
            podschetstoimosti.Text = "Ошибка. Введенное количество превышает имеющееся в магазине.";
        }
        else
        {
            podschetstoimosti.Text =  "Общая стоимость составляет: " + allprice.ToString() + " руб.";
        }
    }


    public void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainwindow = new MainWindow(products);
        mainwindow.Show();
        this.Close();
    }

   

}