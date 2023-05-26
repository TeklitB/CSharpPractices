# Threading in C#
## Thread Pool (ThreadPool class)
* When you use thread pool, threads are backgrounded, they are also coming from the thread pool, 
and the threads are also reused.


## Normal Thread (i.e Thread class)
* When you use normal thread, threads are not backgrounded and they are also not coming from the thread pool, 
and the threads are also not reused. Each thread has a unique thread ID.