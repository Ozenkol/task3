namespace Model;
using Model;

public class UserPlayer : Model.IPlayer
{
    static int userChoice;
    static int computerChoice;
    static int score = 0;
    static Model.Dice? dice;

    private UserPlayer() { }
    private static UserPlayer _instance;
        public static UserPlayer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserPlayer();
            }
            return _instance;
        }

    

    public void SetDice(int i)
    {
        dice = Model.DiceStore.Instance.GetDiceAt(i);
        Model.DiceStore.Instance.DeleteAt(i);
    }
        public int GetComputerChoice() {
        return computerChoice;
    }

    public int GetFairNumber() {
        return (computerChoice + userChoice) % 6;
    }

    public int GetFace() {
        return dice.GetDie();
    }
    public void RollDice() {
        dice.RollDice((userChoice + computerChoice) % 6);
        score += dice.GetDie();
    }
    public int GetScore() {
        return score;
    }

    public void SetComputerChoice()
    {
        Random rnd = new Random();

        int i = rnd.Next(0, 5);

        computerChoice = i;
    }

    public void SetUserChoice(int arg)
    {
        userChoice = arg;
    }
}