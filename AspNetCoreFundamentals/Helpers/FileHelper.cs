using AspNetCoreFundamentals.Interfaces;

namespace AspNetCoreFundamentals.Helpers;

internal sealed class FileHelper : IFileHelper
{
    private readonly string _logFilePath;

    public FileHelper()
    {
        DateTime currentTime = DateTime.UtcNow;
        string logFileName = $"{currentTime:yyyyMMdd_hhmmss}_log.txt";
        _logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", logFileName);
        if (!Directory.Exists(Path.GetDirectoryName(_logFilePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath)!);
        }
    }

    public void WriteToFile(string logMessage)
    {
        using StreamWriter streamWriter = new StreamWriter(_logFilePath, true);
        streamWriter.WriteLine(logMessage);
    }

    public string ReadFromFile()
    {
        using StreamReader streamReader = new StreamReader(_logFilePath);
        return streamReader.ReadToEnd();
    }
}