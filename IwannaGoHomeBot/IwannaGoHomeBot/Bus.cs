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
        public Bus(string NumBus,int NumPlaces, UlyanovskAreas area)
        {
            this.NumBus = NumBus;
            this.NumPlaces = NumPlaces;
            this.area = area;
        }
        public string NumBus;
        public bool HavePlaces = true;
        int NumPlaces;
        public List<Point> Marshrutpoints = new List<Point>();
        public void AddPassanger(string address,double x,double y)
        {
            if(address.Length==NumPlaces)
            {
                HavePlaces = false;
            }
            if (Marshrutpoints.Count <= NumPlaces)
            {
                Marshrutpoints.Add(new Point(x,y,address));
            }
        }
    }
}
