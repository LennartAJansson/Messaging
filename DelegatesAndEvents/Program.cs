using DelegatesAndEvents;

using static System.Console;

var sender = new Sender();
var listener1 = new Listener1(sender);
var listener2 = new Listener2(sender);
listener1.Start();
sender.Send("Hello, World!");
listener2.Start();
sender.Send("Hello, World second time!");
listener1.Stop();
sender.Send("Hello, World third time!");
listener2.Stop();

//Show an example of a lambda expression that takes a string as a parameter and writes it to the console.
sender.MyMessage += (s) => WriteLine($"Lambda received {s}");

//Show an example of Action that takes a string as a parameter and writes it to the console.
Action<string> action = (s) => WriteLine($"Action received {s}");
action.Invoke("Hello world");

//Show an example of Func that takes a string as a parameter and returns a string.
Func<string, string> func = (s) => s;

//Show an example of a basic messagehandler

