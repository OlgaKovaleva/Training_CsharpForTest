using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
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

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB()) //устанавлили соедининение, а дальше идут запросы
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB()) //устанавлили соедининение, а дальше идут запросы
            {
                return (from c in db.Contacts
                             from gcr in db.GCR.Where(p => p.GroupID ==Id && p.ContactID ==c.Id && c.Deprecated == "0000-00-00-00 00:00:00") select c).Distinct().ToList();
            }
        }

        public GroupData()
        {
            
        }

        public GroupData(string name)
        {
            this.name = name;
        }

        [Column (Name= "group_name"), NotNull] //  NotNull на мне важен, можно не писать, т.к. мы писать ничего не будем туда, только читать
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

        [Column(Name = "group_header")]
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

        [Column(Name = "group_footer")]
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

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }
    }
}
