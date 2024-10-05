//Klass som representerar ett inlägg i gästboken med en författare och ett meddelande
public class Post(string author, string message)
{
    public string Author { get; } = author;
    public string Message { get; } = message;

    //Returnerar en sträng med formatet "Författare - Meddelande"
    public override string ToString()
    {
        return $"{Author} - {Message}";
    }
}