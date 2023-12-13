// See https://aka.ms/new-console-template for more information
using System;

public class cardHolder 
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance; 

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one");
            Console.WriteLine("1. Deposit ");
            Console.WriteLine("2. Withdraw ");
            Console.WriteLine("3. Show Balance ");
            Console.WriteLine("4. Exit ");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you, your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw?");
            double withdrawal = Double.Parse(Console.ReadLine());

            //CHECK IF USER HAS ENOUGH MONEY

            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient funds");
            } 
            else 
            {
                double newBalance = currentUser.getBalance() - withdrawal;
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you, your new balance is: " + currentUser.getBalance());
            }

        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is:" + currentUser.getBalance());
        }

        List<cardHolder>cardHolders = new List<cardHolder>(); 
        cardHolders.Add(new cardHolder("001", 1234, "Alex", "Smith", 90.10));
        cardHolders.Add(new cardHolder("002", 1234, "Bob", "Smith", 100.11));
        cardHolders.Add(new cardHolder("003", 1234, "Caleb", "Smith", 900.20));
        cardHolders.Add(new cardHolder("004", 1234, "Donny", "Smith", 301.07));

        //PROMPT USER

        Console.WriteLine("please insert debt card");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try 
            {
                debitCardNum = Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser !=null) { break; }
                else {Console.WriteLine("Card not recognized. Please try again");} 
            }
            catch 
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        //CONFIRM PIN NOW
        Console.WriteLine("Please enter your pin");
        int userPin = 0;
        while(true)
        {
            try 
            {
                userPin = int.Parse(Console.ReadLine());
                //check against our db
                if(currentUser.getPin() == userPin) { break; }
                else {Console.WriteLine("Card not recognized. Please try again");} 
            }
            catch 
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }
        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {

            }
            if(option == 1 ) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser);}
            else if (option == 3) { balance(currentUser);}
            else if (option == 4) { break;}
            else {option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Have a nice day!");
    }
}