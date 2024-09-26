namespace LocationProximity;

public class MarkerMediator
{
  private readonly List<Marker> _markers = [];

  public Marker CreateMarker()
  {
    var m = new Marker();
    m.SetMediator(this);
    _markers.Add(m);
    return m;
  }

  public void Send(Point location, Marker marker)
  {
    foreach (var m in _markers)
    {
      if (m != marker)
      {
        m.Receive(location);
      }
    }
  }
}

public class Marker : Label
{
  private MarkerMediator? _mediator;
  private Point _mouseDownLocation;

  public Marker()
  {
    Text = "{Drag me}";
    TextAlign = ContentAlignment.MiddleCenter;
    MouseDown += OnMouseDown;
    MouseMove += OnMouseMove;
  }

  internal void SetMediator(MarkerMediator mediator)
  {
    _mediator = mediator;
  }

  private void OnMouseDown(object? sender, MouseEventArgs e)
  {
    if (e.Button is not MouseButtons.Left) 
    {
      return;
    }

    _mouseDownLocation = e.Location;
  }

  private void OnMouseMove(object? sender, MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Left)
    {
      Text = Location.ToString();
      Left = e.X + Left - _mouseDownLocation.X;
      Top = e.Y + Top - _mouseDownLocation.Y;
      _mediator?.Send(Location, this);
    }
  }

  public void Receive(Point location)
  {
    var distance = Math.Sqrt(
      Math.Pow(Location.X - location.X, 2) + Math.Pow(Location.Y - location.Y, 2)
    );
    
    if (distance < 100 && BackColor != Color.Red)
    {
      BackColor = Color.Red;
    }
    else if (distance >= 100 && BackColor != Color.Green)
    {
      BackColor = Color.Green;
    }
  }
}