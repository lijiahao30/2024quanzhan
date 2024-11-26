using mp3.library.Helpers;
using mp3.library.Models;
using SQLite;

namespace mp3.library.Services;

public class DiaryStorage : IDiaryStorage
{
    // 数据库相关配置
        public const string DbName = "diary.db";

        public static readonly string DiaryDbPath =
            PathHelper.GetLocalFilePath(DbName);

        private SQLiteAsyncConnection _connection;

        private SQLiteAsyncConnection Connection =>
            _connection ??= new SQLiteAsyncConnection(DiaryDbPath);

        // 初始化数据库表
        public async Task InitializeAsync()
        {
            await Connection.CreateTableAsync<Diary>();
        }

        // 插入一条记录
        public async Task InsertAsync(Diary diary)
        {
            diary.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            diary.UpdateTime = diary.CreateTime;
            diary.IsDelete = "0"; // 默认未删除
            await Connection.InsertAsync(diary);
        }

        // 更新记录
        public async Task UpdateAsync(Diary diary)
        {
            diary.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            await Connection.UpdateAsync(diary);
        }

        // 删除记录（逻辑删除）
        public async Task DeleteAsync(int id)
        {
            var diary = await Connection.FindAsync<Diary>(id);
            if (diary != null)
            {
                diary.IsDelete = "1";
                diary.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                await Connection.UpdateAsync(diary);
            }
        }

        // 获取所有未删除的日记
        public async Task<IList<Diary>> ListAsync()
        {
            return await Connection.Table<Diary>()
                .Where(d => d.IsDelete == "0")
                .OrderByDescending(d => d.CreateTime)
                .ToListAsync();
        }

        // 根据关键词搜索日记
        public async Task<IList<Diary>> QueryAsync(string keyword)
        {
            return await Connection.Table<Diary>()
                .Where(d => d.IsDelete == "0" && d.Content.Contains(keyword))
                .OrderByDescending(d => d.CreateTime)
                .ToListAsync();
        }

        // 根据 ID 查找日记
        public async Task<Diary?> GetByIdAsync(int id)
        {
            return await Connection.Table<Diary>()
                .Where(d => d.Id == id && d.IsDelete == "0")
                .FirstOrDefaultAsync();
        }
}