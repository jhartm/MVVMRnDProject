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

namespace MVVMRnDProject.Controls
{
    /// <summary>
    /// Interaction logic for PortElement.xaml
    /// </summary>
    public partial class PortElement : UserControl
    {
        public PortElement()
        {
            InitializeComponent();
        }

        public Brush ButtonBackgroundColor
        {
            get { return (Brush)GetValue(ButtonBackgroundColorProperty); }
            set { SetValue(ButtonBackgroundColorProperty, value); }
        }

        public int Diameter
        {
            get { return (int)GetValue(DiameterProperty); }
            set { SetValue(DiameterProperty, value); }
        }

        public Brush PopupBackgroundColor
        {
            get { return (Brush)GetValue(PopupBackgroundColorProperty); }
            set { SetValue(PopupBackgroundColorProperty, value); }
        }

        public String NameField
        {
            get { return (String)GetValue(NameFieldProperty); }
            set { SetValue(NameFieldProperty, value); }
        }

        public String IpField
        {
            get { return (String)GetValue(IpFieldProperty); }
            set { SetValue(IpFieldProperty, value); }
        }

        public String StatusField
        {
            get { return (String)GetValue(StatusFieldProperty); }
            set { SetValue(StatusFieldProperty, value); }
        }

        public static readonly DependencyProperty ButtonBackgroundColorProperty =
            DependencyProperty.Register("ButtonBackgroundColor", typeof(Brush), typeof(PortElement), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public static readonly DependencyProperty DiameterProperty =
            DependencyProperty.Register("Diameter", typeof(int), typeof(PortElement), new PropertyMetadata(20));

        public static readonly DependencyProperty PopupBackgroundColorProperty =
            DependencyProperty.Register("PopupBackgroundColor", typeof(Brush), typeof(PortElement), new PropertyMetadata(new SolidColorBrush(Colors.DarkGray)));

        public static readonly DependencyProperty NameFieldProperty =
            DependencyProperty.Register("NameField", typeof(String), typeof(PortElement), new PropertyMetadata("port name"));

        public static readonly DependencyProperty IpFieldProperty =
            DependencyProperty.Register("IpField", typeof(String), typeof(PortElement), new PropertyMetadata("port IP"));

        public static readonly DependencyProperty StatusFieldProperty =
            DependencyProperty.Register("StatusField", typeof(String), typeof(PortElement), new PropertyMetadata("port status"));
    }
}
