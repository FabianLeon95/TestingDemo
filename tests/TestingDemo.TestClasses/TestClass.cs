namespace TestingDemo.TestClasses;

public class TestClass
{
    public decimal Add(decimal a, decimal b)
    {
        return a + b;
    }

    public decimal Subtract(decimal a, decimal b)
    {
        return a - b;
    }

    public decimal Multiply(decimal a, decimal b)
    {
        return a * b;
    }

    public decimal Divide(decimal a, decimal b)
    {
        return a / b;
    }

    public bool IsOdd(int input)
    {
        return input % 2 != 0;
    }

    public bool IsEven(int input)
    {
        return input % 2 == 0;
    }

    public IEnumerable<int> GetOddNumbers(int bound)
    {
        for (var i = 0; i <= bound; i++)
            if (i % 2 != 0)
                yield return i;
    }

    public IEnumerable<int> GetEvenNumbers(int bound)
    {
        for (var i = 0; i <= bound; i++)
            if (i % 2 == 0)
                yield return i;
    }
}