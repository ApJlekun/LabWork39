using System.IO;
using System.Windows;

namespace Task1
{
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

            var query1 = files.Union<FileSystemInfo>(directories)
                                           .Select(item => new { item.Name, item.CreationTime });

            resultDataGrid.ItemsSource = query1;
        }
    }
}
