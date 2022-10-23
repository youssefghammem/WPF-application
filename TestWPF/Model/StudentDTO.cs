using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace TestWPF.Model
{
    public class StudentDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyyChanged("Id"); }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;OnPropertyyChanged("Name"); }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyyChanged("Age"); }
        }


    }
}
