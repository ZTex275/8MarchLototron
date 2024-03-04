using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MultiInstaller
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int itterator = 0;
        List<string> randData;
        string soundsDir = Path.Combine(Directory.GetCurrentDirectory(), "Sounds");

        public MainWindow()
        {
            InitializeComponent();

            List<string> data = 
                ["Красндор", "Красндор", "Красндор", "Красндор", "Красндор", "Красндор", "Красндор", "Красндор",
                 "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин",
                 "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", // Тут 7
                 "Синевран", "Синевран", "Синевран", "Синевран", "Синевран", "Синевран", "Синевран", "Синевран"];

            randData = Shuffle(data);
        }

        private async void onClickButtonStart(object sender, RoutedEventArgs e)
        {
            // Очищаем поле
            textblock1.Background = new SolidColorBrush(Colors.Transparent);
            textblock1.Text = null;
            textblock2.Text = null;

            if (itterator >= randData.Count)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "Sounds/krasndor.wav";
                player.Play();

                //.mp3
                await Task.Delay(5 * 1000);
                App.Current.Shutdown();
                return;
            }

            // Запускаем анимацию
            transform.BeginAnimation(RotateTransform.AngleProperty,
                new DoubleAnimation
                {
                    From = 0,
                    To = 360,
                    Duration = TimeSpan.FromSeconds(1)
                });

            await Task.Delay(1 * 1000);

            // Ставим новые значения
            textblock1.Text = randData[itterator];
            if (randData[itterator] == "Красндор")
            {
                textblock1.Foreground = new SolidColorBrush(Colors.White);
                textblock1.Background = new SolidColorBrush(Colors.Red);

                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                if (Directory.Exists(soundsDir))
                    player.SoundLocation = Path.Combine(soundsDir, "krasndor.wav");
                player.Play();
            }
            else if (randData[itterator] == "Зелинзерин")
            {
                textblock1.Foreground = new SolidColorBrush(Colors.White);
                textblock1.Background = new SolidColorBrush(Colors.Green);

                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                if (Directory.Exists(soundsDir))
                    player.SoundLocation = Path.Combine(soundsDir, "zelinzerin.wav");
                player.Play();
            }
            else if(randData[itterator] == "Жёлтендуй")
            {
                textblock1.Foreground = new SolidColorBrush(Colors.Black);
                textblock1.Background = new SolidColorBrush(Colors.Yellow);

                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                if (Directory.Exists(soundsDir))
                    player.SoundLocation = Path.Combine(soundsDir, "jeltendyi.wav");
                player.Play();
            }
            else if(randData[itterator] == "Синевран")
            {
                textblock1.Foreground = new SolidColorBrush(Colors.White);
                textblock1.Background = new SolidColorBrush(Colors.Blue);

                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                if (Directory.Exists(soundsDir))
                    player.SoundLocation = Path.Combine(soundsDir, "sinevran.wav");
                player.Play();
            }
            textblock1.Foreground = new SolidColorBrush(Colors.White);
            itterator++;

            textblock2.Text = $"Осталось: {randData.Count - itterator}";
        }

        public List<string> Shuffle(List<string> list)
        {
            Random rand = new Random();

            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                var tmp = list[j];
                list[j] = list[i];
                list[i] = tmp;
            }

            return list;
        }

        //SoundPlayer player = new SoundPlayer();
        //player.Stream = Properties.Resources.Ding;
        //player.Play();
    }
}
