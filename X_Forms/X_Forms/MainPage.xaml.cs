using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Neuzuweisung einer UI-Property über die x:Name-Property des Steuerelements
            Lbl_Output.Text = "Hallo Xamarin";
        }

        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            //Neuzuweisung einer Property des Eventauslösenden Steuerelements
            (sender as Button).Text = "Wurde geklickt";
        }

        private async void IBtn_Beispiel_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool erg = await DisplayAlert("Begrüßung", "Geht es dir gut?", "Ja", "Nein");

            if (erg)
                //Neuzuweisung der Textproperty des Labeld mit dem Ausgewählten Element des Pickers
                Lbl_Output.Text = Pkr_Monkeys.SelectedItem?.ToString();
        }
    }
}
