# Main Takeaways
## Threading in C#
### Thread Pool (ThreadPool class)
* When you use thread pool, threads are backgrounded, they are also coming from the thread pool, 
and the threads are also reused.


### Normal Thread (i.e Thread class)
* When you use normal thread, threads are not backgrounded and they are also not coming from the thread pool, 
and the threads are also not reused. Each thread has a unique thread ID.

### SemaphoreSlim Class
We use SemaphoreSlim instance to limit the concurrent threads that can access a shared resource in a multi-threaded environment. 
If threads trying to access a resource are more than the declared limit, only limited threads will be granted access and others will have to wait.