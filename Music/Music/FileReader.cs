using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Music.Maps
{
    static class FileReader
    {
        public static List<SongInfo> GetProperties(string fileName)
        {
            List<SongInfo> songProperties = new List<SongInfo>();
            StreamReader fileReader = new StreamReader( fileName);

            string line;
            while ((line = fileReader.ReadLine()) != null)
            {
                songProperties.Add(new SongInfo(line));
            }
            
            
            return songProperties;

        }
    }
}
