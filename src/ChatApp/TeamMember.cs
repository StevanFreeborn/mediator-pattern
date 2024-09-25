namespace ChatApp;

public abstract class TeamMember(string name)
{
  private Chatroom? _chatroom;
  public string Name { get; } = name;

  internal void SetChatRoom(Chatroom chatroom)
  {
    _chatroom = chatroom;
  }

  public void Send(string message)
  {
    _chatroom?.Send(Name, message);
  }

  public void SendTo<T>(string message) where T : TeamMember
  {
    _chatroom?.SendTo<T>(Name, message);
  }

  public virtual void Receive(string from, string message)
  {
    Console.WriteLine($"{from}: '{message}'");
  }
}