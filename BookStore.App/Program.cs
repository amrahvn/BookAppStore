
using BookService.Implementations;

MenuServices menuServices = new MenuServices();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("1.As Admin");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("2.As User");

string reques=Console.ReadLine();

if (reques == "1")
{
    bool result = await menuServices.Login();

    while (!result)
    {
        result = await menuServices.Login();

        if (!result)
        {
            Console.WriteLine("2.Return as User");
            reques = Console.ReadLine();

            if(reques == "2")
            {
                result=true;
            }

        }
    }
}


if (menuServices.IsAdmin)
{
    menuServices.ShowMenuAdmin();
}
else
{
    menuServices.ShowMenuUser();
}




