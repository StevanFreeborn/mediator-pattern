namespace LocationProximity;

public partial class Form1 : Form
{
  private readonly MarkerMediator _mediator = new MarkerMediator();
  private readonly Button? _addButton;

  public Form1()
  {
    InitializeComponent();
    _addButton = new Button
    {
      Text = "Add Marker",
      Dock = DockStyle.Bottom
    };

    _addButton.Click += OnAddClick;

    Controls.Add(_addButton);
  }

  private void OnAddClick(object? sender, EventArgs e)
  {
    var marker = _mediator.CreateMarker();
    Controls.Add(marker);
  }
}