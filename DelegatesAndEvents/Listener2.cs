namespace DelegatesAndEvents;
using System;

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
    Console.WriteLine($"Listener2 received {s}");
  }

  private void OnMyMessage2(object? sender, EventArgs e)
  {
    Console.WriteLine($"Listener2 received {(e as MyEventArgs).Message} from {sender}");
  }
}