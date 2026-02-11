using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace SmartHome
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public double Duration { get; set; }

        public Song(string title, string artist, double duration)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
        }

        public Song() { }

        public override string ToString()
        {
            return $"{Artist} - {Title} ({Duration})";
        }
    }
}
