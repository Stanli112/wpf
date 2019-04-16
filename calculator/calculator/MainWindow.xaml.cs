using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculator
{
    public partial class MainWindow : Window
    {
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        double result= 0;
        string inp_sign = "";

        public MainWindow()
        {
            InitializeComponent();
        } 
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtMain.Text == "0")
                txtMain.Text = "";
            if (txtMain.Text.Length < 10)
            {
                txtMain.Text += ((TextBlock)((Button)sender).Content).Text;
            }
        }  
        private void ButtonOther_Click(object sender, RoutedEventArgs e)
        {
            inp_sign = ((Button)sender).Name.Substring(3);
            txtHeaderMainSign.Text = ((TextBlock)((Button)sender).Content).Text;
            result = Convert.ToDouble(txtMain.Text);            
            txtHeaderMain.Text = txtMain.Text;
            txtMain.Text = "";
        }
        private void ButtonExtra_Click(object sender, RoutedEventArgs e)
        {
            txtMain.Text = GetExtra(((Button)sender).Name.Substring(3), txtMain.Text);
            if (txtMain.Text.Length < 10)
                txtMain.FontSize = 70;
            if (txtMain.Text.Length > 10)
                txtMain.FontSize = 60;
            if (txtMain.Text.Length > 14)
                txtMain.FontSize = 50;
        }

        private string GetExtra(string btnName, string inp_n)
        {
            switch(btnName)
            {
                case "Change":
                    if (Convert.ToDouble(inp_n) < 0)
                        return inp_n.Substring(1);
                    else
                        return "-" + inp_n;
                case "Dot":
                    if (inp_n.IndexOf(",") < 0)
                        return inp_n + ",";
                    else
                        return inp_n;
                case "X":
                    return Convert.ToString(1/Convert.ToDouble(inp_n));
                case "XSquared":
                    return Convert.ToString(Convert.ToDouble(inp_n) * Convert.ToDouble(inp_n));
                case "Back":
                    if (inp_n.Length == 1)
                        return "0";
                    return inp_n.Substring(0, inp_n.Length-1);
                case "DeleteAll":
                    txtHeaderMain.Text = "";
                    txtHeaderMainSign.Text = "";
                    result = 0;
                    return "0";
                case "Delete":
                    return "0";
                case "Equals":
                    if(txtMain.Text.Length != 0)
                    {
                        txtHeaderMain.Text = "";
                        txtHeaderMainSign.Text = "";
                        return Convert.ToString(GetCalculation(inp_sign, result, Convert.ToDouble(txtMain.Text)));
                    }
                    return "0";
                case "Sqrt":
                    return Math.Sqrt(Convert.ToDouble(inp_n)).ToString();
            }
            return null;
        }
        private double GetCalculation(string btnName, double num1, double num2)
        {
            switch (btnName)
            {
                case "Mult":
                    return num1 * num2;
                case "Minus":
                    return num1 - num2;
                case "Sum":
                    return num1 + num2;
                case "DivisionWithoutRemainder":
                    return (int)num1 * num2;
                case "Division":
                    return num1 / num2;
            }
            return 0;
        }

    }
}
