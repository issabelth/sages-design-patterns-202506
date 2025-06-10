// Zasada segregacji interfejsów (Interface Segregation Principle) – ISP

// Kod nie powinien być zmuszany do polegania na metodach, których nie używa.


// Przykład łamiący zasadę segregacji interfejsów

IATM atm = new SecondATM(1000);

atm.Withdraw(100);

atm.Deposit(50);

var balance = atm.CheckBalance();

Console.WriteLine(balance);


// Złe podejście – wymuszanie nieużywanych metod:
public interface IATM
{
    bool Withdraw(decimal amount); // Wypłata
    void Deposit(decimal amount); // Wpłata
    decimal CheckBalance();
}

public class FirstATM : IATM
{
    private decimal balance;

    public FirstATM(decimal initialBalance)
    {
        balance = initialBalance;
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

public class SecondATM : IATM
{
    private decimal balance;

    public SecondATM(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public decimal CheckBalance()
    {
        return balance;
    }

    public void Deposit(decimal amount)     // <-- problem, wymuszenie nieużywanych mnetod
    {
        throw new NotSupportedException();   
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



