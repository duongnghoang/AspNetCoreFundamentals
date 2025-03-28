namespace AspNetCoreFundamentals.Interfaces;

public interface IFileHelper
{
    void WriteToFile(string logMessage);
    string ReadFromFile();
}