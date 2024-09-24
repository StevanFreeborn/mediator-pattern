namespace Structural;

public class Colleague1(Mediator mediator) : Colleague(mediator)
{
  public override void HandleNotification(string message)
  {
    Console.WriteLine($"Colleague1 receives notification message: {message}");
  }
}
