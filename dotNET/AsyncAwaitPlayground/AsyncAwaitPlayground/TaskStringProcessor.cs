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
            Console.WriteLine("> TaskStringProcessor");

            Task<int> valueTask = ProcessData();
            Console.WriteLine($"valueTask ID: {valueTask.Id}");

            string resultString = "The result of calculation is - ";
            resultString += valueTask.Result;

            Console.WriteLine(resultString);
            return resultString;
        }

        // This method might be moved parent class but I'll leave it here for example clarification
        private Task<int> ProcessData()
        {
            Task<int> processDataTask = Task.Run(() => { return 2 * 2; });
            Console.WriteLine($"processDataTask ID: {processDataTask.Id}");
            return processDataTask;
        }
    }
}
