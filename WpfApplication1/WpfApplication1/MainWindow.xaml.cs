using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;


namespace WpfApplication1
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("send email successfully!");
            this.Close();
        }

        public static bool IsEmail(string inputData)
        {
            //判断邮件的正则
            Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string path = string.Empty;
            System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "choose picture file";
            fileDialog.Filter = "所有图像文件|*.bmp;*.pcx;*.png;*.jpg;*.gif";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox3.Text = fileDialog.FileName;
                path = fileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage();

                bitmapImage.BeginInit();  
                bitmapImage.UriSource = new Uri(@path);  
                bitmapImage.EndInit();
                image1.Source = bitmapImage;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.button1.IsEnabled = false;
        }

        private void checkValue()
        {
            if (this.textBox1.Text.Trim() != "" && this.textBox2.Text.Trim() != "" && this.textBox3.Text.Trim() != "")
            {
                this.button1.IsEnabled = true;
            }
            else
            {
                this.button1.IsEnabled = false;
            }

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkValue();
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkValue();
        }


        private void textBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("email address is not null!");
            }
            if (!IsEmail(this.textBox1.Text.Trim()))
            {
                MessageBox.Show("email address is not correct!");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string path = string.Empty;
            System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "choose text file";
            fileDialog.Filter = "文本文件|*.txt";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fileDialog.FileName;
                this.textBox2.Text = ReadTxtContent(path);
            }
        }

        public static string ReadTxtContent(string Path)
        {
            string Content = string.Empty;
            if (File.Exists(Path))
            {
                StreamReader sr = new StreamReader(Path, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    Content = Content + "\r\n" + line;
                }
                sr.Close();
            }
            return Content;
        }

        
    }
}
