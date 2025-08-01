namespace View;

using System.Reflection.Emit;
using Controller;
using Model;

class ConsoleView
{
    private static readonly DiceStore store = Model.DiceStore.Instance; 
    public void WelcomeView()
    {
        Console.WriteLine("Let's determine who makes the first move.");
    }

    public void SecretWordView() {
        Console.WriteLine("Firstly, let's think a new secret word for for fair game");
        string secretWord = "";
        try
        {
            secretWord = Console.ReadLine();
            Controller.SetSecretWord(secretWord);
        }
        catch
        {
            Console.WriteLine("Error! Invalid input");
        }
    }

    public void FirstMoveView() {
        Model.FirstMove.generateComputerChoice(0, 2);
        Model.Encryption.GenerateHMAC(Model.FirstMove.getComputerChoice());
        Console.WriteLine("I selected a random value in the range 0..1 " + Model.Encryption.GetHMAC() + ". ");
        Console.WriteLine("Try to guess my selection.\n 0 - 0 \n 1 - 1 \n X - exit \n ? - help");
        Console.Write("Your selection: ");
        string input = "";
        try
        {
            input = Console.ReadLine();
            Controller.SetChoice(input);
        }
        catch
        {
            Console.WriteLine("Error! Invalid input");
        }

        Console.WriteLine("My selection: " + Model.FirstMove.getComputerChoice());

        if (Model.FirstMove.getUserChoice() == Model.FirstMove.getComputerChoice()) {
            Console.WriteLine("It's your turn");
            Controller.AddUserPlayerFirst();
        }
        else {
            Console.WriteLine("It's mine turn");
            Controller.AddVirtualPlayerFirst();
        }

    }

    public void DiceChooseView() {
        if(Model.DiceGame.Instance.IsFirstPlayerVirtual()) {
            Model.VirtualPlayer.GetInstance().SetDice();
            Console.WriteLine("I make the first move and choose the " + Model.VirtualPlayer.GetInstance().GetDiceString() + " dice");
            Console.WriteLine("Now your turn select dice");
            Console.WriteLine("Choose your dice:");
            for (int i = 0; i < Model.DiceStore.Instance.DiceCount; i++)
            {
                Console.Write(i + " ");
                Model.DiceStore.Instance.PrintDice(i);
                Console.WriteLine();
            }
            Console.WriteLine("Your selection");
            string dice = Console.ReadLine();
            Controller.SetDice(dice);
        }
        else {
            Console.WriteLine("You make first move, choose dice");
            for (int i = 0; i < Model.DiceStore.Instance.DiceCount; i++)
            {
                Console.Write(i + " ");
                Model.DiceStore.Instance.PrintDice(i);
                Console.WriteLine();
            }
            string dice = Console.ReadLine();
            Controller.SetDice(dice);
            Model.VirtualPlayer.GetInstance().SetDice();
        }

    }

