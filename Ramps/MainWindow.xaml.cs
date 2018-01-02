using Ramps.ViewModels;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ramps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            DataContext = _vm;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var p0 = new Point3D(Double.Parse(p0X.Text), Double.Parse(p0Y.Text), Double.Parse(p0Z.Text));
            var p1 = new Point3D(Double.Parse(p1X.Text), Double.Parse(p1Y.Text), Double.Parse(p1Z.Text));
            var p2 = new Point3D(Double.Parse(p2X.Text), Double.Parse(p2Y.Text), Double.Parse(p2Z.Text));
            var p3 = new Point3D(Double.Parse(p3X.Text), Double.Parse(p3Y.Text), Double.Parse(p3Z.Text));
            _vm.updateBezier(p0, p1, p2, p3, Int32.Parse(Segments.Text));
        }
    }
}
