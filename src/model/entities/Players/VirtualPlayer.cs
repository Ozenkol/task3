namespace Model;
using Model;

public class VirtualPlayer : Model.IPlayer
{
    static int userChoice;
    static int computerChoice;
    static int score = 0;
    static Model.Dice? dice;
    private VirtualPlayer() { }
    private static VirtualPlayer _instance;
    public static VirtualPlayer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new VirtualPlayer();
            }
            return _instance;
        }


    public void SetDice()
    {
        Random rnd = new Random();

        int i = rnd.Next(0, Model.DiceStore.Instance.DiceCount-1);

        dice = Model.DiceStore.Instance.GetDiceAt(i);
        Model.DiceStore.Instance.DeleteAt(i);
    }

    public void SetComputerChoice() {
        Random rnd = new Random();

        int i = rnd.Next(0, 5);

        computerChoice = i;
    }

    public void SetUserChoice(int newUserChoice) {
        userChoice = newUserChoice % 6;
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


    public string GetDiceString() {
        return "["+ string.Join(", ", dice.GetFaces()) + "]";
    }
    public void RollDice() {
        dice.RollDice((userChoice + computerChoice) % 6);
        score += dice.GetDie();
    }

    public void SetDice(int i)
    {

    }

    public void SetUserChoice()
    {

    }

    public int GetScore()
    {
        return score;
    }
}