namespace Malek_wafik.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile File,string FolderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);
            string FileName = $"{Guid.NewGuid()}{File.FileName}";
            string FilePath = Path.Combine(FolderPath, FileName);
            using var Fs = new FileStream(FilePath, FileMode.Create);
            File.CopyTo(Fs);
            return FileName;
        }
        public static void DeleteFile(string FileName,string FolderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);
            string FilePath = Path.Combine (FolderPath, FileName);
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }

    }
}
