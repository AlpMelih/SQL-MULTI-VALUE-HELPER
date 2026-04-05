using System.ComponentModel;
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

namespace SQL_MULTI_VALUE_HELPER
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
            string command = txtCommand.Text;
            string values = txtValues.Text;

            var splittedValues= values.Split(new[] { '\n', '\r', ' ', ',', ';' },StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToList();
            
            
            if (string.IsNullOrEmpty(command) || splittedValues.Count == 0)
            {
                MessageBox.Show("KOMUT VEYA DEĞERERLERİ BOŞ BIRAKMAYINIZ");
                return; 

            }

            string JoinedValue = string.Join(",", splittedValues);

            string FinalVaue = $"{command} ({JoinedValue})";

            Clipboard.SetText(FinalVaue);

            MessageBox.Show("Kopyalandı:\n" + FinalVaue);

        }
    }
}