namespace Model;
public interface Player
{
    static int userChoice;
    static int computerChoice;
    static int fairNumber;
    static int score = 0;
    static Model.Dice? dice;
    void SetDice(Model.Dice newDice)
    {
        dice = newDice;
    }

    void SetComputerChoice() {

    }

    void SetUserChoice() {

    }

    void RollDice()
    {
        dice.RollDice(fairNumber % 6);
        score += dice.GetDie();
    }
}