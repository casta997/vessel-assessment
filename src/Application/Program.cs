using Application.entities;
using Application.repos;

var appManage = new ManageVessel();

var isProgramOn = true;

appManage.Vessels.Add(new Vessel(100, "9647227"));
appManage.Vessels.Add(new Vessel(101, "9647228"));
appManage.Vessels.Add(new Vessel(102, "9647229"));
appManage.Vessels.Add(new Vessel(103, "9647230"));

appManage.ProgrammGetVessels();

appManage.BreakConcludeOperation("");

while (isProgramOn)
{
    Console.WriteLine(@"
---------------------Managing Vessels---------------------
Select 1 operation:
C.- Add vessel
R.- Show vessels
U.- Edit vessel
D.- Delete vessel
e.- Exit
");

    var characterInput = Console.ReadKey().KeyChar;
    Console.Clear();

    switch (characterInput) 
    {
        case 'C':
            appManage.ProgrammAddingVessel();
            break;
        case 'R':
            appManage.ProgrammGetVessels();
            appManage.BreakConcludeOperation("");
            break;
        case 'U':
            appManage.ProgrammUpdateVessel();
            break;
        case 'D':
            appManage.ProgrammDeleteVessel();
            break;
        case 'e':
            appManage.BreakConcludeOperation("App is closing...");
            isProgramOn = false;
            break;
        default:
            appManage.BreakConcludeOperation("Option not available!!\ntry again...");
            break;
    }
}
