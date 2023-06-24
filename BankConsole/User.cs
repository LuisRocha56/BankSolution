using Newtonsoft.Json; 

namespace BankConsole;

public class User
{
    [JsonProperty]
    protected int ID { get; set; }
    [JsonProperty]
    protected string Name { get; set; }
    [JsonProperty]
    protected string email { get; set; }
    [JsonProperty]
    protected DateTime RegisterDate { get; set; }
    [JsonProperty]
    protected decimal Balance { get; set; }

    public User() {}

    #region constructor 1
    /*public User () 
    {
        this.Balance = 1000;
        this.Name = "edson luis";
        this.email = "edsonluis@gmail.com";
        this.RegisterDate = DateTime.Now; 
        this.ID = 001;
    }*/
    #endregion constructor 1
#region constructor 2
    public User(int ID, string name, string email, decimal Balance)
    {
        this.ID = ID;
        this.Name = name;
        this.email = email;
        //SetBalance(Balance);
        this.RegisterDate = DateTime.Now;
    }
#endregion
    public int GetID() 
    {
        return ID;
    }


    public DateTime GetRegisterDate()
    {
        return RegisterDate;
    }
    public virtual void SetBalance(decimal amount)
    {
        decimal quantity = 0;

        if(amount < 0)
        {
            //si el número es negativo el balance es 0
            quantity = 0;
        } else {
            quantity = amount;
        }
        this.Balance += quantity;
    }
   
    public virtual string ShowData() 
    {
        return $"ID: {this.ID}, Nombre: {this.Name}, Correo: {this.email}, Saldo: {this.Balance}, Fecha de registro: {this.RegisterDate.ToShortDateString}";
    }

    public string ShowData(string initialMessage) 
    {
        return $"{initialMessage} -> Nombre: {this.Name}, Correo: {this.email}, Saldo: {this.Balance}, Fecha de registro: {this.RegisterDate.ToShortDateString}";
    }
}