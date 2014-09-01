namespace FileSystemTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Folder
    {
        public Folder(string name, File[] files, Folder[] childFolders)
        {
            this.Name = name;
            this.Files = files;
            this.ChildFolders = childFolders;
        }

        public string Name { get; set; }

        public File[] Files { get; set; }

        public Folder[] ChildFolders { get; set; }
    }
}
