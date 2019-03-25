
public class Move
{
    public int FromX { get; set; }
    public int FromY { get; set; }
    public int ToX { get; set; }
    public int ToY { get; set; }

    public Move() {}

    public Move(int x, int y, int xt, int yt)
    {
        FromX = x;
        FromY = y;
        ToX = xt;
        ToY = yt;
    }
}
