namespace mp3.library.Models
{
    public class Song
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Artist> artists { get; set; }
        public Album album { get; set; } // 新增专辑信息
    }
    public class Album
    {
        public string name { get; set; }
        public string picUrl { get; set; } // 专辑图片 URL
    }

    public class Artist
    {
        public string name { get; set; }
    }
}