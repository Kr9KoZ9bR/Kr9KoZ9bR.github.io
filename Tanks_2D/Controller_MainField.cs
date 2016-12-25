using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Tanks_2D
{
    public partial class Controller_MainField : Form
    {
        View view;
        Model model;

        Thread modelPlayGame;


        public Controller_MainField() : this(330) { }
        public Controller_MainField(int iFsize) : this(iFsize, 4) { }
        public Controller_MainField(int iFsize, int iTamount) : this(iFsize, iTamount, 40) { }
        public Controller_MainField(int iFsize, int iTamount, int iGspeed) : this(iFsize, iTamount, iGspeed, 1) { }
        public Controller_MainField(int iFsize, int iTamount, int iGspeed, int iEagression)
        {
            InitializeComponent();
            model = new Model(iFsize, iTamount, iGspeed, iEagression);

            view = new View(model);
            this.Controls.Add(view);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (model.pgstat == PGStat.plays)
            {
                modelPlayGame.Abort();
                model.pgstat = PGStat.stops;
                StatusChangerStrip();
            }
            else
            {
                model.pgstat = PGStat.plays;
                modelPlayGame = new Thread(model.PlayGame);
                modelPlayGame.Start();
                StatusChangerStrip();
                view.Invalidate();
            }

        }

        private void Controller_MainField_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modelPlayGame != null)
            {
                model.pgstat = PGStat.stops;
                modelPlayGame.Abort();
            }
            DialogResult esc = MessageBox.Show("Дезертировать?!", "Tanks_2D", MessageBoxButtons.YesNoCancel);
            if (esc == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;


        }

        private void PlayerControl(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case 'a':
                case 'ф':
                case 'A':
                case 'Ф':
                    {
                        model.Player.NextDir_x = -1;
                        model.Player.NextDir_y = 0;
                    }
                    break;
                case 'd':
                case 'в':
                case 'D':
                case 'В':
                    {
                        model.Player.NextDir_x = 1;
                        model.Player.NextDir_y = 0;
                    }
                    break;
                case 'w':
                case 'ц':
                case 'W':
                case 'Ц':
                    {
                        model.Player.NextDir_x = 0;
                        model.Player.NextDir_y = -1;
                    }
                    break;
                case 's':
                case 'ы':
                case 'і':
                case 'S':
                case 'Ы':
                case 'І':
                    {
                        model.Player.NextDir_x = 0;
                        model.Player.NextDir_y = 1;
                    }
                    break;

                case 'e':
                case 'E':
                case 'у':
                case 'У':
                    {
                        model.Bullet.Direction_x = model.Player.Direction_x; // направление движения и точка генерирования снаряда
                        model.Bullet.Direction_y = model.Player.Direction_y;

                        if (model.Player.Direction_y == -1)
                        {
                            model.Bullet.X = model.Player.X + 13;
                            model.Bullet.Y = model.Player.Y;
                        }
                        if (model.Player.Direction_y == 1)
                        { 
                            model.Bullet.X = model.Player.X + 13;
                            model.Bullet.Y = model.Player.Y + 25;
                        }
                        if (model.Player.Direction_x == 1)
                        { 
                            model.Bullet.X = model.Player.X + 25;
                            model.Bullet.Y = model.Player.Y + 13;
                        }
                        if (model.Player.Direction_x == -1)
                        { 
                            model.Bullet.X = model.Player.X;
                            model.Bullet.Y = model.Player.Y + 13;
                        }
                    }
                    break;
            }





        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)// выход из игры через меню
        {
            Application.Exit();
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.NewGame();
            view.Refresh();

        }

        void StatusChangerStrip()
        {
            GameStatus_strip.Text = model.pgstat.ToString();
        }
    }
}
      

