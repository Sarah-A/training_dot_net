using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerators
{
    public class MyEnumerable_PersonsCollection //  : IEnumerable
    {
        private List<Person> _persons;

        public MyEnumerable_PersonsCollection()
        {
            _persons = new List<Person>();
        }

        //public MyPersonsEnumerator GetEnumerator()
        //{
        //    return new MyPersonsEnumerator(this);
        //}

        public void AddNewPerson(string name, string surname)
        {
            _persons.Add(new Person(name, surname));
        }

        public void RemovePerson(string name, string surname)
        {
            Person person = new Person(name, surname);

            // todo 
            //_persons.BinarySearch(person, )
            //_persons.Add(new Person(name, surname));
        }

        //public class MyPersonsEnumerator : IEnumerator
        //{
        //    private int _current = -1;
        //    MyEnumerable_PersonsCollection

        //    public MyPersonsEnumerator(MyEnumerable_PersonsCollection persons)
        //    { 
        //        person
        //    }

        //    public Person Current
        //    {
        //        get { return _persons[_current];}
        //    }
        //}
    }

    public class Person : IComparable<Person>
    {
        private string _name;
        private string _surname;

        public Person(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public int CompareTo(Person other)
        {
            return (_name.CompareTo(other._name));
        }

        public void PrintPerson()
        {
            Console.WriteLine("Full Name: {0} {1}", _name, _surname);
        }
    }
}
