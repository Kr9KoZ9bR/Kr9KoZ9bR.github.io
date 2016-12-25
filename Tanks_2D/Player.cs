using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tanks_2D
{
    class Player : IMove, IRotate, IBorderlessField, ICurrentPic
    {
        PlayerPic playerPic = new PlayerPic();   //создаем объект класса PlayerPic
        Image[] img; //массив типа image
        Image currentImg;

        public Image CurrentImg
        {
            get { return currentImg; }
        }

        int iFsize;

        int x, y, direction_x, direction_y, nextDir_x, nextDir_y;

        public int NextDir_y
        {
            get { return nextDir_y; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    nextDir_y = value;
                else nextDir_y = 0;
            }

        }

        public int NextDir_x
        {
            get { return nextDir_x; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    nextDir_x = value;
                else nextDir_x = 0;
            }
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

        public Player(int iFsize) //конструктор игрока
       {
           this.iFsize = iFsize;
           this.x = 150;
           this.y = 300;
           this.NextDir_y = 0;
           this.NextDir_x = 0;
           this.direction_x = 1;
           this.direction_y = 0;
           UseImg();

           ChooseCurrentImg();



       }

        public int Y
        {
            get { return y; }
        }

        public int X
        {
            get { return x; }
        }

        public void Move() // движение
        {
            
                x += direction_x;
                y += direction_y;
                
                    Rotate();




            ChooseCurrentImg();
            BorderlessField();
        }

        int m;                          //выбор текущего изображение из массива (анимация)
        private void ChooseCurrentImg()
        {
            currentImg = img[m];
            m++;
            if (m == 5)
                m = 0;
        }

        public void Rotate()
        {
            if (x > 0 && x < 3 || x > 57 && x < 63 || x > 117 && x < 123 || x > 177 && x < 183 || x > 237 && x < 243 || x > 297 && x < 303)
                Direction_y = nextDir_y;

            if (y > 0 && y < 3 || y > 57 && y < 63 || y > 117 && y < 123 || y > 177 && y < 183 || y > 237 && y < 243 || y > 297 && y < 303 || y > 327 && y < 333)
                Direction_x = nextDir_x;

            UseImg();
        }



        public void BorderlessField() //прозрачность границ поля
        {
            if (x < -1)
                x = iFsize - 31;
            if (x > iFsize - 29)
                x = 1;
            if (y < -1)
                y = iFsize - 30;
            if (y > iFsize - 29)
                y = 1;
        }

        void UseImg()                //выбор изображения по направлению движения
        {
            if (direction_x == 1)
                img = playerPic.Right;
            if (direction_x == -1)
                img = playerPic.Left;
            if (direction_y == 1)
                img = playerPic.Down;
            if (direction_y == -1)
                img = playerPic.Up;
        }
    }
}
