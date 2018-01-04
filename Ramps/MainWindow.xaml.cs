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
            try
            {
                var p0 = new Point3D(p0XValue.Value, p0YValue.Value, p0ZValue.Value);
                var p1 = new Point3D(p1XValue.Value, p1YValue.Value, p1ZValue.Value);
                var p2 = new Point3D(p2XValue.Value, p2YValue.Value, p2ZValue.Value);
                var p3 = new Point3D(p3XValue.Value, p3YValue.Value, p3ZValue.Value);
                _vm.updateBezier(p0, p1, p2, p3, (int)Segments.Value, Height.Value);
            }
            catch (Exception)
            {
                return;
            }
            
        }
    }
}
