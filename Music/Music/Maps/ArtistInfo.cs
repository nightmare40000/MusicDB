using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Maps
{
    public class ArtistInfo
    {
        public virtual long ID { get; set; }
        public virtual string ArtistName { get; set; }
        public virtual IList<SongInfo> Songs { get; set;}

        public ArtistInfo()
        { 
        
        }

        public override string ToString()
        {
            string output = "Artist: " + ArtistName;
            output += " : " + string.Join("\n------", Songs);

            return output;
        }
    }
}
