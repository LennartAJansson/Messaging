namespace DelegatesAndEvents;
using System;

public class MyEventArgs : EventArgs
{
  public string Message { get; set; }
  public MyEventArgs(string message)
  {
    Message = message;
  }
}
