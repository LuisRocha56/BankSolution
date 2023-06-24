namespace BankConsole;

public class Employee : User, IPerson //los dos puntos significan que employee es hija de user
{
    public string Department {get; set; }

    public Employee () {}

    public Employee(int ID, string name, string email, decimal Balance, string Department) : base(ID, name, email, Balance)
    {
        this.Department = Department;
        SetBalance(Balance);
    }

    public override void SetBalance(decimal amount)
    {
        base.SetBalance(amount);
            if(Department.Equals("IT"))
            {
                Balance += (amount * 0.05m);
            }
    }

    public override string ShowData()
    {
        return base.ShowData() + $", Departamento: {this.Department}";
    }

    public string GetName()
    {
        return Name;
    }

    public string GetCountry()
    {
        throw new NotImplementedException();
    }
}