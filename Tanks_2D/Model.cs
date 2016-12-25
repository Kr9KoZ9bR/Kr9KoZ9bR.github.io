using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tanks_2D
{
    class Model
    {
        int killedTanks;
        int iFsize;
        int iTamount;
        public int iGspeed;
        int iEagression;



        public PGStat pgstat;

        Random r;

        Bullet bullet;
        internal Bullet Bullet
        {
            get { return bullet; }
        }

        Player player;
        internal Player Player
        {
            get { return player; }
        }

        List<Tank> tanks;
        internal List<Tank> Tanks
        {
            get { return tanks; }
        }

        List<DestroyedTank> destroiedTanks;
        internal List<DestroyedTank> DestroiedTanks
        {
            get { return destroiedTanks; }
        }



        public Walls wall;





        public Model(int iFsize, int iTamount, int iGspeed, int iEagression)
        {
            r= new Random();



            this.iFsize = iFsize;
            this.iTamount = iTamount;
            this.iGspeed = iGspeed;
            this.iEagression = iEagression;

            NewGame();


           

        }

        internal void NewGame()
        {
            killedTanks = 0;
            bullet = new Bullet();// создаем снаряд
            tanks = new List<Tank>();//создаем вражеские танки
            player = new Player(iFsize);//создаем танк игрока
            destroiedTanks = new List<DestroyedTank>();// создаем список уничтоженных танков

            CreateTanks();
            wall = new Walls();
            CreateDestroyedTanks();
            pgstat = PGStat.stops;
        }

        private void CreateDestroyedTanks() //создаем убитые танки
        {
            
            int x, y;
            while (destroiedTanks.Count < killedTanks)
            {

                x = 30 * killedTanks;
                y = 330;
                bool flag = true;

                foreach (DestroyedTank t in destroiedTanks)
                    if (t.X == x && t.Y == y)
                    {
                        flag = false;
                        break;
                    }

                if (flag)
                    destroiedTanks.Add(new DestroyedTank(x, y));
            }
        }


        private void CreateTanks()
        {
            int x, y;
            while (tanks.Count < iTamount)
            {
                if (tanks.Count == 0) //в первой итерации while создаем сначала Enemy а потом обычные танки. поместим enemy на 0 индекс в коллекцию tanks
                    tanks.Add(new Enemy(iFsize, r.Next(6) * 60, r.Next(6) * 60));


                x = r.Next(6) * 60; // получаем координату генерации танка кратную 60 (что бы попасть в коридор)
                y = r.Next(4) * 60; // берем величину меньше вертикального размера чтобы оставить место для игрока
                bool flag = true; //изначально предпологаем что координаты валидны
                
                foreach (Tank t in tanks) // проверяем наложение координат
                    if (t.X == x && t.Y == y) //поля X и Y это обобщения
                    {
                        flag = false;
                        break; // если произошло наложение координат выходим из цикла foreach и генерируем новые
                    }

                if (flag) // наложение не произошло
                    tanks.Add(new Tank(iFsize, x, y)); 
            }

        }



        public void PlayGame()
        {
            while (pgstat == PGStat.plays)
            {
                Thread.Sleep(iGspeed);

                bullet.Move();
                player.Move();
                ((Enemy) tanks[0]).Move(player.X, player.Y); //т. к. enemy наследуется от tank можем добавить его  
                for (int i = 1; i < tanks.Count; i++ )       //в список tanks но при этом не интерпретировать его в базовый класс. и тогда вызовем для него собственный метод Move
                    tanks[i].Move();//вызываем метод Move для всех танков



                for (int i = 0; i < tanks.Count - 1; i ++) //проверка на столкновение
                    for (int j = i+1; j<tanks.Count; j ++)
                        if (
                            (Math.Abs(tanks[i].X - tanks[j].X) <= 32 && (tanks[i].Y == tanks[j].Y))
                            ||
                            (Math.Abs(tanks[i].Y - tanks[j].Y) <= 32 && (tanks[i].X == tanks[j].X))
                            ||
                            (Math.Abs(tanks[i].X - tanks[j].X) <= 32 && Math.Abs(tanks[i].Y - tanks[j].Y) <= 32)
                            )
                        {
                            if (i == 0)
                                ((Enemy)tanks[i]).RotateBack(); //вызываем разворот отдельно для Enemy чтобы избежать ошибки установки корректного image
                            else
                            tanks[i].RotateBack();
                            tanks[j].RotateBack();
                        }

                for (int i = 0; i < tanks.Count; i++) // столкновение с игроком
                    if (
                        (Math.Abs(tanks[i].X - player.X) <= 29 && (tanks[i].Y == player.Y))
                         ||
                        (Math.Abs(tanks[i].Y - player.Y) <= 29 && (tanks[i].X == player.X))
                         ||
                        (Math.Abs(tanks[i].X - player.X) <= 29 && Math.Abs(tanks[i].Y - player.Y) <= 29)
                        )
                        pgstat = PGStat.looz;

                for (int i = 1; i < tanks.Count; i++)
                    if (Math.Abs(tanks[i].X - bullet.X) < 20 && Math.Abs(tanks[i].Y - bullet.Y) < 20)
                    {

                        killedTanks++;
                        tanks.RemoveAt(i);
                        CreateDestroyedTanks();
                    
                    }
                if (killedTanks + 1 == iTamount)
                    pgstat = PGStat.win;
                
                

            }


        }



    }
}
