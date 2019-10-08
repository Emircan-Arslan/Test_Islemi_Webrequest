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
using System.Net;
using System.Web.Script.Serialization;

namespace TestIslemi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //siteye bağlanmak için 
            WebRequest request = WebRequest.Create("https://rest.novadan.com.tr/rest/view/1");

            //Uygulamanın sistem kimlik bilgilerini alır.
            request.Credentials = CredentialCache.DefaultCredentials;

            //post methodu olduğundan.
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    novakey = "dc9UruUIprv6QAg3BjYSubvFr",
                    novasecret = "R6SkIdBVbe3mFWyV9AN7JgB5n",

                });

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();

            string result = null;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            MessageBox.Show("Test İşlemi Sonuç \n\n" + result);


        }
    }
}
