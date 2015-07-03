namespace ZipExcel.Client.Contracts
{
    public interface IExtractor
    {
        void ExtractData(string pathToArchive, string archiveName);
    }
}
