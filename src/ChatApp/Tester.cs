namespace ChatApp;

public class Tester(string name) : TeamMember(name)
{
  public override void Receive(string from, string message)
  {
    Console.Write($"{Name} ({nameof(Tester)}) has received: ");
    base.Receive(from, message);
  }
}