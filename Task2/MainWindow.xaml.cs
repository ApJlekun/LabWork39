using System.IO;
using System.Windows;

namespace Task2
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

            var query2 = files.GroupBy(f => f.Extension)
                  .Select(g => new
                  {
                      Extension = g.Key,
                      TotalSize = g.Sum(f => f.Length),
                      Count = g.Count(),
                  });

            resultDataGrid.ItemsSource = query2;
        }
    }
}