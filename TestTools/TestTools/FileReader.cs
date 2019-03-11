using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools
{
    public static class FileReader
    {        
         public static FileStream ReadFile(string path)
         {
             FileInfo FI = new FileInfo(path);
             FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
             return fs;
         }        
    }
}
