namespace ProjFira_Maria.Dourado;

internal class Console2
{
    public static int ReadInt()
    {
        string input = Console.ReadLine();

        _ = int.TryParse(input, out int value);
        return value;
    }
}
