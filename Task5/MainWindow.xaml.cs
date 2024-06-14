using System.IO;
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

namespace Task5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData(@"C:\Temp");
        }

        private void GetData(string path)
        {
            // Получить информацию о файлах и папках
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            DirectoryInfo[] directories = directory.GetDirectories("*", SearchOption.AllDirectories);

            var query5 = directories.GroupJoin(files, d => d.FullName, f => f.DirectoryName,
                                (d, f) => new { DirectoryName = d.Name, FileCount = f.Count() });

            resultDataGrid.ItemsSource = query5;
        }
    }
}