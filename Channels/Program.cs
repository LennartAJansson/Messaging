using Channels;

Sender sender = new Sender();
Listener listener = new Listener(sender);

Task result = listener.ListenAsync();

for (int c = 1; c < 11; c++)
{
  await sender.SendPersonAsync($"Hello, World!", c);
  await sender.SendAgeAsync(c);
}

Task.WaitAll(result);