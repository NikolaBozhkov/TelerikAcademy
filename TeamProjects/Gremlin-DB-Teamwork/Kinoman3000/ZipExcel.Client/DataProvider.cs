namespace ZipExcel.Client
{
    using System;
    using System.Linq;

    using ZipExcel.Client.Contracts;

    public class DataProvider
    {
        private IExtractor archiveExtractor;

        public DataProvider()
            : this(new Extractor())
        {
        }

        public DataProvider(IExtractor extractor)
        {
            this.archiveExtractor = new Extractor();
        }

        public void GetData(string pathToArchive, string archiveName)
        {
            this.archiveExtractor.ExtractData(pathToArchive, archiveName);
            // TODO: Implements this method
        }
    }
}