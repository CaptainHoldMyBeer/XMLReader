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
using System.IO;
using Microsoft.Win32;
using System.Xml;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string xml_path = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_File(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();

            XML_text.Clear();
            if (openFileDialog.ShowDialog() == true)
            {
                xml_path = openFileDialog.FileName;
                XML_text.Text = XmlShow(xml_path);
            }
  
        }

        public string XmlShow(string path)
        {
            StringBuilder result = new StringBuilder();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            foreach (XmlElement root in doc.DocumentElement)
            {
                result.Append(root.Name);
                result.AppendLine();

                foreach (XmlNode node in root)
                {      
                    result.Append(node.Name+": "+node.InnerText);
                    result.AppendLine();
                }
                result.AppendLine();

            }
            return result.ToString();
        }
    }
}
