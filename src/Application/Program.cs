using Application.repos;

var appManage = new ManageVessel();

var menuOperations = @"
---------------------Managing Vessels---------------------
Select 1 operation:
1.- Add vessel
2.- Show vessels
3.- Edit vessel
4.- Delete vessel
5.- Exit
";

Console.WriteLine(menuOperations);

var isProgramOn = true;
var messageOptionNotAvailable = @"
Option not available!!
try again...

Press any key to continue...
";

while (isProgramOn)
{
    var sOption = Console.ReadLine();
    int nOption;

    bool success = int.TryParse(sOption, out nOption);
    if (!success)
    {
        Console.WriteLine(messageOptionNotAvailable);
        Console.ReadLine();
        Console.Clear();
    }
    else
    {
        switch (nOption)
        {
            case 1:
                Console.Clear();
                appManage.ProgrammAddingVessel();
                break;
            case 2:
                Console.Clear();
                appManage.ProgrammGetVessels();
                break;
            case 3:
                Console.Clear();
                appManage.ProgrammUpdateVessel();
                break;
            case 4:
                Console.Clear();
                appManage.ProgrammDeleteVessel();
                break;
            case 5:
                Console.WriteLine("App is closing...");
                isProgramOn = false;
                break;
            default:
                Console.WriteLine(messageOptionNotAvailable);
                Console.ReadLine();
                Console.Clear();
                break;
        }
    }

    if (nOption != 5)
        Console.WriteLine(menuOperations);
}
