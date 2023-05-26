using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ThreadPoolApp.TaskRun
{
    /// <summary>
    /// The following example illustrates the Run(Action) method. 
    /// It defines an array of directory names and starts a separate task to retrieve the file names in each directory. 
    /// All tasks write the file names to a single ConcurrentBag<T> object. 
    /// The example then calls the WaitAll(Task[]) method to ensure that all tasks have completed, 
    /// and then displays a count of the total number of file names written to the ConcurrentBag<T> object.
    /// </summary>
    public class TaskRunExample
    {
        public static void RunOnSeparateTask()
        {
            var list = new ConcurrentBag<string>();
            string[] dirNames = { ".", ".." };
            var tasks = new List<Task>();
            foreach (var dirName in dirNames)
            {
                Task t = Task.Run(() => {
                    foreach (var path in Directory.GetFiles(dirName))
                        list.Add(path);
                });
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
            foreach (Task t in tasks)
                Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status);

            Console.WriteLine("Number of files read: {0}", list.Count);
        }
    }
}
