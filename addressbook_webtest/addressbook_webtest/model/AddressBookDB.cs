using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAddressbookTests
{
   public class AddressBookDB:LinqToDB.Data.DataConnection

    {
        public AddressBookDB(): base("AddressBook") { } //вызвать конструктор базового класса и задать имя базы данных

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } } //метод, который возвращает таблицу данных GroupData, только геттер который возвращает набор данных 

        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }
        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); }
}
    }
}
