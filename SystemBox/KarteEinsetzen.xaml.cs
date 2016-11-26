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
using Mfrc522Lib;




namespace SystemBox
{
    
    public sealed partial class KarteEinsetzen : Page
    {
        Mfrc522 mfrc = new Mfrc522();

        public KarteEinsetzen()
        {
            this.InitializeComponent();

            //if (Karte_Drin_CheckBox.IsChecked == true)
            //{
            //    this.Frame.Navigate(typeof(GerätKoppeln));
            //}

            Loaded += PageLoaded;
            
        }



        private void Karte_Drin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GerätKoppeln));
        }

        private void Exit_Button_Clic(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {

            while (true)
            {
                if (mfrc.IsTagPresent())
                {
                    var uid = mfrc.ReadUid();

                    mfrc.HaltTag();

                    textBox.Text = uid.ToString();

                    break;
                }

            }
        }

        public async void InitCardReader()
        {
            await mfrc.InitIO();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            InitCardReader();

            //this.Frame.Loaded += Karte_Loaded;

            //Karte_Drin_CheckBox.SetValue(CheckBox.IsCheckedProperty, true);


        }



        //private void Karte_Loaded(object sender, RoutedEventArgs e)
        //{
        //    while (Karte_Drin_CheckBox.IsChecked == true)
        //    {
        //        if (mfrc.IsTagPresent())
        //        {
        //            var uid = mfrc.ReadUid();

        //            mfrc.HaltTag();

        //            textBox.Text = uid.ToString();



        //        }
        //    }
        //}


    }
}
