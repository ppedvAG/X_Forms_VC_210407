using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class MainPage : ContentPage
    {
        //Property zum Zwischenspeichern der Personenliste (ObservableCollection ist eine generische Liste, welche die GUI
        //automatisch über Veränderungen innerhalb der Liste informiert)
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Anna", Nachname="Nass"}
        };

        //Konstruktor
        public MainPage()
        {
            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Neuzuweisung einer UI-Property über die x:Name-Property des Steuerelements
            Lbl_Main.Text = "Hallo Xamarin";

            //Durch Setzen des BindingContextes nehmen Kurzbindungen aus dem XAML-Code automatisch Bezug auf die Properties
            //des im BindingContext gesetzten Objekts
            this.BindingContext = this;

            Lbl_Battery.Text = Battery.State.ToString() + " | Level: " + Battery.ChargeLevel * 100 + "%";
        }

        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            //Neuzuweisung einer Property des Eventauslösenden Steuerelements
            (sender as Button).Text = "Wurde geklickt";

            Personenliste.Add(new Person() { Vorname = Ent_Vorname?.Text, Nachname = Ent_Nachname?.Text });
        }

        private async void IBtn_Beispiel_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool erg = await DisplayAlert("Begrüßung", "Geht es dir gut?", "Ja", "Nein");

            if (erg)
                //Neuzuweisung der Textproperty des Labeld mit dem Ausgewählten Element des Pickers
                Lbl_Main.Text = Pkr_Monkeys.SelectedItem?.ToString();
        }

        private void Btn_Name_Clicked(object sender, EventArgs e)
        {
            //Änderung einer Property des BindingContexts des StackLayouts (INotifyPropertyChanged informiert GUI über Veränderung (vgl. Person.cs))
            (StL_DataBinding.BindingContext as Person).Vorname = "Martin";
        }

        private void Btn_Push_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage 
            Navigation.PushAsync(new Layouts.GridLayoutBsp());
        }

        private void Btn_PushModal_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage, welche aber keinen 'Zurück'-Button anzeigt
            Navigation.PushModalAsync(new Layouts.AbsoluteLayoutBsp());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Personenliste.Clear();
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            //Personenliste.Remove((LstV_Namen.SelectedItem as Person));


            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschung", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen eines Listeneintrags
                Person person = (sender as MenuItem).CommandParameter as Person;

                Personenliste.Remove(person);
            }
        }

        private void Btn_Tabbed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationBsps.TabbedPageBsp());
        }

        private async void Btn_Youtube_Clicked(object sender, EventArgs e)
        {
            //Öffnen der Youtube-App über die Xamarin-Essentials mit Übergabe des Package-Namens
            if (await Launcher.CanOpenAsync("vnd.youtube://"))
               await Launcher.OpenAsync("vnd.youtube://rLKnqR9Oqh8");
        }
    }
}
