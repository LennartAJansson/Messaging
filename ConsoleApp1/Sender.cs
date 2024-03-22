namespace ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void MyDelegate(string s);

internal class Sender
{
  public event MyDelegate MyMessage;
  public event EventHandler MyMessage2;

  //Skicka 
  public void Send(string s)
  {
    MyMessage?.Invoke(s);
    MyMessage2?.Invoke(this, new MyEventArgs(s));
  }
}

internal class Listener1
{
  private readonly Sender c1;

  public Listener1(Sender c1)
  {
    this.c1 = c1;
  }

  public void Start()
  {
    //Attacha lyssnaren till Eventet i Class1
    c1.MyMessage += OnMyMessage;
    c1.MyMessage2 += OnMyMessage2;
  }

  public void Stop()
  {
    //Ta bort lyssnaren från Eventet i Class1
    c1.MyMessage -= OnMyMessage;
    c1.MyMessage2 -= OnMyMessage2;
  }

  //Lyssnare
  public void OnMyMessage(string s)
  {
    Console.WriteLine($"Class2 received {s}");
  }
  private void OnMyMessage2(object? sender, EventArgs e)
  {
    Console.WriteLine($"Class2 received {(e as MyEventArgs).Message} from {sender}");
  }
}


public class MyEventArgs : EventArgs
{
  public string Message { get; set; }
  public MyEventArgs(string message)
  {
    Message = message;
  }
}

internal class Listener2
{
  private readonly Sender c1;

  public Listener2(Sender c1)
  {
    this.c1 = c1;
  }

  public void Start()
  {
    //Attacha lyssnaren till Eventet i Class1
    c1.MyMessage += OnMyMessage;
  }
  public void Stop()
  {
    //Ta bort lyssnaren från Eventet i Class1
    c1.MyMessage -= OnMyMessage;
  }

  //Lyssnare
  public void OnMyMessage(string s)
  {
    Console.WriteLine($"Class3 received {s}");
  }
}