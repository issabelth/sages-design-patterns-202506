// Zasada segregacji interfejsów (Interface Segregation Principle) – ISP

// Kod nie powinien być zmuszany do polegania na metodach, których nie używa.


// Podział interfejsów

var atm = new SecondATM(1000);

atm.Withdraw(100);

if (atm is IDeposit deposit)
{
    deposit.Deposit(50);
}
else
{
    Console.WriteLine("Brak możliwości wpłaty");
}

var balance = atm.CheckBalance();

Console.WriteLine(balance);


// Złe podejście – wymuszanie nieużywanych metod:
[Obsolete]
public interface IATM : IWidthdraw, IDeposit, IBalance
{
   
  
}

public interface IWidthdraw
{
    bool Withdraw(decimal amount); // Wypłata
}

public interface IDeposit
{
    void Deposit(decimal amount); // Wpłata
}

public interface IBalance
{
    decimal CheckBalance();
}

public abstract class ATM : IWidthdraw, IDeposit, IBalance
{
    protected decimal balance;

    protected ATM(decimal balance)
    {
        this.balance = balance;
    }

    public decimal CheckBalance()
    {
        return balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine("Deposit successful. New Balance: " + balance);
        }
        else
        {
            Console.WriteLine("Invalid amount for deposit.");
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        else
        {
            Console.WriteLine("Insufficient funds or invalid amount.");
            return false;
        }
    }
}

public class FirstATM : ATM, IWidthdraw, IDeposit, IBalance
{
    public FirstATM(decimal initialBalance)
        : base(initialBalance)
    {
    }

   
}

public class SecondATM : ATM, IWidthdraw, IBalance
{
    public SecondATM(decimal initialBalance)
        : base(initialBalance)
    {
    }
}



