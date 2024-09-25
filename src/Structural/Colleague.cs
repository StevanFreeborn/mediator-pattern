namespace Structural;

public abstract class Colleague
{
  protected Mediator? _mediator;

  internal void SetMediator(Mediator mediator)
  {
    _mediator = mediator;
  }

  public virtual void Send(string message)
  {
    _mediator?.Send(message, this);
  }

  public abstract void HandleNotification(string message);
}