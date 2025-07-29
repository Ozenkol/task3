using System;
using System.Collections.Generic;

namespace Model;
public class DiceStore
{
    private static DiceStore? _instance;
    private static readonly object _lock = new();

    public static DiceStore Instance
    {
        get
        {
            lock (_lock)
            {
                return _instance ??= new DiceStore();
            }
        }
    }

    private readonly List<Dice> _diceList = [];

    public void Init(string [] args)
        {
            foreach (string arg in args) {
            _diceList.Add(new Dice(arg));
        }
        }

    public IReadOnlyList<Dice> DiceList => _diceList.AsReadOnly();

    private DiceStore() { }

    public int DiceCount => _diceList.Count;

    // Example getter method
    public Dice GetDiceAt(int index)
    {
        return _diceList[index];
    }

    public void Push(Dice dice)
    {
        _diceList.Add(dice);
    }

    public void DeleteAt(int index)
    {
        if (index >= 0 && index < _diceList.Count)
        {
            _diceList.RemoveAt(index);
        }
    }

    public void Print() {
        foreach(Dice dice in _diceList) {
            Console.WriteLine("["+ string.Join(", ", dice.GetFaces()) + "]");
        }
    }

}
