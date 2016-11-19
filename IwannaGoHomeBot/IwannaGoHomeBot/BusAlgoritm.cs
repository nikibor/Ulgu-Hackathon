using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IwannaGoHomeBot
{
    class BusAlgoritm
    {
        ListUlyanovskAreas listAreas = new ListUlyanovskAreas();
        public BusAlgoritm()
        {
            ListBus.Add(new Bus(6,listAreas.listAreas.Find(x=>x.nameArea=="Железнодорожный район")));
            ListBus.Add(new Bus(6, listAreas.listAreas.Find(x => x.nameArea == "Ленинский район")));
            ListBus.Add(new Bus(6, listAreas.listAreas.Find(x => x.nameArea == "Новый город")));
            ListBus.Add(new Bus(6, listAreas.listAreas.Find(x => x.nameArea == "Засвияжский район")));
            ListBus.Add(new Bus(6, listAreas.listAreas.Find(x => x.nameArea == "Заволжский район")));

            points.Add(new Point(48.324314,54.256019,"ВАРЕЙКИСА 6"));
            points.Add(new Point(48.288273, 54.284022,"кузоватовская 45"));
            points.Add(new Point(48.588158, 54.388569, "пр.авиастроителей 12 / 21"));
            points.Add(new Point(48.388013, 54.352011, "ленинс северный венец 32"));
            points.Add(new Point(48.367541,54.304069, "засв набережная свияги 40"));
            points.Add(new Point(48.298514, 54.269376, "проспект хо ши мина засвияж"));
            points.Add(new Point(48.383585, 54.351948, "ул розы люксембург 34"));
            points.Add(new Point(48.338866, 54.347624, "бульвар архитекторов 13"));
            points.Add(new Point(48.385812, 54.323135, "карла маркса 39"));
            points.Add(new Point(48.333126, 54.259669, "хрустальная 34"));
            points.Add(new Point(48.369086, 54.351996, "2 переулок нариманова 32"));
            points.Add(new Point(48.298101, 54.276269, "самарская 11"));
            points.Add(new Point(48.310264, 54.257712, "гая"));
            points.Add(new Point(48.541553, 54.351896, "вр Михайлова 35"));
            points.Add(new Point(48.394293, 54.329699, "островского 50"));
            points.Add(new Point(48.363651, 54.287475, "локомотивная 13"));
            points.Add(new Point(48.313193, 54.289945, "доватора 32"));
            points.Add(new Point(48.385705, 54.306665, "минаева 42"));
        }
        List<Point> points = new List<Point>();     
        List<Bus> ListBus = new List<Bus>();

        public void FindBusForNewUser()
        {
            for(int i=0;i<points.Count;i++)
            {
                foreach(var area in listAreas.listAreas)
                {
                    if(points[i].x > area.lowerCorner.x && points[i].x < area.upperCorner.x && points[i].y<area.upperCorner.y && points[i].y>area.lowerCorner.y)// Проверка на вхождение в район
                    {
                        if(ListBus.Find(x => x.area == area || x.HavePlaces == true)==null)
                        {
                            ListBus.Add(new Bus(6, new ListUlyanovskAreas().listAreas.Find(x => x == area)));
                        }
                        ListBus.Find(x => x.area == area||x.HavePlaces==true).AddPassanger(points[i].addres);
                        Console.WriteLine("Автобус следует в -{0} добавлен пассажир -{1}", area.nameArea, points[i].addres);
                        break;
                    }
                }
            }
            Console.ReadKey();
        }
    }

    //class PoiskVGlubinu
    //{
    //    List<Bus> ListBus = new List<Bus>();
    //    List<Point> points = new List<Point>();

    //    public PoiskVGlubinu()
    //    {
    //        points.Add(new Point(48.283674, 54.358633, "Репина 49"));
    //        points.Add(new Point(52.283674, 54.358633, "2"));
    //        points.Add(new Point(49.283674, 54.358633, "3"));
    //        points.Add(new Point(53.283674, 51.358633, "4"));
    //        points.Add(new Point(46.283674, 53.358633, "5"));
    //        points.Add(new Point(49.983674, 55.358633, "6"));
    //        points.Add(new Point(35.283674, 57.358633, "7"));
    //        points.Add(new Point(47.283674, 54.358633, "8"));
    //        points.Add(new Point(55.283674, 52.358633, "9"));
    //        points.Add(new Point(44.283674, 53.358633, "10"));
    //        points.Add(new Point(43.283674, 55.358633, "11"));
    //        points.Add(new Point(49.283674, 57.358633, "12"));
    //        points.Add(new Point(50.83674, 59.358633, "13"));
    //        points.Add(new Point(51.283674, 52.358633, "14"));
    //        points.Add(new Point(60.283674, 51.358633, "15"));
    //        points.Add(new Point(32.283674, 50.358633, "16"));
    //        points.Add(new Point(17.283674, 59.358633, "17"));
    //        points.Add(new Point(48.274, 51.358633, "18"));
    //    }
    //    public void startFind()
    //    {
    //        ListBus.Add(new Bus(4));
    //        var firstpoint = points[0];
    //        Point secondpoint=points[1];

    //        ListBus.Last().AddPassanger(firstpoint.addres);

    //        while (points.Count != 0)
    //        {
    //            double MinDistance = 999999999;
    //            for (int i = 0; i < points.Count-1; i++)
    //            {
    //                if (Math.Sqrt(Math.Pow(points[i].x - points[i + 1].x, 2) + Math.Pow(points[i].y - points[i + 1].y, 2))<MinDistance)
    //                {
    //                    MinDistance = Math.Sqrt(Math.Pow(points[i].x - points[i + 1].x, 2) + Math.Pow(points[i].y - points[i + 1].y, 2));
    //                    firstpoint = points[i];
    //                    secondpoint = points[i + 1];
    //                }
    //            }
    //            Console.WriteLine(MinDistance);
    //            if (ListBus.Last().HavePlaces)
    //            {
    //                ListBus.Last().AddPassanger(secondpoint.addres);
    //                points.Remove(secondpoint);
    //            }
    //            else
    //            {
    //                ListBus.Add(new Bus(4));
    //                ListBus.Last().AddPassanger(secondpoint.addres);
    //                points.Remove(secondpoint);
    //            }
    //            if (points.Count == 1)
    //            {
    //                if (ListBus.Last().HavePlaces)
    //                {
    //                    ListBus.Last().AddPassanger(points[0].addres);
    //                    points.Remove(points[0]);
    //                }
    //                else
    //                {
    //                    ListBus.Add(new Bus(4));
    //                    ListBus.Last().AddPassanger(points[0].addres);
    //                    points.Remove(points[0]);
    //                }
    //            }
    //        }
    //        Console.ReadKey();
    //    }

    //}

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
