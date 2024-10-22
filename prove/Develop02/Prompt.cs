public class Prompt
{
    public string _promptsFilePath;
    
    public Random _randomProducer; //dead > moved to Entry class
    public int _randomIndex;
    public List<int> _promptIndexUsed = new List<int>();
    public string _randomPrompt;
    

    public void GetUserPromptsFilePathsFromUserClassObj(string _currentUserPromptsFilePath)
    {
        _promptsFilePath = _currentUserPromptsFilePath;
    }





    // List of all prompts
    public List<string> all_prompts = new List<string>()
    {
        
    };



    public int RandomProducer()
    {
        Random randomInt = new Random(); //fix
        int randomIndex = randomInt.Next(_)

        Prompt._randomIndex = random_producer;
        
        return _randomIndex
    };







    // Hard code list of 100 prompts (under the methods)
    public List<string> promptsAll = new List<string>
    {


    };

    int promptsAll_length = promptsAll.Count;






}
