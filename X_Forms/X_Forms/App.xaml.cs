using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    public partial class App : Application
    {
        //Die App-Klasse beinhaltet eine grundlegen Initialisierung der App sowie die MainPage-Property, welche defniert,
        //welche Page gerade in der App angezeigt wird. Diese Property wird auch als Einstiegspunkt verwendet.
        public App()
        {
            InitializeComponent();

            //Zuweisung der MainPage-Property zu einer Page
            //MainPage = new MainPage();

            //Zuweisung der MainPage - Property zu einer NavigationPage(ermöglicht Stack - Navigation) mit Angabe der Startpage.
            //MainPage = new NavigationPage(new MainPage());

            //Zuweisung der FlyoutPage als Hauptnavigation zu der MainPage-Property
            MainPage = new NavigationBsps.Flyout.FlyoutPageMain();
        }

        //Methoden, welche zu bestimmten globalen Events ausgeführt werden (Start, Unterbrechen der App [Sleep], Wiederaktivierung der App [Resume])
        protected override void OnStart()
        {
            //Aufruf der Essentials.Preferences-Klasse zum Speichern und Abrufen von App-Settings
            if (Preferences.ContainsKey("timestamp"))
                MainPage.DisplayAlert("Gespeicherte Zeit", Preferences.Get("timestamp", DateTime.Now).ToString(), "ok");
        }

        protected override void OnSleep()
        {
            Preferences.Set("timestamp", DateTime.Now);
        }

        protected override void OnResume()
        {
            MainPage.DisplayAlert("Geschlafene Zeit", DateTime.Now.Subtract(Preferences.Get("timestamp", DateTime.Now)).ToString(), "ok");
        }
    }
}
