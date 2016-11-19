using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IwannaGoHomeBot
{
    class BusAlgoritm
    {
        public BusAlgoritm()
        {
            ListBus.Add(new Bus(16));
            ListBus.Add(new Bus(25));
            ListBus.Add(new Bus(16));
        }
        List<Bus> ListBus = new List<Bus>();

        public void FindBusForNewUser(string adress)
        {
            foreach (var bus in ListBus)
            {
                if (bus.HavePlaces)
                {
                    if (bus.AddPassanger(adress))
                    {

                    }
                }
            }
        }
    }
    class Bus
    {
        public Bus(int NumPlaces)
        {
            this.NumPlaces = NumPlaces;
        }
        string NumBus;
        public bool HavePlaces = true;
        public int NumPlaces;
        private List<string> adresses = new List<string>();
        public bool AddPassanger(string address)
        {
            if (adresses.Count <= NumPlaces)
            {
                adresses.Add(address);
                return true;
            }
            HavePlaces = false;
            return false;
        }
    }

    class PoiskVGlubinu
    {
        List<Bus> ListBus = new List<Bus>();
        List<Point> points = new List<Point>();

        public PoiskVGlubinu()
        {
            points.Add(new Point(48.283674, 54.358633, "Репина 49"));
            points.Add(new Point(52.283674, 54.358633, "2"));
            points.Add(new Point(49.283674, 54.358633, "3"));
            points.Add(new Point(53.283674, 51.358633, "4"));
            points.Add(new Point(46.283674, 53.358633, "5"));
            points.Add(new Point(49.983674, 55.358633, "6"));
            points.Add(new Point(35.283674, 57.358633, "7"));
            points.Add(new Point(47.283674, 54.358633, "8"));
            points.Add(new Point(55.283674, 52.358633, "9"));
            points.Add(new Point(44.283674, 53.358633, "10"));
            points.Add(new Point(43.283674, 55.358633, "11"));
            points.Add(new Point(49.283674, 57.358633, "12"));
            points.Add(new Point(50.83674, 59.358633, "13"));
            points.Add(new Point(51.283674, 52.358633, "14"));
            points.Add(new Point(60.283674, 51.358633, "15"));
            points.Add(new Point(32.283674, 50.358633, "16"));
            points.Add(new Point(17.283674, 59.358633, "17"));
            points.Add(new Point(48.274, 51.358633, "18"));
        }
        public void startFind()
        {
            ListBus.Add(new Bus(4));
            var firstpoint = points[0];
            Point secondpoint=points[1];

            ListBus.Last().AddPassanger(firstpoint.addres);

            while (points.Count != 0)
            {
                double MinDistance = 999999999;
                for (int i = 0; i < points.Count-1; i++)
                {
                    if (Math.Sqrt(Math.Pow(points[i].x - points[i + 1].x, 2) + Math.Pow(points[i].y - points[i + 1].y, 2))<MinDistance)
                    {
                        MinDistance = Math.Sqrt(Math.Pow(points[i].x - points[i + 1].x, 2) + Math.Pow(points[i].y - points[i + 1].y, 2));
                        firstpoint = points[i];
                        secondpoint = points[i + 1];
                    }
                }
                Console.WriteLine(MinDistance);
                if (ListBus.Last().HavePlaces)
                {
                    ListBus.Last().AddPassanger(secondpoint.addres);
                    points.Remove(secondpoint);
                }
                else
                {
                    ListBus.Add(new Bus(4));
                    ListBus.Last().AddPassanger(secondpoint.addres);
                    points.Remove(secondpoint);
                }
                if (points.Count == 1)
                {
                    if (ListBus.Last().HavePlaces)
                    {
                        ListBus.Last().AddPassanger(points[0].addres);
                        points.Remove(points[0]);
                    }
                    else
                    {
                        ListBus.Add(new Bus(4));
                        ListBus.Last().AddPassanger(points[0].addres);
                        points.Remove(points[0]);
                    }
                }
            }
            Console.ReadKey();
        }

    }

    class Point
    {
        public double x;
        public double y;
        public string addres;
         
        public Point(double x,double y,string addres)
        {
            this.x = x;
            this.y = y;
            this.addres = addres;
        }
    }
}
