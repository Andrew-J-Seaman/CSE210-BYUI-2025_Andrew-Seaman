public class Bin
{
    // ATTRIBUTES //
    private string _denomination;
    private double _value;
    private int _count;

    // CONSTRUCTORS //
    public Bin(string denomination, double value, int count)
    {
        _denomination = denomination;
        _value = value;
        _count = count;
    }

    // METHODS //
    public void Transaction(int count)
    // value parameter should be negative for debit, positive for credit
    {
        _count += count;
    }

    public string getDenomination()
    {
        return _denomination;
    }

    public int GetCount()
    {
        return _count;
    }

    // public void setCount(int amount)
    // {
    //     _count = amount;
    //}
}
