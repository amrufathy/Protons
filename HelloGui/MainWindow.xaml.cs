using System.Windows;

namespace HelloGui
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

        private void HelloButton_MouseClickHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello!","Greetings");
        }
    }
}
