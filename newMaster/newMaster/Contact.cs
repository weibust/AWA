using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newMaster
{
    public class Contact
    {
        #region Attributes
        private string id;
        private string firstname;
        private string lastname;
        //private string birthday;
        //private string bnr;
        #endregion

        #region Properties
        public string ID
        {
            get { return this.id; }
        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        //public string Birthday
        //{
        //    get { return this.birthday; }
        //    set { this.birthday = value; }
        //}

        //public string Bnr
        //{
        //    get { return this.bnr; }
        //    set { this.bnr = value; }
        //}
        #endregion

        #region Constructor
        public Contact(string id, string firstname, string lastname)
        {
            this.id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            //this.Birthday = birthday;
            //this.Bnr = bnr;
        }
        #endregion
    }
}