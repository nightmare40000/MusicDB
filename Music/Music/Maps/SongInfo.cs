using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Maps
{
    public class SongInfo
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Album { get; set; }
        public virtual int Duration { get; set; }
        public virtual IList<GenreInfo> Genres { get; set; }
                      //{
                      //    get
                      //    {
                      //        string output = "";
                      //        if (_duration >= 3600) output += (int)(_duration / 3600) + "h ";
                      //        if (_duration >= 60) output += (int)((_duration % 3600) / 60) + ":";
                      //        output += _duration % 60;
                      //        return output;
                      //    }
                      //    set
                      //    { 
                      //        _duration = 0;
                      //        if (value.IndexOf("h") != -1)
                      //        {
                      //            _duration += int.Parse(value.Substring(0, value.IndexOf("h"))) * 3600;
                      //            value = value.Substring(value.IndexOf("h") + 2);
                      //        }
                      //        _duration += int.Parse(value.Substring(0, value.IndexOf(":"))) * 60;
                      //        _duration += int.Parse(value.Substring(value.IndexOf(":") + 1));
                              
                      //    }
                      //}       
/*        public List<string> Gentre 
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
            }
        }
 */
        public SongInfo(string line)
        {
            line = LineCorrect(line);

            //Id = int.Parse(line.Substring(0, line.IndexOf('.')));
            //line = line.Substring(line.IndexOf('.') + 1);

            Name = line.Substring(0, line.IndexOf('-'));
            line = line.Substring(line.IndexOf('-') + 1);


           // Duration =  line.Substring(0, line.IndexOf(';'));
           // line = line.Substring(line.IndexOf(';') + 1);


            /*         _genre = new List<string>();
            
                     for (int i = line.IndexOf(","); ; i = line.IndexOf(","))
                     {
                         if ( i != -1)
                         {
                             _genre.Add(line.Substring(0, i));
                             line = line.Substring(i + 1);
                         }
                         else 
                         {
                             _genre.Add(line);
                             break;
                         }
                     }
                 }
             */
        }

        /// <summary>
        /// Функция коррекции записи
        /// </summary>
        /// <param name="line">Строка для коррекции</param>
        private string LineCorrect(string line)
        {
            string output = "";
            
            // Удаляем лишние пробелы
            line = System.Text.RegularExpressions.Regex.Replace(line, " +", " ");
            //////////////  Записываем ID  //////////////////////////
            if (line[0] == ' ') line = line.Substring(1);
            output += line.Substring(0, line.IndexOf("."));
            if (output[output.Length - 1] == ' ')
                output = output.Substring(0, output.Length - 1);
            
            output += ".";
            line = line.Substring(line.IndexOf(".") + 1);

            /////////////////  Название трека  /////////////////////
            if (line[0] == ' ') line = line.Substring(1);
            output += line.Substring(0, line.IndexOf("-"));
            if (output[output.Length - 1] == ' ')
                output = output.Substring(0, output.Length - 1);

            output += "-";
            line = line.Substring(line.IndexOf("-") + 1);

            ///////////////////  Наименование группы  ///////////////
            if (line[0] == ' ') line = line.Substring(1);
            output += line.Substring(0, line.IndexOf(";"));
            if (output[output.Length - 1] == ' ')
                output = output.Substring(0, output.Length - 1);

            output += ";";
            line = line.Substring(line.IndexOf(";") + 1);

            //////////////////  Продолжительность  ///////////////////
            if (line[0] == ' ') line = line.Substring(1);
            output += line.Substring(0, line.IndexOf(";"));
            if (output[output.Length - 1] == ' ')
                output = output.Substring(0, output.Length - 1);

            output += ";";
            line = line.Substring(line.IndexOf(";") + 1);
            /////////////////  Корректируем положение жанров  ///////
            while (line.IndexOf(",") != -1)
            {
                if (line[0] == ' ') line = line.Substring(1);
                output += line.Substring(0, line.IndexOf(","));
                if (output[output.Length - 1] == ' ')
                    output = output.Substring(0, output.Length - 1);

                output += ",";
                line = line.Substring(line.IndexOf(",") + 1);
            }

            if (line[0] == ' ') line = line.Substring(1);
            output += line;
            if (output[output.Length - 1] == ' ')
                output = output.Substring(0, output.Length - 1);

            return output;
        }

        public override string ToString()
        {
            string genres = string.Join(", ", Genres);
            return string.Format("\nSong     : {0}\nDuration : {1}\nAlbum    : {2}\nGenres   : {3}", Name, Duration, Album, genres);
        }


        public SongInfo()
        { 
        
        }
    }

}
