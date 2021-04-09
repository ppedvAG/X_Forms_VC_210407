using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace X_Forms.MVVMBsp.Model
{
    public class Person
    {
        public string Name { get; set; }
        public int Alter { get; set; }

        public static ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();
    }
}
