namespace Model;

public static class FirstMove
{

    private static string userChoice = null;
    private static string computerChoice = null;

    private static readonly Random rnd = new Random();

    public static void generateComputerChoice(int start, int end)
    {
        computerChoice = rnd.Next(start, end).ToString();
    }
    public static string getUserChoice()
    {
        return userChoice;
    }
    public static void setUserChoice(string newUserChoice)
    {
        userChoice = newUserChoice;
    }
    public static string getComputerChoice()
    {
        return computerChoice;
    }
    public static bool isEqual() {
        return userChoice == computerChoice;
    }
}