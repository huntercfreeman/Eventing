using System;
using System.Collections.Generic;

namespace Eventing.Code
{
    public interface ITableRendererState
    {
        public event EventHandler OnNewItemEventHandler;
        public void OnNewItemEventInvoke(object sender, EventArgs e);
        /*
         * If you want to pass a string along with the event do this
         * (also works for any other type)
         public event EventHandler<string> OnNewItemEventHandler;
         public void OnNewItemEventInvoke(object sender, string e); 
         */

        public Person[] GetPeople();
        public void AddPerson(Person person);
    }
}
