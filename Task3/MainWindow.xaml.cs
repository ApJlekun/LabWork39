using System.IO;
using System.Windows;

namespace Task3
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
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            DirectoryInfo[] directories = directory.GetDirectories("*", SearchOption.AllDirectories);

            var query3 = files.GroupBy(f => new { f.CreationTime.Year, f.CreationTime.Month })
                              .Select(g => new
                              {
                                  g.Key.Year,
                                  g.Key.Month,
                                  Count = g.Count()
                              });

            resultDataGrid.ItemsSource = query3;
        }
    }
}