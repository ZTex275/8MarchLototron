using DevExpress.Mvvm.Native;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            //List<string> data = 
            //    ["Красндор", "Красндор", "Красндор", "Красндор", "Красндор", "Красндор", "Красндор", "Красндор",
            //     "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин", "Зелинзерин",
            //     "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй", "Жёлтендуй",
            //     "Синевран", "Синевран", "Синевран", "Синевран", "Синевран", "Синевран", "Синевран", "Синевран"];
            
            textbox_Count.Text = "32";
            textblock_krasndor.Text = krasndorCounter.ToString();
            textblock_zelinzerin.Text = zelinzerinCounter.ToString();
            textblock_jeltendyi.Text = jeltendyiCounter.ToString();
            textblock_sinevran.Text = sinevranCounter.ToString();
        }

        private async void onClickButtonStart(object sender, RoutedEventArgs e)
        {
            button_Start.IsEnabled = false;
            // Очищаем поле
            textblock_Faculty.Background = new SolidColorBrush(Colors.Transparent);
            textblock_Faculty.Text = null;
            textblock_LeftBehind.Text = null;

            // Когда закончились все элементы
            if (itterator >= randData.Count)
            {
                await ExitAsync();
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

            FillAndPlay();

            textblock_LeftBehind.Text = $"Осталось: {randData.Count - itterator}";

            button_Start.IsEnabled = true;
        }

        public void FillAndPlay()
        {
            // Ставим новые значения
            textblock_Faculty.Text = randData[itterator];
            if (randData[itterator] == "Красндор")
            {
                textblock_Faculty.Foreground = new SolidColorBrush(Colors.White);
                textblock_Faculty.Background = new SolidColorBrush(Colors.Red);

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
                textblock_Faculty.Foreground = new SolidColorBrush(Colors.White);
                textblock_Faculty.Background = new SolidColorBrush(Colors.Green);

                if (File.Exists(Path.Combine(soundsDir, "zelinzerin.wav")))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    player.SoundLocation = Path.Combine(soundsDir, "zelinzerin.wav");
                    player.Play();
                }

                zelinzerinCounter++;
                textblock_zelinzerin.Text = zelinzerinCounter.ToString();
            }
            else if (randData[itterator] == "Жёлтендуй")
            {
                textblock_Faculty.Foreground = new SolidColorBrush(Colors.Black);
                textblock_Faculty.Background = new SolidColorBrush(Colors.Yellow);

                if (File.Exists(Path.Combine(soundsDir, "jeltendyi.wav")))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    player.SoundLocation = Path.Combine(soundsDir, "jeltendyi.wav");
                    player.Play();
                }

                jeltendyiCounter++;
                textblock_jeltendyi.Text = jeltendyiCounter.ToString();
            }
            else if (randData[itterator] == "Синевран")
            {
                textblock_Faculty.Foreground = new SolidColorBrush(Colors.White);
                textblock_Faculty.Background = new SolidColorBrush(Colors.Blue);

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
        }

        private void textbox_Count_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            int count;
            if (int.TryParse(textbox_Count.Text, out count))
            {
                count = Convert.ToInt32(textbox_Count.Text);
                button_Start.IsEnabled = true;
            }
            else
            {
                // Ошибка преобразования
                button_Start.IsEnabled = false;
                return;
            }

            List<string> data = new();
            int j = 0;

            for (int i = 0; i < count; i++)
            {
                if (j > 3) j = 0;

                if (j == 0)
                    data.Add("Красндор");
                else if (j == 1)
                    data.Add("Зелинзерин");
                else if (j == 2)
                    data.Add("Жёлтендуй");
                else if (j == 3)
                    data.Add("Синевран");

                j++;
            }

            // Обнуляем переменные
            itterator = 0;
            krasndorCounter = 0;
            zelinzerinCounter = 0;
            jeltendyiCounter = 0;
            sinevranCounter = 0;

            textblock_krasndor.Text = krasndorCounter.ToString();
            textblock_zelinzerin.Text = zelinzerinCounter.ToString();
            textblock_jeltendyi.Text = jeltendyiCounter.ToString();
            textblock_sinevran.Text = sinevranCounter.ToString();

            randData = Shuffle(data);
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

        public async Task ExitAsync()
        {
            if (File.Exists(Path.Combine(soundsDir, "exit.wav")))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = Path.Combine(soundsDir, "exit.wav"); // Другой wav
                player.Play();
            }

            await Task.Delay(11 * 1000);
            App.Current.Shutdown();
            return;
        }

        private async void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            await ExitAsync();
        }

        private void textbox_Count_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            //Запрещаем вводить нечисловые значения
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
