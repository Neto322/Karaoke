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
using Microsoft.Win32;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

using System.Windows.Threading;

namespace Karaoke
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;

        AudioFileReader reader;

        WaveOut output;

        string path = Environment.CurrentDirectory;

        int i;

        int[] second =
        {
            0,3000,6000

        };

        string[] lyrics =
        {
            "A mí me gusta el Tangananica ;)",
            "Y yo prefiero el tanganana :0"
        };

        public MainWindow()
        {
            InitializeComponent();

            i = 0;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            texto.Visibility = Visibility.Hidden;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            bara.Value = reader.CurrentTime.TotalMilliseconds;

           if(reader.CurrentTime.TotalMilliseconds > second[i])
            {
                texto.Text = lyrics[i];
                i++;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Play.Visibility = Visibility.Hidden;
            reader = new AudioFileReader(path + "/31 minutos - Hermanos Guarennes - Tangananica, Tangananá.mp3");
            output = new WaveOut();
            bara.Maximum = reader.TotalTime.TotalMilliseconds;
            output.Init(reader);
            output.Play();
            timer.Start();
            texto.Visibility = Visibility.Visible;
        }
    }
}
