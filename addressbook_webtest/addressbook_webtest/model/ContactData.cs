using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name ="addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>, IFormatProvider
    {
        private string firstName;
        private string lastName;
        private string middleName;
        private string nickname;
        private string title;
        private string company;
        private string address;
        private string homeTelephone;
        private string mobileTelephone;
        private string workTelephone;
        private string faxTelephone;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private string birthdate;
        private string anniversary;
        private string group;
        private string addressSecondary;
        private string homeSecondary;
        private string notesSecondary;
        private string photo;
        private string allTelephones;
        private string allEmails;
        private string age;
        private string anniversaryPeriod;

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return LastName == other.LastName && FirstName==other.FirstName ;
        }

        public override int GetHashCode()//сначала для сравниваемых элементов получаются хешкоды и сравниваются хешкоды. если хешкоды разные, то сразу автоматически считается, что элементы не равны. если хешкоды совпали, то только тогда начинается более точное сравнение при помощи equals

        {
            return Tuple.Create(FirstName,LastName).GetHashCode();
            

        }

        public override string ToString()
        {
            return "first name=" + FirstName+"last name="+LastName;
        }

       

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName)==0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return LastName.CompareTo(other.LastName);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB()) //устанавлили соедининение, а дальше идут запросы
            {
                return (from c in db.Contacts.Where(x=> x.Deprecated == "0000-00-00-00 00:00:00") select c).ToList(); //лямбда выражения, т.е. в where анонимная функция
            }
        }

        //public List<GroupData> GetGroups()
        //{
        //    using (AddressBookDB db = new AddressBookDB()) //устанавлили соедининение, а дальше идут запросы
        //    {
        //        return (from g in db.Groups
        //                from gcr in db.GCR.Where(p => p.ContactID == Id && p.GroupID == g.Id && g.Deprecated == "0000-00-00-00 00:00:00")
        //                select g).Distinct().ToList();
        //    }
        //}

        public ContactData (string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public ContactData()
        {
            
        }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set;  }

        [Column(Name ="middlename")]
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }

        [Column(Name = "nickname")]
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        [Column(Name = "title")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        [Column(Name = "company")]
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string HomeTelephone
        {
            get
            {
                return homeTelephone;
            }
            set
            {
                homeTelephone = value;
            }
        }

        public string AllTelephones
        {
            get
            {
                if (allTelephones!= null)
                {
                    return CleanUp(allTelephones);
                }
                else
                {
                    return CleanUp(HomeTelephone) + CleanUp(MobileTelephone) + CleanUp(WorkTelephone)+CleanUp(HomeSecondary);
                }
            }
            set
            {
                allTelephones = value;
            }
        }

  
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return EmailCleanUp(allEmails);
                }
                else
                {
                    return EmailCleanUp(Email) + EmailCleanUp(Email2) + EmailCleanUp(Email3);
                }
            }
            set
            {
                allEmails = value;
            }
        }
        private string CleanUp(string telephone)
        {
            if (telephone==null)
            {
                return "";
            }
            else
            {
                return telephone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("\r", "").Replace("\n", "");
            }
        }

        private string EmailCleanUp(string email)
        {
            if (email == null)
            {
                return "";
            }
            else
            {
                return email.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            }
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else return null;
        }

        public string MobileTelephone
        {
            get
            {
                return mobileTelephone;
            }
            set
            {
                mobileTelephone = value;
            }
        }

        public string WorkTelephone
        {
            get
            {
                return workTelephone;
            }
            set
            {
                workTelephone = value;
            }
        }

        public string FaxTelephone
        {
            get
            {
                return faxTelephone;
            }
            set
            {
                faxTelephone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                birthdate = value;
            }
        }
        public string Anniversary
        {
            get
            {
                return anniversary;
            }
            set
            {
                anniversary = value;
            }
        }
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }
        public string AddressSecondary
        {
            get
            {
                return addressSecondary;
            }
            set
            {
                addressSecondary = value;
            }
        }
        public string HomeSecondary
        {
            get
            {
                return homeSecondary;
            }
            set
            {
                homeSecondary = value;
            }
        }
        public string NotesSecondary
        {
            get
            {
                return notesSecondary;
            }
            set
            {
                notesSecondary = value;
            }

        }

        [Column(Name = "firstname")]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        [Column(Name = "lastname")]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        public string Age
        {
            get
            {
                if (age != null)
                {
                    return age;
                }
                else
                {
                    return "("+age+")";
                }
            }
            set
            {
                age = value;
            }
        }
        public string AnniversaryPeriod
        {
            get
            {
                if (anniversaryPeriod != null)
                {
                    return anniversaryPeriod;
                }
                else
                {
                    return "(" + anniversaryPeriod + ")";
                }
            }
            set
            {
                anniversaryPeriod = value;
            }
        }

        
    }
}
