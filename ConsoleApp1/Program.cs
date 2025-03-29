using Business;
using Data;

var robot = new Services(5,5);

Console.WriteLine("Robot Simulator....");

Console.WriteLine("Enter First Commands in this format: 'PLACE X,Y,F - PLACE 0,0,0 => 0,0,North");
var inp = Console.ReadLine();
if (string.IsNullOrWhiteSpace(inp))return;
var cmd = inp.Split(' ');

while (cmd[0] != "PLACE")
{
    Console.WriteLine("Enter First Commands in this format: 'PLACE X,Y,F - PLACE 0,0,0 => 0,0,North");
    inp = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(inp)) return;
    cmd = inp.Split(' ');

}

var command = cmd[1].Split(',');
if(command.Length < 2)
{
    Console.WriteLine("Invalid command entered.. Taking default... PLACE 0,0,0");
    robot.Place(0, 0, 0);
}
else
if (string.IsNullOrWhiteSpace(command[0]) || string.IsNullOrWhiteSpace(command[1]) || string.IsNullOrWhiteSpace(command[2]))
{
    Console.WriteLine("Invalid command entered.. Taking default... PLACE 0,0,0");
    robot.Place(0, 0, 0);
}
else
robot.Place(int.Parse(command[0]), int.Parse(command[1]), int.Parse((command[2])));

Console.WriteLine("Enter any Commands: 'PLACE X,Y,F'/MOVE/LEFT/RIGHT/REPORT");

while (true)
{
    var input = Console.ReadLine().ToUpper();

    switch (input)
    {
        case "PLACE":
            var parameters = command[1].Split(',');
            robot.Place(int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse((command[2])));
            break;
        case "MOVE": robot.Move(); 
            break;
        case "LEFT": robot.TurnLeft(); 
            break;
        case "RIGHT": robot.TurnRight();
            break;
        case "REPORT": Console.WriteLine(robot.Report()); break;
        default:
            Console.WriteLine("Invalid command!!!");
            break;
    }
}
