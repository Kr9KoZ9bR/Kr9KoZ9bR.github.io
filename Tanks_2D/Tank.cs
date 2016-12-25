using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tanks_2D
{
    class Tank: IMove, IRotate, IRotateBack, IBorderlessField, ICurrentPic
    {
       private TankPic tankPic = new TankPic();

       private void UseImg()
       {
           if (direction_x == 1)
               img = tankPic.Right;
           if (direction_x == -1)
               img = tankPic.Left;
           if (direction_y == 1)
               img = tankPic.Down;
           if (direction_y == -1)
               img = tankPic.Up;
       }

       protected Image[] img;

       protected Image currentImg;

       protected int iFsize;

       protected int x, y, direction_x, direction_y;

       protected static Random r;

       protected int m;
       protected void ChooseCurrentImg()
        {
            currentImg = img[m];
            m++;
            if (m == 5)
                m = 0;
        }

       public Image CurrentImg
       {
           get { return currentImg; }
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

       public Tank(int iFsize, int x, int y)
       {
           this.iFsize = iFsize;

           r = new Random();// определяем направление движения при генерации танка
           if (r.Next(100) < 50)
           {
               Direction_y = 0;
           loop:
               Direction_x = r.Next(-1, 2);
               if (Direction_x == 0)
                   goto loop;
           }
           else
           { 
            Direction_x = 0;
           loop:
               Direction_y = r.Next(-1, 2);
               if (Direction_y == 0)
                   goto loop;
           }

           UseImg();

           ChooseCurrentImg();

           this.x = x;
           this.y = y;

       }

       public int Y
       {
           get { return y; }
       }

       public int X
       {
           get { return x; }
       }
                      
       public void Move()
        {
            
            x += direction_x;
            y += direction_y;
            if (Math.IEEERemainder(x, 60) == 0 && Math.IEEERemainder(y, 60) == 0)
                Rotate();

            ChooseCurrentImg();
            BorderlessField();
        }
        
       public void Rotate()
        {
                if (r.Next(5000) < 2500)
                {
                    if (Direction_y == 0)//движение по вертикали
                    {
                        direction_x = 0;
                        while (Direction_y == 0)
                            Direction_y = r.Next(-1, 2);
                    }
                }
                else//движ по горизонтали
                {
                    if (Direction_x == 0)  
                    { 
                        direction_y = 0;
                        while (Direction_x == 0)
                            Direction_x = r.Next(-1, 2);

                    }
                }
            UseImg();
        }

       public void BorderlessField()
        {
            if (x <= -1)
                x = iFsize - 31;
            if (x >= iFsize - 29)
                x = 1;
            if (y <= -1)
                y = iFsize - 31;
            if (y >= iFsize - 29)
                y = 1;


        }
            
       public void RotateBack()//разворот на 180
        {
            Direction_x = -1 * Direction_x;
            Direction_y = -1 * Direction_y;
            UseImg();
        }

    }
}
