Console.WriteLine("Starting...");
Console.WriteLine();

Action sayHi = () => Console.WriteLine("Hi!");

var n0 = new Zero();
var n1 = new Succ(n0);
var n2 = new Succ(n1);
var n3 = n1.Plus(n2);

Console.WriteLine("Should say \"Hi!\" 3 times");
n3.Loop(sayHi);

var n5 = n2.Plus(n3);

Console.WriteLine("Should say \"Hi!\" 5 times");
n5.Loop(sayHi);

Console.WriteLine();
Console.WriteLine("Finished!");

public interface INat
{
    INat Plus(INat n);
    bool IsZero();
    void Loop(Action a);
}

public class Zero : INat
{
    public INat Plus(INat n)
    {
        return n;
    }

    public bool IsZero()
    {
        return true;
    }

    public void Loop(Action a)
    {
        //do nothing...
    }
}

public class Succ : INat
{
    private readonly INat prev;

    public Succ(INat n)
    {
        prev = n;
    }

    public INat Plus(INat n)
    {
        INat result = new Zero();
        Action add = () => result = new Succ(result);
        Loop(add);
        n.Loop(add);
        return result;
    }

    public bool IsZero()
    {
        return false;
    }

    public void Loop(Action a)
    {
        a();
        prev.Loop(a);
    }
}
