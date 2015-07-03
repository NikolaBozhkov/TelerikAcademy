namespace ZipExcel.Client
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    using ZipExcel.Client.Contracts;

    internal class Extractor : IExtractor
    {
        private const string FileForExtract = "Reports";

        private readonly IParser excelParser;

        public Extractor()
            : this(new ExcelParser())
        {
        }

        public Extractor(IParser parser)
        {
            this.excelParser = parser;
        }

        public void ExtractData(string pathToArchive, string archiveName)
        {
            if (Directory.Exists(string.Format("{0}{1}", pathToArchive, FileForExtract)))
            {
                Directory.Delete(string.Format("{0}{1}", pathToArchive, FileForExtract), true);
            }

            ZipFile.ExtractToDirectory(string.Format("{0}{1}", pathToArchive, archiveName), string.Format("{0}{1}", pathToArchive, FileForExtract));
            var allFolders = Directory.GetDirectories(string.Format("{0}{1}", pathToArchive, FileForExtract));

            foreach (var folder in allFolders)
            {
                var folderName = Path.GetFileName(folder);
                var allFiles = Directory.GetFiles(folder);

                foreach (var file in allFiles)
                {
                    this.excelParser.Parse(folderName, file);
                }
            }
        }
    }
}