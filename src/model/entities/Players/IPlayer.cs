namespace Model;
public interface IPlayer
{

    abstract void SetDice(int i);

    abstract void SetComputerChoice();

    abstract void SetUserChoice(int arg);

    abstract void RollDice();
    abstract int GetScore();
}