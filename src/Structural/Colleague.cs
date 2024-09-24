namespace Structural;

public abstract class Colleague(Mediator mediator)
{
  protected Mediator _mediator = mediator;

  public virtual void Send(string message)
  {
    _mediator.Send(message, this);
  }

  public abstract void HandleNotification(string message);
}