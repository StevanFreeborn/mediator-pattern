using Structural;

var mediator = new ConcreteMediator();
var colleague1 = new Colleague1();
var colleague2 = new Colleague2();
mediator.Register(colleague1);
mediator.Register(colleague2);

colleague1.Send("Hello, Colleague2!");
colleague2.Send("Hello, Colleague1!");