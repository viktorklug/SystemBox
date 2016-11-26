using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Gpio;


namespace SystemBox
{

    public sealed partial class MainPage : Page
    {


        private const int Charging_Pin = 4;     // GpioPin 4 prüft ob an der Ladestation oder mobil, Liegt Spannung an.
        private GpioPin ChargPin;
        private GpioPinValue ChargPinValue;

        //private DispatcherTimer timer;



        public MainPage()
        {
            this.InitializeComponent();

            Application.Current.DebugSettings.EnableFrameRateCounter = false; //FrameRateCounter Deaktiviert
            
            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(2);
            //timer.Tick += Timer_Tick;
            //timer.Start();
            
            Unloaded += MainPage_Unloaded;

            InitGPIO();

        }


        private void AdminPage_Click(object sender, RoutedEventArgs e) // Button Adminbereich !Muss Überarbeitet werden, KennwortBlock kein TextBlock anlegen
        {
            this.Frame.Navigate(typeof(AdminPage));
        }

        private void Start_Click(object sender, RoutedEventArgs e) // Button Start
        {
            ChargPinValue = ChargPin.Read();
            if (ChargPinValue == GpioPinValue.High)
            {
                if (Sync_RadioButton.IsChecked == true)  // Werden Daten mit Server Synchronisiert?
                {
                    this.Frame.Navigate(typeof(SyncBildschirm));  // Während Synchronisation, zeige diesen Bildschirm
                }
                else
                {
                    this.Frame.Navigate(typeof(LadeBildschirm)); // Keine Synchronisation, zeige diesen Bildschrim
                }
            }

            else if (ChargPinValue == GpioPinValue.Low)
            {
                this.Frame.Navigate(typeof(KarteEinsetzen));
            }
        }
                
        private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            if (gpio == null)
            {
                ChargPin = null;
                //                
                GpioStatus.Text = "Auf diesem Gerät ist kein GPIO-Controller vorhanden.";
                return;
            }
            ChargPin = gpio.OpenPin(Charging_Pin);
            //
            ChargPin.Write(GpioPinValue.Low);
            ChargPin.SetDriveMode(GpioPinDriveMode.Input);
            //            
            GpioStatus.Text = "GPIO-Pin korrekt initialisiert.";
        }

        private void MainPage_Unloaded(object sender, object args)
        {
            ChargPin.Dispose();
        }

        //private void Flip_5V_Check_Box()
        //{
        //    ChargPinValue = ChargPin.Read();
        //    if (ChargPinValue == GpioPinValue.High)
        //    {
        //        // hier muss was hin 5V ?
        //    }

        //    else if (ChargPinValue == GpioPinValue.Low)
        //    {
        //        //hier muss was hin 5V?
        //    }
        //    //                       
        //}

        //private void Timer_Tick(object sender, object e)
        //{

        //}



    }
}



