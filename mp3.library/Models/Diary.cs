namespace mp3.library.Models;

[SQLite.Table("diary")]
public class Diary
{
    [SQLite.Column("id")] public int Id { get; set; }
    [SQLite.Column("content")] public string Content { get; set; } = string.Empty;

    [SQLite.Column("img_url")] public string ImgUrl { get; set; } = string.Empty;

    [SQLite.Column("create_time")] public string CreateTime { get; set; } = string.Empty;

    [SQLite.Column("update_time")] public string UpdateTime { get; set; } = string.Empty;
    
    [SQLite.Column("is_delete")] public string IsDelete { get; set; } = string.Empty;
    
    [SQLite.Column("mood")] public string Mood { get; set; } = string.Empty;
    
    [SQLite.Column("song")] public string Song { get; set; } = string.Empty;

    private string _snippet;

    [SQLite.Ignore] public string Snippet =>
        _snippet ??= Content.Split('。')[0].Replace("\r\n", " ");
}

