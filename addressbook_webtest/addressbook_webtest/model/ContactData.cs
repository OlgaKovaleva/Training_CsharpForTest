using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
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

    

        public ContactData (string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

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

    }
}
