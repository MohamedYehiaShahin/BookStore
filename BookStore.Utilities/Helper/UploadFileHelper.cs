using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utilities.Helper
{
    public static class UploadFileHelper
    {
        public static string SaveFile(IFormFile FileUrl, String FolderPath)
        {
            //Get Directory
            string FilePath = $"{Directory.GetCurrentDirectory()}/wwwroot/Files/{FolderPath}";

            //Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);

            //merge directory with File Name
            string FinalPath = Path.Combine(FilePath, FileName);

            //save your file as stream "data overtime"
            using (var stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(stream);
            }

            return FileName;
        }

        public static void DeleteFile(string FolderName, string RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName);
            }
        }
    }
}
