using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace X_Forms
{
    public class Person : INotifyPropertyChanged
    {
        private string vorname;
        public string Vorname 
        { 
            get => vorname; 
            set 
            { 
                vorname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vorname)));
            }
        }

        public string Nachname { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
