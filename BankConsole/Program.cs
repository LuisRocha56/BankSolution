using System.Text.RegularExpressions;
using BankConsole;

if (args.Length==0)
    EmailServeice.SendEmail();
else
   ShowMenu();


void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Selecciona una opción:");
    Console.WriteLine("1. Crea un Usuario nuevo");
    Console.WriteLine("2. Elimina un Usuario existente");
    Console.WriteLine("3. Salir");

    int option=0;
    do
    {
        string input = Console.ReadLine();

        if(!int.TryParse(input, out option)|| option<=0|| option>3)
            Console.WriteLine("ingresa una opcion válida (1, 2 o 3).");
        else if(option>3)
            Console.WriteLine("ingresa una opcion válida invalida (1, 2 o 3).");
    }while(option ==0 || option >3);

    switch(option)
    {
        case 1:
            CreateUser();
        break;
        case 2:
            DeleteUser();
        break;
        case 3:
            Environment.Exit(0);
        break;
    }
}

void CreateUser()
{
    Console.Clear();
    Console.WriteLine("Ingresa la informacion del usuario:");

    Console.Write("ID: ");
    int ID = int.Parse(Console.ReadLine());

    Console.Write("Nombre: ");
    string name= Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    Console.Write("Saldo: ");
    decimal balance = decimal.Parse(Console.ReadLine());

    Console.Write("Escribe 'c' si el usuario es cliente, 'e' si es empleado: ");
    char userType = char.Parse(Console.ReadLine());

    User newUser;

    if(userType.Equals('c'))
    {
        Console.Write("Regimen Fiscal: ");
        char TaxRegime= char.Parse(Console.ReadLine());

        newUser = new Client(ID, name, email, balance, TaxRegime);
    }
    else
    {
        Console.Write("Departamento: ");
        string Department = Console.ReadLine();

           newUser = new Employee(ID, name, email, balance, Department);
    }

    Storage.AddUser(newUser);

    Console.WriteLine("Usuario creado.");
    Thread.Sleep(2000);
    ShowMenu();
}

void DeleteUser()
{
    Console.Clear();
   
    Console.Write("Ingresa el ID del usuario a eliminar: ");
    int ID = int.Parse(Console.ReadLine());

    string result = Storage.DeleteUser(ID);

    if(result.Equals("Success"))
    {
        Console.Write("Usuario eliminado.");
        Thread.Sleep(2000);
        ShowMenu();
    }

}