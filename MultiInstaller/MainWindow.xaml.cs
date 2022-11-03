using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace MultiInstaller
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Installers")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Installers"));
            }
        }

        private void onClickButtonGraphViewer(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Installers\GraphViewerInstaller.exe"))
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Installers\GraphViewerInstaller.exe");
            }
        }
        private void onClickButtonD14Black(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Installers\D14BlackInstaller.exe"))
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Installers\D14BlackInstaller.exe");
            }
        }
        private void onClickButtonSI25Black(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Installers\SI25BlackInstaller.exe"))
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Installers\SI25BlackInstaller.exe");
            }
        }
        private void onClickButtonCRSBlack(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Installers\CRSBlackInstaller.exe"))
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Installers\CRSBlackInstaller.exe");
            }
        }
        private void onClickButtonCRSWhite(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Installers\CRSWhiteOldInstaller.exe"))
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Installers\CRSWhiteOldInstaller.exe");
            }
        }
        private void onClickButtonD14(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Installers\D14Installer.exe"))
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Installers\D14Installer.exe");
            }
        }
        private void onClickButtonCRS(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Installers\CRSInstaller.exe"))
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Installers\CRSInstaller.exe");
            }
        }
    }
}
