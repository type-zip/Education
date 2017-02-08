using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitPlayground
{
    public class AsyncStringProcessor : StringProcessor
    {
        /// <summary>
        /// Synchronous method that runs on the main thread and starts the simple async/await example
        /// </summary>
        override public string Process()
        {

            // Call to CreateValueAsync() method and assing the task object it will return to a local variable
            Task<string> stringWithValueTask = CreateStringWithValueAsync();
            // At this point SimpleExample is suspended until the CreateStringWithValueAsync() reaches the await statement, then the execution
            // of SimpleExample() is continued while CreateStringWithValueAsync() waits for ProcessData() to complete on another thread

            // Here we can perform some actions that will happen on the main thread          

            // Obtain the result value. If task's isn't completed at this point, the execution of a main thread is suspended unil the task's thread
            // is completed.
            Console.WriteLine(stringWithValueTask.Result);
            return stringWithValueTask.Result;
        }


        /// <summary>
        /// An asynchronous method that awaits for some (potentially) asynchronous operation
        /// and performs some actions with operation's result
        /// </summary>
        private async Task<string> CreateStringWithValueAsync()
        {
            /*
             * I find this function somewhat confusing because it appears that the asynchronous operation whose result I'm
             * interested in happens in ProcessData() method and not in CreateStringWithValueAsync() therefore rendering the latter
             * as some sort of seemingly exessive wrapping over the TAP
             */

            // A string variable that will hold result of asynchronous opertaion
            string resultString = "The result of calculation is";

            // Call to ProcessData() method and assig the Task object it will return to a local variable. At this point 
            // a new thead for the operation is created (or not, it is irrelevant for the current example) inside the ProcessData() function
            Task<int> calculationResult = ProcessData();  // A NEW THREAD INSIDE THE ProcessData() IS CREATED

            // Perform some operation over the string while ProcessData() is busy
            resultString += " - ";

            // Obtain the value of task stored in calculationResult and add it to the string
            // At this point CreateStringWithValueAsync will be suspended until the ProcessData() returns value and
            // the execution will return to the SimpleExample()
            resultString += await calculationResult;
            // --------------------- EVERYTHING PAST THIS LINE CONTINUES ON THE TASK'S THREAD ---------------------

            // Once ProcessData() is completed, the execution of CreateStringWithValueAsync is resumed (even if it's result isn't yet requested by SimpleExample())
            // on the task's thread, independently from the main thread that may or may not wait for the task's value at this point

            // We're free to perform other operations over the calculationResult before we'll return the value from this
            // method, implicitly setting the value of the task captured in SomeExample()'s stringWithValueTask variable
            return resultString;
        }

        /// <summary>
        /// An asynchronous method that simulates some sort of operation which long-lievity and tendency to suspend the execution of the
        /// program was the reason beghind all this asynchronous stuff. This is the point where the another thread is created and the actual
        /// calculation if performed
        /// </summary>
        private Task<int> ProcessData()
        {
            // Task is instantly shcheduled for execution upon its creaion, thus spawning new thread
            return Task<int>.Run(() => { return 2 * 2; }); // A NEW THREAD IS CREATED HERE
        }
    }
}
