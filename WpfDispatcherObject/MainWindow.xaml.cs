using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfDispatcherObject {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e) {
            var d = new DrivedObject();
            d.DoSomething();
        }

        private async void NGButton_Click(object sender, RoutedEventArgs e) {
            //UIスレッド以外からの呼び出しでエラーが出る
            var d = new DrivedObject();
            try {
                await Task.Run(
                    () => d.DoSomething()
                    );
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);
            }
        }

        private async void DispacherButton_Click(object sender, RoutedEventArgs e) {
            //UIスレッド以外からの呼び出しだがDispacer経由だからエラーが出ない
            var d = new DrivedObject();
            await Task.Run(
                async () => {
                    if (!d.CheckAccess()) {
                        await d.Dispatcher.InvokeAsync(() => d.DoSomething());
                    }
                });
        }
    }
}
