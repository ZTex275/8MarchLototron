using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MarchLototron
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> randData;
        string soundsDir = Path.Combine(Directory.GetCurrentDirectory(), "Sounds");
        static int itterator = 0;
        static int krasndorCounter = 0;
        static int zelinzerinCounter = 0;
        static int jeltendyiCounter = 0;
        static int sinevranCounter = 0;

        public MainWindow()
        {
            InitializeComponent();

            // 4x8
            List<string> data = 
                ["Красндор", "Красндор", "Красндор", "Красндор", "Красндор", "Красндор", "Красндор", "Красндор",
                 "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин",
                 "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй",
                 "Синевран", "Синевран", "Синевран", "Синевран", "Синевран", "Синевран", "Синевран", "Синевран"];

            randData = Shuffle(data);

            textblock_krasndor.Text = krasndorCounter.ToString();
            textblock_zelinzerin.Text = zelinzerinCounter.ToString();
            textblock_jeltendyi.Text = jeltendyiCounter.ToString();
            textblock_sinevran.Text = sinevranCounter.ToString();
        }

        private async void onClickButtonStart(object sender, RoutedEventArgs e)
        {
            // Очищаем поле
            textblock1.Background = new SolidColorBrush(Colors.Transparent);
            textblock1.Text = null;
            textblock2.Text = null;

            if (itterator >= randData.Count)
            {
                if (File.Exists(Path.Combine(soundsDir, "krasndor.wav")))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    // Дорогие девушки, поздравляю с праздником, а мне надо лететь по своим волшебным делам. Ту туУ ту ту тУ ТУУУУУУ ТУУУУУУ ТУУУ 
                    player.SoundLocation = Path.Combine(soundsDir, "krasndor.wav"); // Другой wav
                    player.Play();
                }

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

                if (File.Exists(Path.Combine(soundsDir, "krasndor.wav")))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    player.SoundLocation = Path.Combine(soundsDir, "krasndor.wav");
                    player.Play();
                }

                krasndorCounter++;
                textblock_krasndor.Text = krasndorCounter.ToString();
            }
            else if (randData[itterator] == "Зелинзерин")
            {
                textblock1.Foreground = new SolidColorBrush(Colors.White);
                textblock1.Background = new SolidColorBrush(Colors.Green);

                if (File.Exists(Path.Combine(soundsDir, "zelinzerin.wav")))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    player.SoundLocation = Path.Combine(soundsDir, "zelinzerin.wav");
                    player.Play();
                }

                zelinzerinCounter++;
                textblock_zelinzerin.Text = zelinzerinCounter.ToString();
            }
            else if(randData[itterator] == "Жёлтендуй")
            {
                textblock1.Foreground = new SolidColorBrush(Colors.Black);
                textblock1.Background = new SolidColorBrush(Colors.Yellow);

                if (File.Exists(Path.Combine(soundsDir, "jeltendyi.wav")))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    player.SoundLocation = Path.Combine(soundsDir, "jeltendyi.wav");
                    player.Play();
                }

                jeltendyiCounter++;
                textblock_jeltendyi.Text = jeltendyiCounter.ToString();
            }
            else if(randData[itterator] == "Синевран")
            {
                textblock1.Foreground = new SolidColorBrush(Colors.White);
                textblock1.Background = new SolidColorBrush(Colors.Blue);

                if (File.Exists(Path.Combine(soundsDir, "sinevran.wav")))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    player.SoundLocation = Path.Combine(soundsDir, "sinevran.wav");
                    player.Play();
                }

                sinevranCounter++;
                textblock_sinevran.Text = sinevranCounter.ToString();
            }
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
    }
}
