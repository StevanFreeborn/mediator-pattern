using Structural;

var mediator = new ConcreteMediator();
var colleague1 = new Colleague1(mediator);
var colleague2 = new Colleague2(mediator);
mediator.Colleague1 = colleague1;
mediator.Colleague2 = colleague2;

colleague1.Send("Hello, Colleague2!");
colleague2.Send("Hello, Colleague1!");