using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IwannaGoHomeBot
{
    class Bus
    {
        public UlyanovskAreas area;
        public Bus(int NumPlaces, UlyanovskAreas area)
        {
            this.NumPlaces = NumPlaces;
            this.area = area;
        }
        string NumBus;
        public bool HavePlaces = true;
        int NumPlaces;
        private List<string> adresses = new List<string>();
        public void AddPassanger(string address)
        {
            if(address.Length==NumPlaces)
            {
                HavePlaces = false;
            }
            if (adresses.Count <= NumPlaces)
            {
                adresses.Add(address);
            }
        }
    }
}
