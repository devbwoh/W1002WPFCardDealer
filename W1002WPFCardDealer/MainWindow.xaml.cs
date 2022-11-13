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

namespace W1002WPFCardDealer
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

        private void OnDeal(object sender, RoutedEventArgs e)
        {
            Random r = new Random();

            int n = r.Next(52);

            BitmapImage b = new BitmapImage(new Uri($"images/{GetCardName(n)}",
                    UriKind.RelativeOrAbsolute));
            Card1.Source = b;
        }

        private string GetCardName(int c)
        {
            string shape = "";
            switch (c / 13)
            {
                case 0: shape = "spades"; break;
                case 1: shape = "diamonds"; break;
                case 2: shape = "hearts"; break;
                case 3: shape = "clubs"; break;
            }

            string number = "";
            switch (c % 13)
            {
                case 0: number = "ace"; break;
                case int n when (n > 0 && n < 10):
                    number = (c % 13 + 1).ToString(); break;
                case 10: number = "jack"; shape += "2"; break;
                case 11: number = "queen"; shape += "2"; break;
                case 12: number = "king"; shape += "2"; break;
            }
            return string.Format("{0}_of_{1}.png", number, shape);
        }
    }
}
