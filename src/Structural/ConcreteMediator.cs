namespace Structural;

public class ConcreteMediator : Mediator
{
  private readonly List<Colleague> _colleagues = [];

  public void Register(Colleague colleague)
  {
    colleague.SetMediator(this);
    _colleagues.Add(colleague);
  }

  public T CreateColleague<T>() where T : Colleague, new()
  {
    var colleague = new T();
    colleague.SetMediator(this);
    Register(colleague);
    return colleague;
  }

  public override void Send(string message, Colleague colleague)
  {
    _colleagues
      .Where(c => c != colleague)
      .ToList()
      .ForEach(c => c.HandleNotification(message));
  }
}