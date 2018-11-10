using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace I_have_a_plan
{
    public interface IFileService
    {
        Task WriteToFileAsync(string filename, string text);
        Task<string> ReadFromFileAsync(string filename);
        Task<bool> IsFileExistAsync(string filename);
        Task DeleteFileAsync(string filename);


    }
}
