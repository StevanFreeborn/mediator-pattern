using MediatedAPI.Data;
using MediatedAPI.Models;

using MediatR;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(
  config => config.RegisterServicesFromAssemblyContaining<Program>()
);

builder.Services.AddDbContext<ContactsContext>(options =>
  options.UseInMemoryDatabase("Contacts")
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetRequiredService<ContactsContext>();
await context.Database.EnsureCreatedAsync();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.MapGet("/contacts/{id}", async (int id, IMediator mediator) =>
{
  var contact = await mediator.Send(new Query { Id = id });
  return contact is null ? Results.NotFound() : Results.Ok(contact);
});

app.UseHttpsRedirection();

app.Run();

class Query : IRequest<Contact> 
{ 
  public int Id { get; set; }
}

class ContactHandler(ContactsContext context) : IRequestHandler<Query, Contact?>
{
  private readonly ContactsContext _context = context;

  public async Task<Contact?> Handle(Query request, CancellationToken cancellationToken)
  {
    return await _context.Contacts.FindAsync([request.Id], cancellationToken);
  }
}