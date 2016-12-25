using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tanks_2D
{
    class Walls: IPic
    {
        WallsPic wallsPic = new WallsPic();
        Image img;

        public Image Img
        {
            get { return img; }
        }

        public Walls()
        {
            img = wallsPic.Img;
        }
    }
}
