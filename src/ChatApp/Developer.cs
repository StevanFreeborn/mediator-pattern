namespace ChatApp;

public class Developer(string name) : TeamMember(name)
{
  public override void Receive(string from, string message)
  {
    Console.Write($"{Name} ({nameof(Developer)}) has received: ");
    base.Receive(from, message);
  }
}
