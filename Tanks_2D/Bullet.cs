using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tanks_2D
{
    class Bullet
    {
        private BulletPic bulletkPic = new BulletPic();
        private Image img;
        public Image Img
        {
            get { return img; }
        }

        int x, y, direction_x, direction_y; //определяем координаты

        public Bullet() //перегрузим конструктор по умолчанию
        {
            img = bulletkPic.BulUp;
            x = y = -30;
            Direction_x = Direction_y = 0;
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Direction_x
        {
            get { return direction_x; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direction_x = value;
                else direction_x = 0;
            }
        }

        public int Direction_y
        {
            get { return direction_y; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direction_y = value;
                else direction_y = 0;
            }
        }

        public void Move()
        {
            UseImg();
            x += Direction_x * 3;
            y += Direction_y * 3;
        
        }

        private void UseImg()
        {
            if (direction_x == 1)
                img = bulletkPic.BulRight;
            if (direction_x == -1)
                img = bulletkPic.BulLeft;
            if (direction_y == 1)
                img = bulletkPic.BulDown;
            if (direction_y == -1)
                img = bulletkPic.BulUp;
        }
    }
}
