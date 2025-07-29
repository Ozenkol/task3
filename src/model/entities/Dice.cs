namespace Model;

public class Dice(string input)
{
    private int die = 0;
    private readonly int[] faces = input.Split(',')
            .Select(s => int.Parse(s))
            .ToArray();

    public void RollDice(int i) {
        die = faces[i];
    }

    public int GetDie() {
        return die;
    }

    public int[] GetFaces() {
        return faces;
    }

    public void PrintFaces() {
        Console.Write("["+ string.Join(", ", GetFaces()) + "]");
    }

}