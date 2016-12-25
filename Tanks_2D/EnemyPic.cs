using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tanks_2D
{
    class EnemyPic
    {
        Image[] up = new Image[] {
            Properties.Resources.ETank_U0_1I, 
            Properties.Resources.ETank_U0_1II, 
            Properties.Resources.ETank_U0_1III, 
            Properties.Resources.ETank_U0_1IV, 
            Properties.Resources.ETank_U0_1V};
        Image[] down = new Image[] {
            Properties.Resources.ETank_D01I, 
            Properties.Resources.ETank_D01II, 
            Properties.Resources.ETank_D01III, 
            Properties.Resources.ETank_D01IV, 
            Properties.Resources.ETank_D01V};
        Image[] left = new Image[] {
            Properties.Resources.ETank_L_10I, 
            Properties.Resources.ETank_L_10II, 
            Properties.Resources.ETank_L_10III, 
            Properties.Resources.ETank_L_10IV, 
            Properties.Resources.ETank_L_10V};
        Image[] right = new Image[] {
            Properties.Resources.ETank_R10I, 
            Properties.Resources.ETank_R10II, 
            Properties.Resources.ETank_R10III, 
            Properties.Resources.ETank_R10IV, 
            Properties.Resources.ETank_R10V};


        public Image[] Up
        {
            get { return up; }
        }

        public Image[] Down
        {
            get { return down; }
        }
        public Image[] Left
        {
            get { return left; }
        }

        public Image[] Right
        {
            get { return right; }
        }
    }
}
