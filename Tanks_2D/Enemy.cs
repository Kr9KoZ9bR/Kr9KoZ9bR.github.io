using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks_2D
{
    class Enemy: Tank
    {


        EnemyPic enemyPic = new EnemyPic();
        private void UseImg()
        {
            if (direction_x == 1)
                img = enemyPic.Right;
            if (direction_x == -1)
                img = enemyPic.Left;
            if (direction_y == 1)
                img = enemyPic.Down;
            if (direction_y == -1)
                img = enemyPic.Up;
        }
        //т. к. сигнатуры следующих методов отличаются от их сигнатур в родительском классе ключевое слово new при их переопределении не требуется
        public void Rotate(int target_x, int target_y) //внедряем алгоритм преследования игрока
        {
            Direction_x = Direction_y = 0;

            if (X > target_x)
                Direction_x = -1;
            if (X < target_x)
                Direction_x = 1;
            if (Y > target_y)
                Direction_y = -1;
            if (Y < target_y)
                Direction_y = 1;

            if (Direction_x != 0 && Direction_y != 0)
                if (r.Next(3000) < 1500)
                    Direction_x = 0;
                else
                    Direction_y = 0;

            UseImg();
        }

        public void Move(int target_x, int target_y)
        {


            x += direction_x;
            y += direction_y;
            if (Math.IEEERemainder(x, 60) == 0 && Math.IEEERemainder(y, 60) == 0)
                Rotate(target_x, target_y);

            ChooseCurrentImg();
            BorderlessField();
        }

        new public void RotateBack()//разворот на 180
        {
            Direction_x = -1 * Direction_x;
            Direction_y = -1 * Direction_y;
            UseImg();
        }


        public Enemy(int iFsize, int x, int y) : base(iFsize, x, y) { UseImg(); ChooseCurrentImg(); }
        
    }
}
