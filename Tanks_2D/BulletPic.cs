using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tanks_2D
{
    class BulletPic //задаем и инкапсулируем графику снаряда
    {
        Image bulUp = Properties.Resources.Bullet_U0_1;
        Image bulDown = Properties.Resources.Bullet_D01;
        Image bulLeft = Properties.Resources.Bullet_L_10;
        Image bulRight = Properties.Resources.Bullet_R10;

        public Image BulUp
        {
            get { return bulUp; }
        }
        public Image BulDown
        {
            get { return bulDown; }
        }
        public Image BulLeft
        {
            get { return bulLeft; }
        }
        public Image BulRight
        {
            get { return bulRight; }
        }
       

    }
}