    public void DiceGameView() {
        while(!Model.DiceGame.Instance.isGameOver()) {
            if (Model.DiceGame.Instance.IsFirstPlayerVirtual()) {
                Console.WriteLine("It's time for my roll.");
                Controller.SetComputerChoice();
                Console.WriteLine("I selected a random value in the range 0..5 ");
                Console.WriteLine("0 - 0");
                Console.WriteLine("1 - 1");
                Console.WriteLine("2 - 2");
                Console.WriteLine("3 - 3");
                Console.WriteLine("4 - 4");
                Console.WriteLine("5 - 5");
                Console.WriteLine("X - exit");
                Console.WriteLine("? - Help");
                Console.Write("Your selection: ");
                string userChoice = Console.ReadLine();
                Controller.SetUserChoice(userChoice);
                Console.WriteLine("My number is " + Model.VirtualPlayer.GetInstance().GetComputerChoice());
                Console.WriteLine("The fair number generation result is " + userChoice + " + " + Model.VirtualPlayer.GetInstance().GetComputerChoice() + " = " +  + Model.VirtualPlayer.GetInstance().GetFairNumber() + " (mod 6)");
                VirtualPlayer.GetInstance().RollDice();
                Console.WriteLine("My roll result " + Model.VirtualPlayer.GetInstance().GetFace());

                Console.WriteLine("It's time for your roll.");
                Controller.SetComputerChoice();
                Console.WriteLine("I selected a random value in the range 0..5 ");
                Console.WriteLine("0 - 0");
                Console.WriteLine("1 - 1");
                Console.WriteLine("2 - 2");
                Console.WriteLine("3 - 3");
                Console.WriteLine("4 - 4");
                Console.WriteLine("5 - 5");
                Console.WriteLine("X - exit");
                Console.WriteLine("? - Help");
                Console.Write("Your selection: ");
                userChoice = Console.ReadLine();
                Controller.SetUserChoice(userChoice);
                Console.WriteLine("My number is " + Model.UserPlayer.GetInstance().GetComputerChoice());
                Console.WriteLine("The fair number generation result is " + userChoice + " + " + Model.UserPlayer.GetInstance().GetComputerChoice() + " = " +  + Model.UserPlayer.GetInstance().GetFairNumber() + " (mod 6)");
                UserPlayer.GetInstance().RollDice();
                Console.WriteLine("Your roll result " + Model.UserPlayer.GetInstance().GetFace());

            }
            else {
                Console.WriteLine("It's time for my roll.");
                Controller.SetComputerChoice();
                Console.WriteLine("I selected a random value in the range 0..5 ");
                Console.WriteLine("0 - 0");
                Console.WriteLine("1 - 1");
                Console.WriteLine("2 - 2");
                Console.WriteLine("3 - 3");
                Console.WriteLine("4 - 4");
                Console.WriteLine("5 - 5");
                Console.WriteLine("X - exit");
                Console.WriteLine("? - Help");
                Console.Write("Your selection: ");
                string userChoice = Console.ReadLine();
                Controller.SetUserChoice(userChoice);
                Console.WriteLine("My number is " + Model.UserPlayer.GetInstance().GetComputerChoice());
                Console.WriteLine("The fair number generation result is " + userChoice + " + " + Model.UserPlayer.GetInstance().GetComputerChoice() + " = " +  + Model.UserPlayer.GetInstance().GetFairNumber() + " (mod 6)");
                UserPlayer.GetInstance().RollDice();
                Console.WriteLine("My roll result " + Model.UserPlayer.GetInstance().GetFace());

                Console.WriteLine("It's time for my roll.");
                Controller.SetComputerChoice();
                Console.WriteLine("I selected a random value in the range 0..5 ");
                Console.WriteLine("0 - 0");
                Console.WriteLine("1 - 1");
                Console.WriteLine("2 - 2");
                Console.WriteLine("3 - 3");
                Console.WriteLine("4 - 4");
                Console.WriteLine("5 - 5");
                Console.WriteLine("X - exit");
                Console.WriteLine("? - Help");
                Console.Write("Your selection: ");
                userChoice = Console.ReadLine();
                Controller.SetUserChoice(userChoice);
                Console.WriteLine("My number is " + Model.VirtualPlayer.GetInstance().GetComputerChoice());
                Console.WriteLine("The fair number generation result is " + userChoice + " + " + Model.VirtualPlayer.GetInstance().GetComputerChoice() + " = " +  + Model.VirtualPlayer.GetInstance().GetFairNumber() + " (mod 6)");
                VirtualPlayer.GetInstance().RollDice();
                Console.WriteLine("My roll result " + Model.VirtualPlayer.GetInstance().GetFace());
            }
        }
        if (Model.DiceGame.Instance.GetWinner() is VirtualPlayer) {
            Console.WriteLine("I win! (" + Model.UserPlayer.GetInstance().GetScore() + " < " + Model.VirtualPlayer.GetInstance().GetScore() + ")");
        }
        else {
            Console.WriteLine("You win! (" + Model.UserPlayer.GetInstance().GetScore() + " > " + Model.VirtualPlayer.GetInstance().GetScore() + ")");
        }
    }


    public void HelpView() {
        Console.WriteLine("Help");
    }

}