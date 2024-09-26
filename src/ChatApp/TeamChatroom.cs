namespace ChatApp;

public class TeamChatroom : Chatroom
{
  private readonly List<TeamMember> _members = [];

  public override void Register(TeamMember member)
  {
    member.SetChatRoom(this);
    _members.Add(member);
  }

  public void RegisterMembers(params TeamMember[] members)
  {
    foreach (var member in members)
    {
      Register(member);
    }
  }

  public override void Send(string from, string message)
  {
    foreach (var member in _members)
    {
      if (member.Name == from)
      {
        continue;
      }

      member.Receive(from, message);
    }
  }

  public override void SendTo<T>(string from, string message)
  {
    foreach (var member in _members)
    {
      if (member.Name == from || member is not T)
      {
        continue;
      }

      member.Receive(from, message);
    }
  }
}