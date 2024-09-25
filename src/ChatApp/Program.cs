using ChatApp;

var teamChat = new TeamChatroom();

var john = new Developer("John");
var steve = new Developer("Steve");
var jane = new Tester("Jane");
var sarah = new Tester("Sarah");

teamChat.RegisterMembers(john, jane, steve, sarah);

Console.WriteLine("-----");

john.Send("Hey Jane, I've just pushed a new feature.");
jane.Send("Great! I'll test it right away.");

Console.WriteLine("-----");

john.SendTo<Tester>("Hey Testers, could you help me with this bug?");

Console.WriteLine("-----");

sarah.SendTo<Developer>("Hey Developers, could you help me with this bug?");