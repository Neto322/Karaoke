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
            0,3200,7100,11107,14112,18006,22012,25090,29002,33000,36500,40000,44000,47000,52000,55000,57000,61000,63000,65000,72000,75000,79000,82000,87000,90000,93000,101000,10000000

        };

        string[] lyrics =
        {
            "A mí me gusta el Tangananica ^̮^",
            "Y yo prefiero el tanganana ˙ ͜ʟ˙",
            "La mejor frase es tangananica ヽ༼ຈل͜ຈ༽ﾉ",
            @"El mejor verso es tanganana \ (•◡•) /",
            "Tangananica nica nica nica ~(˘▾˘~)",
            "Tanganana ヾ(⌐■_■)ノ♪",
            "Todo lo explica ja!! (ᵔᴥᵔ)",
            "no explica na(╯°□°)╯",
            "Para alegrarme digo tangananica ヽ(◕ヮ◕ヽ)",
            "Para reírme digo tanganana (☞ﾟ∀ﾟ)☞",
            "Comí un rico tangananica(づ￣ ³￣)づ",
            "A mí me dieron tanganana ( ͡° ͜ʖ ͡°)",
            "Tangananica nica nica nica (◕‿◕✿)",
            "Tanganana (¬‿¬)",
            "Me tienes pica pica (;´༎ຶД༎ຶ`)",
            "no pasa na ( ▀ ͜͞ʖ▀)",
            "Cómo voy a perder mi palabra es tan buena ( ͡ᵔ ͜ʖ ͡ᵔ )",
            "Tu palabra es tan mala ◉_◉",
            @"no hay nada qué hacer¯\_(ツ)_/¯",
            "Cómo vas a ganar si la mejor palabra es tanganana (ง ͠° ͟ل͜ ͡°)ง",
            "Tú siempre dices tangananica ಠ_ಠ",
            "Tú siempre gritas tanganana ಠ╭╮ಠ",
            "Ya no soporto el tangananicaლ(ಠ益ಠლ)",
            "Y yo detesto tu tanganana(¬_¬)",
            "Tangananica nica nica nica ╚(ಠ_ಠ)=┐",
            "Tanganana ლ,ᔑ•ﺪ͟͠•ᔐ.ლ",
            "Nuestra mamá nos va a retar... °Д°",
            "Oye, oye, ordenemos mejor o si no nos van a pillar..."










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
