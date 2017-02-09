# Description
The point of this project was (apart from gaining understaing on how git would react to various changes happening at the remote branches) to finally figure out how exactly async/await keywords should be used and what advantages they provide over the TAP.

## Async keyword usefulness example
http://stackoverflow.com/a/18982576
Turns out that while the benefits of async/await are not not really visible in a HelloWorld-tier project, they can significantly simplify the code even in a slighttly more complex scenario.

## A good intro into async and await by Stephen Cleary
http://blog.stephencleary.com/2012/02/async-and-await.html
>I like to think of “await” as an “asynchronous wait”. That is to say, the async method pauses until the awaitable is complete (so it waits), but the actual thread is not blocked (so it’s asynchronous).
