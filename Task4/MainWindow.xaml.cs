using System.IO;
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

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData(@"F:\Images");
        }

        private void GetData(string path)
        {
            // Получить информацию о файлах и папках
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            DirectoryInfo[] directories = directory.GetDirectories("*", SearchOption.AllDirectories);

            var query4 = from file in files
                         join dir in directories on file.DirectoryName equals dir.FullName
                         where dir.CreationTime.Date == DateTime.Today
                         select new { FileName = file.Name, FilePath = file.FullName, DirectoryName = dir.FullName };
            /*files.Join(directories, f => f.DirectoryName, d => d.FullName,
                                 (f, d) => new { FileName = f.Name, FilePath = f.DirectoryName })
                           .Where(fd => fd.Date == DateTime.Today);*/
            resultDataGrid.ItemsSource = query4;
        }
    }
}