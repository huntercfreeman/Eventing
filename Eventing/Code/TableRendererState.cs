using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventing.Code
{
    public class TableRendererState : ITableRendererState
    {
        private List<Person> _people = new List<Person>
        {
            new Person { FirstName = "Hunter", LastName = "Freeman" },
            new Person { FirstName = "Joseph", LastName = "Dark" },
            new Person { FirstName = "Bernard", LastName = "Farrell" }
        };

        public event EventHandler OnNewItemEventHandler;

        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        public Person[] GetPeople()
        {
            // the private field would be passed by reference
            // if not for .ToArray thereby it would be public
            // in a sense that they then would have the
            // reference to the object
            return _people.ToArray();
        }

        public void OnNewItemEventInvoke(object sender, EventArgs e)
        {
            // EventHandler<string> handler = OnNewItemEventHandler;
            // if you want to pass a string
            EventHandler handler = OnNewItemEventHandler;

            handler?.Invoke(sender, e);
        }
    }
}
