using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vojska.Models
{
    public class Vod
    {
        public ObservableCollection<Vojnik> listVojnika;

        public Vod()
        {
            listVojnika = new ObservableCollection<Vojnik>();

        }

        public void DodajVojnika(Vojnik noviVojnik) {
            listVojnika.Add(noviVojnik);
        
        }
    }
}
