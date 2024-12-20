# 日记应用

## 项目简介

本项目是一款基于 C# 开发的跨平台日记应用，旨在帮助用户记录日常生活、情绪变化和日记回顾。用户可以通过应用记录日记，上传图片生成描述性文字，并获得情绪趋势分析等高级功能。应用提供现代化的 UI 设计，支持日夜主题切换，帮助用户在舒适的环境中书写日记。

本项目不仅满足基本的日记记录需求，还结合了智能化情感分析和个性化推荐功能，助力用户进行情绪管理和自我反思，提升心理健康水平。

---

## 技术栈选型

### **语言与平台**
- **C#：** 
  - 功能强大且类型安全的编程语言，广泛支持跨平台应用开发。
  - 丰富的类库和社区支持，适合文件处理、数据分析和情感分析。
- **.NET 8.0：**
  - 最新版本提供了高效的 API，支持开发跨平台、高性能的现代化应用。

### **开发工具**
- **Rider IDE：**
  - 由 JetBrains 提供的跨平台开发工具，支持 C# 和 .NET 项目开发。
  - 功能强大的代码补全、调试和版本控制，提升开发效率。
  - 对 Avalonia UI 框架的良好支持，加速 UI 设计与预览。

### **用户界面**
- **Avalonia UI：**
  - 跨平台的开源 UI 框架，支持 Windows、macOS 和 Linux。
  - 使用 XAML 布局和 MVVM 架构，分离界面逻辑和数据逻辑。
  - 支持自定义主题，方便实现日夜模式切换功能。

---

## 功能点介绍

### **基础功能**
1. **日记列表显示：**
   - 显示所有日记的标题、日期和部分内容。
   - 支持按日期排序，提供日历视图或列表视图。
2. **编辑日记：**
   - 输入日记标题、日期和正文内容。
   - 支持图片上传和插入标签（如心情标签、情绪等级等）。
   - 通过 AI 自动生成图像描述文字，插入到日记内容中。
3. **图像生成支持：**
   - 保存用户上传的图像。
   - 利用 AI 模型生成描述性文字并附加到日记中。

### **高级功能**
1. **每日推荐歌曲：**
   - 增加音乐播放器模块，通过情感分析或日期推荐适合用户当下心情的歌曲。
   - 自动记录歌曲名称，方便回顾。
2. **心情数据分析：**
   - 统计日记中的情绪趋势，包括心情状态变化和日记数量。
   - 生成可视化图表，并通过 AI 提供个性化分析和建议。
3. **心情树洞：**
   - 根据用户日记内容和情绪，提供温暖的鼓励或回应。
4. **主题和界面设置：**
   - 支持日间和夜间主题切换，提供舒适的书写体验。

---

## 数据库设计

### 表：`diary`

| 字段名称       | 数据类型    | 描述                                      |
|----------------|-------------|-------------------------------------------|
| `id`          | INTEGER     | 主键，自增                                |
| `content`     | TEXT        | 日记正文内容                              |
| `img_url`     | TEXT        | 图片 URL                                  |
| `create_time` | DATETIME    | 创建时间，默认当前时间                    |
| `update_time` | DATETIME    | 更新时间，记录最近更新的时间              |
| `is_delete`   | INTEGER     | 逻辑删除标记 (`0` 表示未删除, `1` 表示已删除)|
| `mood_id`     | INTEGER     | 外键，关联心情表                          |
| `song_id`     | INTEGER     | 外键，关联歌曲表                          |

---

## 快速启动

### **运行前准备**
1. 安装 .NET 8.0 SDK：[下载地址](https://dotnet.microsoft.com/download/dotnet/8.0)
2. 安装 Rider IDE 或 Visual Studio。
3. 确保本地有 SQLite 数据库支持。

### **启动项目**
1. 克隆项目代码：
   ```bash
   git clone https://github.com/your-repo/diary-app.git
   cd mp3
