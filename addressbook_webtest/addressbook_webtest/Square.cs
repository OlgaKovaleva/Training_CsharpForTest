using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_webtest
{
    class Square: Figure  // класс Square наследуется от класса Figure
    {
        private int size; //default size=0 for integer
       
        public Square (int size) //конструктор класса
        {
            this.size = size; //в поле класса присваиваем значение, которое передано через параметр

            //в текущий объект его поля помещаем значение, которое передано в качестве параметра;
            //без префикса this это будет всего лишь локальная переменная
        }

        public int Size //определяем property с помощью  getters and setters
        {
            get
            {
                return size;
            }
            set
            {
                size = value;

            }
        }
        public int getSize ()
        {
            return size;
        }

        public void setSize(int size)
        {
            this.size = size;
        }
    }
}
