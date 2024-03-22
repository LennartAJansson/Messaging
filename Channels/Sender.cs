namespace Channels;
using System.Threading.Channels;
using System.Threading.Tasks;

public interface ICommand;

public record AddPersonCommand(string Name, int Age) : ICommand;

public record UpdatePersonAgeCommand(int Age): ICommand;

internal class Sender
{
  public Channel<ICommand> CommandChannel { get; set; }

  public Sender() => CommandChannel = Channel.CreateUnbounded<ICommand>();

  public async Task SendPersonAsync(string name, int age)
  {
    await CommandChannel.Writer.WriteAsync(new AddPersonCommand(name,age));
  }
  public async Task SendAgeAsync(int age)
  {
    await CommandChannel.Writer.WriteAsync(new UpdatePersonAgeCommand(age));
  }
}
