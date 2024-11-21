using System.Collections.Generic;

namespace mp3.library.Models
{
    public class SearchResult
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public List<Song> songs { get; set; }
    }

   
  
}