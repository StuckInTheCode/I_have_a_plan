using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(I_have_a_plan.Droid.FileService))]
namespace I_have_a_plan.Droid
{
    public class FileService : IFileService
    {
        public Task DeleteFileAsync(string filename)
        {
            File.Delete(GetFilePath(filename));
            return Task.FromResult(true);
        }

        public Task<bool> IsFileExistAsync(string filename)
        {
            //get filepath
            string filepath = GetFilePath(filename);
            bool exists = File.Exists(filepath);
            //if file exist return result of finding operation
            return Task<bool>.FromResult(exists);
        }

        public async Task<string> ReadFromFileAsync(string filename)
        {
            string filepath = GetFilePath(filename);
            using (StreamReader reader = File.OpenText(filepath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task WriteToFileAsync(string filename, string text)
        {
            string filepath = GetFilePath(filename);
            using (StreamWriter writer = File.CreateText(filepath))
            {
                await writer.WriteAsync(text);
            }
        }

        string GetFilePath(string filename)
        {
            //create path
            return Path.Combine(GetDocsPath(), filename);
        }

        string GetDocsPath()
        {
            //MyDocuments folder
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        }

        public string ReadFromFile(string filename)
        {
            throw new NotImplementedException();
        }
    }
}