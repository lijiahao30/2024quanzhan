using System.Collections.Generic;

namespace mp3.library.Models
{
    public class SongUrlResponse
    {
        public List<SongUrlData> data { get; set; }
    }

    public class SongUrlData
    {
        public string id { get; set; }
        public string url { get; set; }
    }
}