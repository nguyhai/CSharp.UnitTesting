using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            //File.ReadAllText("video.txt");
            return File.ReadAllText(path);
        }
    }
}
