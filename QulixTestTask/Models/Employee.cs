using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QulixTestTask.Models
{
    public class Employee
    {
        private Int32 _id;
        private String _firstName;
        private String _lastName;
        private String _patronymic;
        private DateTime _recruitmentDate;
        private String _position;
        private String _company;

        public Int32 Id { get { return _id; } }

        public String FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public String Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; }
        }

        public DateTime RecruitmentDate
        {
            get { return _recruitmentDate; }
            set { _recruitmentDate = value; }
        }

        public String Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public String Company
        {
            get { return _company; }
            set { _company = value; }
        }

        public Employee(Int32 Id, String firstName, String lastName, String patronymic, DateTime recruitmentDate, String position, String company)
        {
            _id = Id;
            _firstName = firstName;
            _lastName = lastName;
            _patronymic = patronymic;
            _recruitmentDate = recruitmentDate;
            _position = position;
            _company = company;
        }

        public Employee() { } //пустой конструктор для работы лявбды в "AddEmployee"
    }
}