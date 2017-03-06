using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceTest
{
    interface IController<in TControlled> where TControlled : new()
    {
        bool CreateControlled(TControlled controlled);
    }

    class Controller<A> : IController<A> where A : new()
    {
        public A CreateControlled()
        {
            throw new NotImplementedException();
        }
    }

    class BaseControlled
    { }

    class SpecializedControlled : BaseControlled
    { }

    class Program
    {
        static void Main(string[] args)
        {
            IController<BaseControlled> superInterface = new Controller<>();
            IController<object> childInterface = new Controller<object>();
            childInterface = superInterface;
        }
    }
}
