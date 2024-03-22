namespace Channels;
using System;
using System.Threading.Channels;
using System.Threading.Tasks;

internal class Listener(Sender sender)
{
  private readonly ChannelReader<ICommand> reader = sender.CommandChannel.Reader;

  public async Task ListenAsync()
  {
    await foreach (ICommand msg in reader.ReadAllAsync())
    {
      if (msg is AddPersonCommand addPersonCommand)
      {
        Console.WriteLine($"Received (AddPersonCommand): {addPersonCommand}");
      }
      else if (msg is UpdatePersonAgeCommand updatePersonAgeCommand)
      {
        Console.WriteLine($"Received (UpdatePersonAgeCommand): {updatePersonAgeCommand}");
      }
    }
  }
}