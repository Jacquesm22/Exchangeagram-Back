using ExchangeAGram.Application.Common.Interfaces;
using System;
using System.IO;

namespace ExchangeAGram.Infrastructure.Services
{
    public class SystemFileService : ISystemFileService
    {
        public string CombinePaths(params string[] paths)
        {
            if (paths == null || paths.Length == 0)
            {
                throw new ArgumentException(null, nameof(paths));
            }

            return Path.Combine(paths);
        }

        public void EnsureDirectory(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                throw new ArgumentException(null, nameof(directory));
            }

            Directory.CreateDirectory(directory);
        }

        public void SaveFileBytes(byte[] fileBytes, string fullFileName)
        {
            if (fileBytes == null || fileBytes.Length == 0)
            {
                throw new ArgumentException(null, nameof(fileBytes));
            }

            if (string.IsNullOrWhiteSpace(fullFileName))
            {
                throw new ArgumentException(null, nameof(fullFileName));
            }

            File.WriteAllBytes(fullFileName, fileBytes);
        }

        public string GetFileExtension(string fileName)
        {
            if (!fileName.Contains("."))
            {
                return fileName;
            }

            return fileName[(fileName.LastIndexOf('.') + 1)..];
        }

        public string GetFileNameFromFullPath(string fullFilePath)
        {
            if (string.IsNullOrWhiteSpace(fullFilePath))
            {
                throw new ArgumentException(null, nameof(fullFilePath));
            }

            return Path.GetFileNameWithoutExtension(fullFilePath);
        }

        public string RemoveExtensionFromFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException(null, nameof(fileName));
            }

            if (!fileName.Contains("."))
            {
                return fileName;
            }

            string name = fileName.Substring(0, fileName.LastIndexOf('.'));
            return name;
        }

        public byte[] GetSystemFile(string fullFileName)
        {
            if (string.IsNullOrWhiteSpace(fullFileName))
            {
                throw new ArgumentException(null, nameof(fullFileName));
            }

            if (!File.Exists(fullFileName))
            {
                return null;
            }

            return File.ReadAllBytes(fullFileName);
        }
    }
}
