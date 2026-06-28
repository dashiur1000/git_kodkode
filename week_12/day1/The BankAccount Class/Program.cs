using BankStern;
using Microsoft.VisualBasic;
using System;
using System.Runtime.CompilerServices;
namespace BankStern;
enum AccountType {Savings, Checking, Business}
class BankAccount
{
    private int _accountNumber { get; }
    private string _ownerName { get; set; }
    private double _balance { get; set; }
    private string _accountType { get; set; }
    private bool _isActive;
    private List<string> _transactionHistory;

    public int AccountNumber { get => _accountNumber; }
    public string OwnerName
    {
        get => _ownerName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                _ownerName = "Unknown";
            else
                _ownerName = value;
        }
    }
    public double Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
                _balance = 0;
            else
                _balance = value;
        }
    }
    public string AccountType
    {
        get => _accountType;
        set
        {
            if (Enum.TryParse<AccountType>(value, true, out _))
            {
                _accountType = value;
            }
            else
                _accountType = "Checking";
        }
    }
    //public bool IsActive
    //{
    //    get => _isActive;
    //    set
    //    {
    //        _isActive = true;
    //    }
    //}

    public BankAccount(int accountNumber, string ownerName, double balance, string accountType)
    {
        _accountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = balance;
        AccountType = accountType;
        _isActive = true;
        _transactionHistory = new List<string>();
    }
    public BankAccount(int accountNumber, string ownerName) : this(accountNumber, ownerName, 0.0, "Checking") { }

    public override string ToString()
        => $"Account #{AccountNumber} | Owner: {OwnerName} | Balance:{Balance:F2} | Type: {AccountType}";
    public void Deposit(double amount)
    {
        if (amount > 0 & _isActive)
        {
            Balance += amount;
            _transactionHistory.Add($"Depositing ${amount} to account {AccountNumber}");
        }
        else
            Console.WriteLine("error!");
    }
    public bool Withdraw(double amount)
    {
        if (amount > 0 & Balance >= amount & _isActive)
        {
            Balance -= amount;
            _transactionHistory.Add($"Withdrawing ${amount} from account {AccountNumber}");
            return true;
        }
        else
        {
            Console.WriteLine("error!");
            return false;
        }
    }
    public void ApplyInterest()
    {
        if (AccountType.ToLower() == "Savings".ToLower())
        {
            Balance *= 1.02;
        }
    }
    public void PrintTransactionHistory()
    {
        for (int i = 0; i < _transactionHistory.Count; i++)
        {
            Console.WriteLine(_transactionHistory[i]);
        }
    }
    public void Activate()
    {
        _isActive = true;
    }
    public void Deactivate()
    {
        _isActive = false;
    }
    public static bool Transfer(BankAccount from, BankAccount to, double amount)
    {
        if (from._isActive == true & to._isActive == true & amount > 0 & from._balance >= amount)
        {
            from.Withdraw(amount);
            to.Deposit(amount);
            from._transactionHistory.Add($"Transfer ${amount} from #{from} to #{to}");
            return true;
        }
        else
        {
            Console.WriteLine("error!");
            return false;
        }
    }
    class check
    {
        static void Main()
        {
            List<BankAccount> Account = new List<BankAccount>();
            Account.Add(new BankAccount(1, "Dudi Stern", 100.0, "Savings"));
            Account.Add(new BankAccount(2, "Miri Stern"));
            Account.Add(new BankAccount(3, "Meir Stern", 50.0, "Business"));
            Account.Add(new BankAccount(4, "Liby Stern"));
            Account.Add(new BankAccount(5, "Unknown", 0.0, "Checking"));
            Account[0].Deposit(50);
            Account[1].Deposit(50);
            Account[2].Withdraw(25);
            Account[3].Deposit(50);
            foreach (BankAccount account in Account)
            {
                { Console.WriteLine(Account); }
                Console.WriteLine("==================");
                Account[4].Deactivate();
                Account[4].Withdraw(25);
                Account[4].Activate();
                Console.WriteLine(Account[0]);
                Console.WriteLine(Account[2]);
                Console.WriteLine("==================");
                for (int i = 0; i < Account.Count; i++)
                {
                    Account[i].ApplyInterest();
                }
                Console.WriteLine("==================");
                Transfer(Account[0], Account[1], 25.5);
                Console.WriteLine(Account[0]);
                Console.WriteLine(Account[1]);
                Account[0].PrintTransactionHistory();
                Console.WriteLine("==================");
                for (int i = 0; i < Account.Count; i++)
                {
                    Console.WriteLine(Account[i]);
                }
            }
            }
        }
    }
