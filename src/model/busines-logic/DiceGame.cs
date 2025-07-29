namespace Model;

public class DiceGame
{
    private readonly Player firstPlayer;
    private readonly Player secondPlayer;

    private static DiceGame? _instance;
    private static readonly object _lock = new();

    private static readonly DiceStore store = DiceStore.Instance;

    // Приватный конструктор
    private DiceGame(Player p1, Player p2)
    {
        firstPlayer = p1;
        secondPlayer = p2;
    }

    // Статическое свойство доступа
    public static DiceGame Instance(Player p1, Player p2)
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new DiceGame(p1, p2);
            }
            return _instance;
        }
    }

    public bool IsFirstPlayerVirtual()
    {
        return firstPlayer is VirtualPlayer;
    }

    public void InitGame()
    {
        if (firstPlayer is VirtualPlayer)
        {
            // логика для виртуального игрока
        }
    }
}
