namespace ExchangeAGram.Application.Common.Interfaces
{
    public interface ISystemFileService
    {
        void SaveFileBytes(byte[] fileBytes, string fullFileName);
        byte[] GetSystemFile(string fullFileName);
        void EnsureDirectory(string directory);
        string CombinePaths(params string[] paths);
        string RemoveExtensionFromFile(string fileName);
        string GetFileExtension(string fileName);
        string GetFileNameFromFullPath(string fullFilePath);
    }
}
