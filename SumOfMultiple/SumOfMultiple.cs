namespace SumOfMultipleLibrary;
public class SumOfMultiple
{
    public static int Solve(int limit)
    {
        if(limit < 2)
            return 0;

        try
        {
            var numbersBelowLimit = Enumerable.Range(1, limit - 1);
            var numbersMultiple3or5 = numbersBelowLimit.Where(x => (x % 3 == 0) || (x % 5 == 0));
            var sum = numbersMultiple3or5.Sum();
            return sum;
        }
        catch(Exception e)
        {
            return 0;
        }
    }
}
