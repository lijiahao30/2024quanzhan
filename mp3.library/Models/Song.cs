using System.ComponentModel;
using System.Drawing;

namespace mp3.library.Models
{
    
        public class SongDetailResponse
        {
            public List<Song> songs { get; set; }
            public int code { get; set; } // 响应状态码
        }

        public class Song: INotifyPropertyChanged
        {
            private byte[] _albumImageBytes;
            public string id { get; set; }
            public string name { get; set; }
            public List<Artist> artists { get; set; }
            public Album album { get; set; } // 包含专辑信息
          
            // 专辑图片二进制数据，通知 UI 变化
            public byte[] AlbumImageBytes
            {
                get => _albumImageBytes;
                set
                {
                    if (_albumImageBytes != value)
                    {
                        _albumImageBytes = value;
                        OnPropertyChanged(nameof(AlbumImageBytes));
                    }
                }
            }
            // 实现 INotifyPropertyChanged 接口
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
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

