using System;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(I_have_a_plan.UWP.FileService))]
namespace I_have_a_plan.UWP
{
    class FileService : IFileService
    {
        public async Task DeleteFileAsync(string filename)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile storageFile = await localFolder.GetFileAsync(filename);
            await storageFile.DeleteAsync();
        }

        public async Task<bool> IsFileExistAsync(string filename)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                await localFolder.GetFileAsync(filename);
            }
            catch { return false; }
            return true;
        }


        public async Task<string> ReadFromFileAsync(string filename)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile helloFile = await localFolder.GetFileAsync(filename);
            string text = await FileIO.ReadTextAsync(helloFile);
            return text;
        }

        public async Task WriteToFileAsync(string filename, string text)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            //create temporary file
            StorageFile tempFile = await localFolder.CreateFileAsync(filename,
           CreationCollisionOption.ReplaceExisting);
            //write to the temporary file
            await FileIO.WriteTextAsync(tempFile, text);
        }
    }
}
