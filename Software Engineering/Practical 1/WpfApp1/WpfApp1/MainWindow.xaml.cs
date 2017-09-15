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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] lines;
        int nbNext = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int age;
            if (string.IsNullOrWhiteSpace(txtName.Text) || (int.TryParse(txtAge.Text, out age))==false || string.IsNullOrWhiteSpace(txtAddress.Text) || age<0 || age>100 )
            {
                MessageBox.Show("Error : A field is empty");
            }
            else
            {
                // A string of data
                string lines = txtName.Text + "," + txtAddress.Text + "," + txtAge.Text;
                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter("H:\\Software Engineering\\Practical 1\\test.txt", true);
                file.WriteLine(lines);
                file.Close();
            }
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Clear();
            txtAge.Clear();
            txtName.Clear();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            lines = System.IO.File.ReadAllLines(@"H:\\Software Engineering\\Practical 1\\test.txt");
            string[] text = lines[0].Split(',');
            txtName.Text = text[0];
            txtAge.Text = text[1];
            txtAddress.Text = text[2];
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (lines == null || lines.Length == 0)
            {
                MessageBox.Show("Error : No array loaded");
            }
            else 
            {
                string[] text = lines[nbNext].Split(',');
                txtName.Text = text[0];
                txtAge.Text = text[1];
                txtAddress.Text = text[2];
                nbNext++;
            }
        }
    }
}
