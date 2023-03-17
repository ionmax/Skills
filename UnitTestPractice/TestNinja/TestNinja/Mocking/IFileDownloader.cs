namespace TestNinja.Mocking
{
    public interface IFileDownloader
    {
        void Download(string url, string destinationPath);
    }
}