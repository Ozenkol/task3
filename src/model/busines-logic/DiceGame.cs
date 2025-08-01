using System;

namespace Model;

public class DiceGame
{
    private IPlayer? firstPlayer;
    private IPlayer? secondPlayer;

    private IPlayer? winnerPlayer;
    private int step = 0;
    private static DiceGame? _instance;
    private static readonly DiceStore store = DiceStore.Instance;

    private DiceGame()
    {

    }

    public static DiceGame Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DiceGame();
            }
            return _instance;

        }
    }

    public void SetPlayers(IPlayer first, IPlayer second) {
        firstPlayer = first;
        secondPlayer = second;
    }

    public IPlayer GetWinner() {
        return winnerPlayer;
    }


    public bool IsFirstPlayerVirtual()
    {
        return firstPlayer is VirtualPlayer;
    }

    public Boolean isGameOver()
    {
        step++;
        if (step != 1)
        {
            if (firstPlayer.GetScore() > secondPlayer.GetScore())
            {
                winnerPlayer = firstPlayer;
                return true;
            }
            if (firstPlayer.GetScore() < secondPlayer.GetScore())
            {
                winnerPlayer = secondPlayer;
                return true;
            }
        }
        return false;
    }
}
