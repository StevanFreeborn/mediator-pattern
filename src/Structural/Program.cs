using Structural;

var mediator = new ConcreteMediator();
var colleague1 = mediator.CreateColleague<Colleague1>();
var colleague2 = mediator.CreateColleague<Colleague2>();

colleague1.Send("Hello, Colleague2!");
colleague2.Send("Hello, Colleague1!");