﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tanks_2D
{
    class TankPic
    {
        Image[] up = new Image[] {
            Properties.Resources.Tank_U0_1I, 
            Properties.Resources.Tank_U0_1II, 
            Properties.Resources.Tank_U0_1III, 
            Properties.Resources.Tank_U0_1IV, 
            Properties.Resources.Tank_U0_1V};
        Image[] down = new Image[] {
            Properties.Resources.Tank_D01I, 
            Properties.Resources.Tank_D01II, 
            Properties.Resources.Tank_D01III, 
            Properties.Resources.Tank_D01IV, 
            Properties.Resources.Tank_D01V};
        Image[] left = new Image[] {
            Properties.Resources.Tank_L_10I, 
            Properties.Resources.Tank_L_10II, 
            Properties.Resources.Tank_L_10III, 
            Properties.Resources.Tank_L_10IV, 
            Properties.Resources.Tank_L_10V};
        Image[] right = new Image[] {
            Properties.Resources.Tank_R10I, 
            Properties.Resources.Tank_R10II, 
            Properties.Resources.Tank_R10III, 
            Properties.Resources.Tank_R10IV, 
            Properties.Resources.Tank_R10V};


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
