using System;
using System.Collections.Generic;

namespace Model;
public sealed class DiceStore
{

    private DiceStore() { }

    public List<Dice> _diceList = [];
    public int DiceCount => _diceList.Count;

    private static DiceStore? _instance;

    public static DiceStore Instance
        {
            get {
                if(_instance == null)
                {
                    _instance = new DiceStore();
                }
                return _instance;
            }

        }

    public void Init(string [] args)
        {
            foreach (string arg in args) {
                _diceList.Add(new Dice(arg));
        }
    }

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

    public void PrintDices() {
        foreach(Dice dice in _diceList) {
            Console.WriteLine("["+ string.Join(", ", dice.GetFaces()) + "]");
        }
    }

    public void PrintDice(int i) {
        GetDiceAt(i).PrintFaces();
    }

}
