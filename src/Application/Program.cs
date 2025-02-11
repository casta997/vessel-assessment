// See https://aka.ms/new-console-template for more information
using Application.repos;

var programmVessel = new ManageVessel();

Console.WriteLine(@"
---------------------Managing Vessels---------------------
Select 1 operation:
1.- Add vessel
2.- Show vessel
3.- Edit vessel
4.- Delete vessel
5.- Exit
");

var nOption = 0;

while (nOption != 5)
{
    nOption = int.Parse(Console.ReadLine());

    switch (nOption)
    {
        case 1:
            Console.WriteLine("Vessel added");
            break;
        case 2:
            Console.WriteLine("Showing vessel");
            break;
        case 3:
            Console.WriteLine("Vessel edited!");
            break;
        case 4:
            Console.WriteLine("Vessel deleted");
            break;
        case 5:
            Console.WriteLine("Finish program");
            break;
        default:
            Console.WriteLine("Option not available!");
            break;
    }

}
