public class Fraction
{


// ATTRIBUTES
    private int _top;
    private int _bottom;


// CONSTRUCTORS
    public Fraction(){
    }

    public Fraction(int wholeNumber){
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom){
        _top = top;
        _bottom = bottom;
    }


// GETTERS AND SETTERS
    public int GetTop(){
        return _top;
    }
    
    public void SetTop(int top){
        _top = top;
    }

    public int GetBottom(){
        return _bottom;
    }
    
    public void SetBottom(int bottom){
        _bottom = bottom;
    }


// METHODS
    public string GetFractionString(){
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue(){
        return Math.Round((double)_top/_bottom, 2);
    }


}