using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace xamarinCompraList.Models
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Actualizar([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        //public bool Listo { get; set; }
        private bool listo;

        public bool Listo
        {
            get { return listo; }
            set { listo = value; Actualizar(); }
        }

        public string QuienAgrego { get; set; }
    }
}
