namespace TinyURLPOC.Helpers;

public interface IURLEncoding<T> where T : class
{
    public T Encode(T plainText);
    public T Decode(T base64EncodedText);
}