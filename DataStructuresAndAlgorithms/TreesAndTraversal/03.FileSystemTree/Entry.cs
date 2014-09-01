namespace FileSystemTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Entry
    {
        public static Folder CreateFileSystemTree(string startPoint)
        {
            var childFolders = Directory.GetDirectories(startPoint);
            var files = Directory.GetFiles(startPoint);
            Folder folder = new Folder(startPoint, new File[files.Length], new Folder[childFolders.Length]);

            for (int i = 0; i < files.Length; i++)
			{
                var fileInfo = new FileInfo(files[i]);
                folder.Files[i] = new File(files[i], fileInfo.Length);
			}

            for (int i = 0; i < childFolders.Length; i++)
			{
                folder.ChildFolders[i] = CreateFileSystemTree(childFolders[i]);
			}

            return folder;
        }

        public static long CalculateSize(Folder folder)
        {
            long result = 0;

            foreach (var currentFolder in folder.ChildFolders)
            {
                result += CalculateSize(currentFolder);
            }

            foreach (var file in folder.Files)
            {
                result += file.Size;
            }

            return result;
        }

        public static void Main()
        {
            Console.Write("Enter a root(test with: D:\\Projects): ");
            var startPoint = Console.ReadLine();

            var fileSystem = CreateFileSystemTree(startPoint);
            var size = CalculateSize(fileSystem);
            Console.WriteLine("Size: {0}", size);
        }
    }
}
