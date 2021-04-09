using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.MVVMBsp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Page ContextPage { get; set; }

        public string NeuerName { get; set; }
        public int NeuesAlter { get; set; }

        public ObservableCollection<Model.Person> Personenliste
        {
            get { return Model.Person.Personenliste; }
            set { Model.Person.Personenliste = value; }
        }

        public Command HinzufuegenCmd { get; set; }
        public Command LoeschenCmd { get; set; }

        public MainViewModel()
        {
            HinzufuegenCmd = new Command(AddPerson, CanAddPerson);
            LoeschenCmd = new Command(DeletePerson);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddPerson(object p)
        {
            Model.Person person = new Model.Person()
            {
                Name = NeuerName,
                Alter = NeuesAlter
            };

            Personenliste.Add(person);

            NeuerName = String.Empty;
            NeuesAlter = 0;

            InformView(nameof(NeuerName));
            InformView(nameof(NeuesAlter));
        }

        public bool CanAddPerson(object parameter)
        {
            return (bool)parameter;
        }

        public async void DeletePerson(object parameter)
        {
            if (await ContextPage.DisplayAlert("Löschen", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein"))
                Personenliste.Remove(parameter as Model.Person);
        }

        private void InformView(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
