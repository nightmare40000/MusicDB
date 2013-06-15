using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Maps
{
    public class GenreInfo
    {
        public virtual int ID {get; set;}
        public virtual string Name { get; set; }

        public GenreInfo()
        { 
        
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
