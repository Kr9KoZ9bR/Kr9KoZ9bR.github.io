using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Tanks_2D
{
    partial class View : UserControl
    {
        Model model;


        public View(Model model)
        {
            InitializeComponent();
            this.model = model;
            
        }

        void Draw(PaintEventArgs e) //отрисовка
        {
            DrawWalls(e);
            DrawTank(e);
            DrawPlayer(e);
            DrawBullet(e);
            DrawDestroyedTank(e);
            

            if (model.pgstat != PGStat.plays)
                return;

            Thread.Sleep(model.iGspeed);
            Invalidate();
        }

        private void DrawDestroyedTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.DestroiedTanks.Count; i++)
                e.Graphics.DrawImage(model.DestroiedTanks[i].Img, new Point(model.DestroiedTanks[i].X, model.DestroiedTanks[i].Y));
            //foreach(DestroyedTank a in model.DestroiedTanks)
            //e.Graphics.DrawImage(a.Img, new Point(a.X, a.Y));

        }

        private void DrawBullet(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Bullet.Img, new Point(model.Bullet.X, model.Bullet.Y));
        }

        private void DrawPlayer(PaintEventArgs e) //метод отрисовки игрока (объекта класса игрок созданного в model)
        {

            e.Graphics.DrawImage(model.Player.CurrentImg, new Point(model.Player.X, model.Player.Y));

        }

        private void DrawTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.Tanks.Count; i++)
                e.Graphics.DrawImage(model.Tanks[i].CurrentImg, new Point(model.Tanks[i].X, model.Tanks[i].Y));
            
            //foreach(Tank t in model.Tanks)
               // e.Graphics.DrawImage(t.CurrentImg, new Point(t.X, t.Y));
        }

        private void DrawWalls(PaintEventArgs e)
        {
            for (int y = 30; y < 300; y += 60)
            for (int x = 30; x < 300; x +=60)
            e.Graphics.DrawImage(model.wall.Img, new Point(x, y));
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }

        private void View_Load(object sender, EventArgs e)
        {

        }
    }
}
