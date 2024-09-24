namespace Structural;

public class Colleague2(Mediator mediator) : Colleague(mediator)
{
  public override void HandleNotification(string message)
  {
    Console.WriteLine($"Colleague2 receives notification message: {message}");
  }
}