using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileProcessor
{
    public class FilesProcessor
    {
        const string inputDirectory= @"C:\TestFileProcessor\input";
        const string outputDirectory = @"C:\TestFileProcessor\output\";

        public void ProcessFiles()
        {
            this.GetFiles();
        }

        private void GetFiles()
        {
            DirectoryInfo d = new DirectoryInfo(inputDirectory);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {
                file.CopyTo(outputDirectory+file.Name);
                file.Delete();
            }

        }
    }
}
