using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitPlayground
{
    public class TaskStringProcessor : StringProcessor
    {
        public override string Process()
        {
            Task<int> valueTask = ProcessData();
            string resultString = "The result of calculation is - ";
            resultString += valueTask.Result;

            Console.WriteLine(resultString);
            return resultString;
        }

        private Task<int> ProcessData()
        {
            return Task.Run(() => { return 2 * 2; });
        }
    }
}
