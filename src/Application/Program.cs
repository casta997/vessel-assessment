// See https://aka.ms/new-console-template for more information
using Application.repos;

var appManage = new ManageVessel();

Console.WriteLine(@"
---------------------Managing Vessels---------------------
Select 1 operation:
1.- Add vessel
2.- Show vessel
3.- Edit vessel
4.- Delete vessel
5.- List vessel
Press any other number to exit!
");

var isProgramOn = true;

while (isProgramOn)
{
    var nOption = int.Parse(Console.ReadLine());

    switch (nOption)
    {
        case 1:
            appManage.ProgrammAddingVessel();
            break;
        case 2:
            appManage.ProgrammGetVessel();
            break;
        case 3:
            Console.WriteLine("Vessel edited!");
            break;
        case 4:
            Console.WriteLine("Vessel deleted");
            break;
        case 5:
            var  vessels = appManage.Vessels;
            foreach (var item in vessels)
            {
                Console.WriteLine(item.ToString());
            }

            break;
        case 6:
            
        default:
            Console.WriteLine("Finish program");
            isProgramOn = false;
            break;
    }

}
