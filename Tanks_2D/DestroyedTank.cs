using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tanks_2D
{
    class DestroyedTank
    {
        DestroyedTankPic destroyedTankPic = new DestroyedTankPic();
        Image img;
        int x, y;
        public int Y
        {
            get { return y; }
        }
        public int X
        {
            get { return x; }
        }

        public Image Img
        {
            get { return img; }
        }

        public DestroyedTank(int x, int y)
        {
            img = destroyedTankPic.Img;
            this.x = x;
            this.y = y;
        }


    }
}
