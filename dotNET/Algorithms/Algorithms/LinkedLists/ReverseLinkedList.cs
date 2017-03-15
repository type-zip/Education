using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedLists
{
    public static class ReverseLinkedList
    {
        public static Cell<int> GetList()
        {
            Cell<int> root = new Cell<int>();
            Cell<int> previous = root;

            for (int i = 1; i < 10; i++)
            {
                Cell<int> temp = new Cell<int>();
                temp.Value = i;
                previous.Next = temp;
                previous = temp;
            }

            return root;
        }

        public static Cell<int> Reverse(Cell<int> root)
        {
            Cell<int> previous = null;
            Cell<int> following = null;
            
            while(root != null)
            {
                following = root.Next;
                root.Next = previous;
                previous = root;
                root = following;
            }

            return previous;
        }
    }
}
