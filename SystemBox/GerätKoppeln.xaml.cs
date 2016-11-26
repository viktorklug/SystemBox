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


namespace SystemBox
{
   
    public sealed partial class GerätKoppeln : Page
    {
        public GerätKoppeln()
        {
            this.InitializeComponent();

            //if (Karte_Drin_CheckBox.IsChecked == true) // Abfrage ob Karte noch drin ist sonst keine Signale aufnehmen 
            //{
            //    if (Signal_JA_RadioButton.IsChecked == true)
            //    {
            //        this.Frame.Navigate(typeof(MessungLäuft)); // Aufnahme weiter
            //    }
            //    else
            //    {
            //        this.Frame.Navigate(typeof(Bereit));  // Aufnahme weiter
            //    }
            //}
            //else
            //{
            //    this.Frame.Navigate(typeof(Fehlermeldung));  // Fehlermedung bei Signal und keine Karte
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //if (Signal_JA_RadioButton.IsChecked == true)  // Signal aber keine Karte Fehlermeldung
            //{
            //    if (Karte_Drin_CheckBox.IsChecked == false)
            //    {
            //        this.Frame.Navigate(typeof(Fehlermeldung));
            //    }
            //    else
            //    {
            //        this.Frame.Navigate(typeof(MessungLäuft));
            //    }
            //}
        }

        
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Karte_Drin(object sender, RoutedEventArgs e)
        {
            if(Signal_JA_RadioButton.IsChecked == true)
            {
                this.Frame.Navigate(typeof(MessungLäuft));
            }
            else
            {
                
            }
        }
    }
}
