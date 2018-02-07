using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QulixTestTask.Models
{
    public class Company
    {
        private Int32 _id;
        private String _companyName;
        private String _companyType;
        private Int32 _people;

        public Int32 Id { get { return _id; } }

        public String CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public String CompanyType
        {
            get { return _companyType; }
            set { _companyType = value; }
        }

        public Int32 People
        {
            get { return _people; }
            set
            {
                if (value >= 0)
                {
                    _people = value;
                }
                else
                {
                    throw new System.ArgumentException("Parameter must be >= 0", "People");
                }
            }
        }
    }
}