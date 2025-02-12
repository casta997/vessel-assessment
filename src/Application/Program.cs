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
            Console.Write("Insert IMO code:");
            var imoCode = Console.ReadLine();
            if (programmVessel.checkImoNumber(imoCode))
            {
                programmVessel.addVessel(imoCode);
                Console.WriteLine("Vessel added");
            }
            break;
        case 2:
            Console.Write("Insert id of the interested vessel: ");
            var idVesselInput = int.Parse(Console.ReadLine());
            var vessel = programmVessel.vessel(idVesselInput);
            Console.WriteLine(
                $@"
Information of the selected vessel:
    {vessel}
"
                );
            break;
        case 3:
            Console.WriteLine("Vessel edited!");
            break;
        case 4:
            Console.WriteLine("Vessel deleted");
            break;
        case 5:
            var  vessels = programmVessel.Vessels;
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
