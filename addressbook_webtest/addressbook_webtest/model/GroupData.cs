using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class GroupData : IEquatable<GroupData>, IComparable<GroupData> //объект типа GroupData можно сравнивать с другими объектами такого типа
    {
        private string name;
        private string header;
        private string footer;

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()//сначала для сравниваемых элементов получаются хешкоды и сравниваются хешкоды. если хешкоды разные, то сразу автоматически считается, что элементы не равны. если хешкоды совпали, то только тогда начинается более точное сравнение при помощи equals

        {
            return Name.GetHashCode();

        }

        public override string ToString()
        {
            return "name=" + Name + "\n header" + Header + "\n footer" + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public GroupData(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;  
            }
            set
            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return header;

            }
            set
            {
                header = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

        public string Id { get; set; }
    }
}
