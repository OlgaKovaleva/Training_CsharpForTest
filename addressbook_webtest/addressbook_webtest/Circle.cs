using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_webtest
{
    class Circle: Figure // класс Circle наследуется от класса figure
    {
        private int radius;
        

        public Circle(int radius) //констурктор класса
        {
            this.radius = radius;
        }

        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }


    }
}
