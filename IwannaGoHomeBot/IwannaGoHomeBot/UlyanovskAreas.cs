using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IwannaGoHomeBot
{
    class UlyanovskAreas
    {
        public string nameArea;
        public AreaPoint lowerCorner;
        public AreaPoint upperCorner;
        public UlyanovskAreas(string nameArea,AreaPoint lowerCorner,AreaPoint upperCorner)
        {
            this.nameArea = nameArea;
            this.lowerCorner = lowerCorner;
            this.upperCorner = upperCorner;
        }
    }
    class AreaPoint
    {
        public double x;
        public double y;
        public AreaPoint(double x,double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class ListUlyanovskAreas
    {
        public List<UlyanovskAreas> listAreas = new List<UlyanovskAreas>();
        public ListUlyanovskAreas()
        {
            listAreas.Add(new UlyanovskAreas("Ленинский район", new AreaPoint(48.142719, 54.304395), new AreaPoint(48.427629, 54.421596)));
            listAreas.Add(new UlyanovskAreas("Железнодорожный район", new AreaPoint(48.159617, 54.184034), new AreaPoint(48.427863, 54.312989)));
            listAreas.Add(new UlyanovskAreas("Новый город", new AreaPoint(48.555639, 54.354189), new AreaPoint(48.62763, 54.401616)));
            listAreas.Add(new UlyanovskAreas("Засвияжский район", new AreaPoint(48.156652, 54.219679), new AreaPoint(48.371071, 54.330969)));
            listAreas.Add(new UlyanovskAreas("Заволжский район", new AreaPoint(48.457085, 54.276221), new AreaPoint(48.7256, 54.408843)));
        }
    }
}
