using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedLists
{
    public class DoublyLinkedCell<T>
    {
        public T Value;

        public DoublyLinkedCell<T> Previous;

        public DoublyLinkedCell<T> Next;
    }
}
