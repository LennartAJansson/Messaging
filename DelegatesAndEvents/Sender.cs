namespace DelegatesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void MyDelegate(string s);

internal class Sender
{
  //Custom event based on delegate MyDelegate
  public event MyDelegate MyMessage;
  //Default system event based on EventHandler
  public event EventHandler MyMessage2;

  //Skicka 
  public void Send(string s)
  {
    MyMessage?.Invoke(s);
    MyMessage2?.Invoke(this, new MyEventArgs(s));
  }
}
