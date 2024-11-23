/*
 Navicat Premium Data Transfer

 Source Server         : sqlite
 Source Server Type    : SQLite
 Source Server Version : 3030001
 Source Schema         : main

 Target Server Type    : SQLite
 Target Server Version : 3030001
 File Encoding         : 65001

 Date: 21/11/2024 19:18:18
*/

PRAGMA foreign_keys = false;

-- ----------------------------
-- Table structure for diary
-- ----------------------------
DROP TABLE IF EXISTS "diary";
CREATE TABLE "diary" (
  "id" INTEGER PRIMARY KEY AUTOINCREMENT,
  "content" TEXT NOT NULL,
  "img_url" TEXT NOT NULL,
  "create_time" TEXT NOT NULL,
  "update_time" TEXT NOT NULL,
  "is_delete" TEXT NOT NULL,
  "mood" TEXT NOT NULL,
  "song" TEXT NOT NULL
);

-- ----------------------------
-- Records of diary
-- ----------------------------
INSERT INTO "diary" VALUES (1, '今天过得很充实，学习了一些新知识。', 'https://example.com/img1.jpg', '2024-11-21 08:30:00', '2024-11-21 08:30:00', 'no', 'happy', 'Take Five');
INSERT INTO "diary" VALUES (2, '今天和朋友们一起出去玩，很开心。', 'https://example.com/img2.jpg', '2024-11-21 18:00:00', '2024-11-21 18:00:00', 'no', 'excited', 'Shape of You');
INSERT INTO "diary" VALUES (3, '今天有些累，工作压力有点大。', 'https://example.com/img3.jpg', '2024-11-21 21:00:00', '2024-11-21 21:00:00', 'no', 'stressed', 'Faded');
INSERT INTO "diary" VALUES (4, '今天读了一本很有意思的书，受益匪浅。', 'https://example.com/img4.jpg', '2024-11-21 10:00:00', '2024-11-21 10:00:00', 'no', 'thoughtful', 'Blinding Lights');
INSERT INTO "diary" VALUES (5, '今天早晨散步很舒服。', 'https://example.com/img5.jpg', '2024-11-20 07:30:00', '2024-11-20 07:30:00', 'no', 'relaxed', 'Morning Mood');
INSERT INTO "diary" VALUES (6, '晚饭吃了麻辣火锅，好过瘾。', 'https://example.com/img6.jpg', '2024-11-20 19:00:00', '2024-11-20 19:00:00', 'no', 'satisfied', 'Hotline Bling');
INSERT INTO "diary" VALUES (7, '完成了一个重要的项目，心情大好！', 'https://example.com/img7.jpg', '2024-11-19 16:00:00', '2024-11-19 16:00:00', 'no', 'accomplished', 'We Are the Champions');
INSERT INTO "diary" VALUES (8, '天气阴沉沉的，感觉有点丧。', 'https://example.com/img8.jpg', '2024-11-18 13:00:00', '2024-11-18 13:00:00', 'no', 'melancholy', 'Someone Like You');
INSERT INTO "diary" VALUES (9, '和家人度过了一个温暖的周末。', 'https://example.com/img9.jpg', '2024-11-17 21:00:00', '2024-11-17 21:00:00', 'no', 'warm', 'Perfect');
INSERT INTO "diary" VALUES (10, '今天追了一整天剧，很满足。', 'https://example.com/img10.jpg', '2024-11-16 22:00:00', '2024-11-16 22:00:00', 'no', 'content', 'On My Way');
INSERT INTO "diary" VALUES (11, '今天去看了一场电影，非常感人。', 'https://example.com/img11.jpg', '2024-11-15 20:30:00', '2024-11-15 20:30:00', 'no', 'touched', 'Cinema Paradiso');
INSERT INTO "diary" VALUES (12, '试了一道新菜，虽然失败了，但很有趣。', 'https://example.com/img12.jpg', '2024-11-14 12:00:00', '2024-11-14 12:00:00', 'no', 'curious', 'Cake by the Ocean');
INSERT INTO "diary" VALUES (13, '今天读了一本励志书，重新充满力量！', 'https://example.com/img13.jpg', '2024-11-13 15:00:00', '2024-11-13 15:00:00', 'no', 'motivated', 'Stronger');
INSERT INTO "diary" VALUES (14, '散步时看到了美丽的日落，超治愈。', 'https://example.com/img14.jpg', '2024-11-12 18:30:00', '2024-11-12 18:30:00', 'no', 'peaceful', 'Golden Hour');
INSERT INTO "diary" VALUES (15, '和同事的合作很顺利，今天效率极高！', 'https://example.com/img15.jpg', '2024-11-11 17:00:00', '2024-11-11 17:00:00', 'no', 'productive', 'Team');
INSERT INTO "diary" VALUES (16, '今天收到了一封很温暖的邮件。', 'https://example.com/img16.jpg', '2024-11-10 08:00:00', '2024-11-10 08:00:00', 'no', 'grateful', 'Somewhere Over the Rainbow');
INSERT INTO "diary" VALUES (17, '今天的瑜伽课感觉整个人焕然一新。', 'https://example.com/img17.jpg', '2024-11-09 09:30:00', '2024-11-09 09:30:00', 'no', 'refreshed', 'Yoga');
INSERT INTO "diary" VALUES (18, '今天下雨了，但心情依旧很好！', 'https://example.com/img18.jpg', '2024-11-08 14:00:00', '2024-11-08 14:00:00', 'no', 'calm', 'Rainy Day');
INSERT INTO "diary" VALUES (19, '跑步时听到了这首歌，瞬间充满力量！', 'https://example.com/img19.jpg', '2024-11-07 06:30:00', '2024-11-07 06:30:00', 'no', 'energetic', 'Eye of the Tiger');
INSERT INTO "diary" VALUES (20, '读完了一本惊悚小说，太震撼了！', 'https://example.com/img20.jpg', '2024-11-06 23:00:00', '2024-11-06 23:00:00', 'no', 'excited', 'Thriller');
INSERT INTO "diary" VALUES (21, '今天和朋友打了一场篮球比赛，超开心！', 'https://example.com/img21.jpg', '2024-11-05 19:00:00', '2024-11-05 19:00:00', 'no', 'joyful', 'Space Jam');
INSERT INTO "diary" VALUES (22, '听到了许久未听的老歌，满满的回忆杀。', 'https://example.com/img22.jpg', '2024-11-04 15:30:00', '2024-11-04 15:30:00', 'no', 'nostalgic', 'Yesterday');
INSERT INTO "diary" VALUES (23, '今天心情不好，但看了搞笑视频后好多了。', 'https://example.com/img23.jpg', '2024-11-03 20:00:00', '2024-11-03 20:00:00', 'no', 'cheered up', 'Happy');
INSERT INTO "diary" VALUES (24, '今天的考试很顺利，希望有个好成绩！', 'https://example.com/img24.jpg', '2024-11-02 10:00:00', '2024-11-02 10:00:00', 'no', 'hopeful', 'Believer');
INSERT INTO "diary" VALUES (25, '独自一人在家，但很享受这种静谧时光。', 'https://example.com/img25.jpg', '2024-11-01 21:00:00', '2024-11-01 21:00:00', 'no', 'content', 'Sound of Silence');
INSERT INTO "diary" VALUES (26, '今天尝试写了一段小诗，虽然稚嫩，但很有趣。', 'https://example.com/img26.jpg', '2024-10-31 17:00:00', '2024-10-31 17:00:00', 'no', 'creative', 'Poetry in Motion');
INSERT INTO "diary" VALUES (27, '看了一部纪录片，学到了许多新知识。', 'https://example.com/img27.jpg', '2024-10-30 22:00:00', '2024-10-30 22:00:00', 'no', 'inspired', 'Documentary Vibes');
INSERT INTO "diary" VALUES (28, '做了一个很难的数学题，最后居然解出来了！', 'https://example.com/img28.jpg', '2024-10-29 11:00:00', '2024-10-29 11:00:00', 'no', 'proud', 'Eureka');
INSERT INTO "diary" VALUES (29, '今天搬家了，虽然累但很开心。', 'https://example.com/img29.jpg', '2024-10-28 15:00:00', '2024-10-28 15:00:00', 'no', 'fulfilled', 'New Beginnings');
INSERT INTO "diary" VALUES (30, '和多年未见的老朋友聚会，聊了很多往事。', 'https://example.com/img30.jpg', '2024-10-27 20:30:00', '2024-10-27 20:30:00', 'no', 'nostalgic', 'Old Friends');
INSERT INTO "diary" VALUES (31, '晚上看了星星，感觉很放松。', 'https://example.com/img31.jpg', '2024-10-26 22:00:00', '2024-10-26 22:00:00', 'no', 'peaceful', 'Starlight');
INSERT INTO "diary" VALUES (32, '收到了一份特别的礼物，意外又惊喜！', 'https://example.com/img32.jpg', '2024-10-25 19:00:00', '2024-10-25 19:00:00', 'no', 'surprised', 'A Gift for You');
INSERT INTO "diary" VALUES (33, '今天完成了一次马拉松，突破了自己。', 'https://example.com/img33.jpg', '2024-10-24 14:00:00', '2024-10-24 14:00:00', 'no', 'triumphant', 'Run Free');
INSERT INTO "diary" VALUES (34, '今天煮了家乡的菜，勾起了许多回忆。', 'https://example.com/img34.jpg', '2024-10-23 12:00:00', '2024-10-23 12:00:00', 'no', 'homesick', 'Home Sweet Home');
INSERT INTO "diary" VALUES (35, '今天和家里的宠物玩了很久，特别开心。', 'https://example.com/img35.jpg', '2024-10-22 16:00:00', '2024-10-22 16:00:00', 'no', 'joyful', 'Paws and Claws');
INSERT INTO "diary" VALUES (36, '今天在图书馆度过了一个安静的下午。', 'https://example.com/img36.jpg', '2024-10-21 14:30:00', '2024-10-21 14:30:00', 'no', 'focused', 'Classical Studies');
INSERT INTO "diary" VALUES (37, '看了一部恐怖片，吓得晚上都不敢关灯。', 'https://example.com/img37.jpg', '2024-10-20 23:00:00', '2024-10-20 23:00:00', 'no', 'scared', 'Horror Nights');
INSERT INTO "diary" VALUES (38, '第一次尝试画水彩画，感觉很有趣！', 'https://example.com/img38.jpg', '2024-10-19 10:00:00', '2024-10-19 10:00:00', 'no', 'creative', 'Color Splash');
INSERT INTO "diary" VALUES (39, '今天尝试了一种新的乐器，虽然生疏但很有趣。', 'https://example.com/img39.jpg', '2024-10-18 16:00:00', '2024-10-18 16:00:00', 'no', 'interested', 'Melody of Life');
INSERT INTO "diary" VALUES (40, '收到了一封很久未联系朋友的信，满满感动。', 'https://example.com/img40.jpg', '2024-10-17 09:00:00', '2024-10-17 09:00:00', 'no', 'touched', 'Old Memories');
INSERT INTO "diary" VALUES (41, '今天的天气很好，阳光洒满了整个屋子。', 'https://example.com/img41.jpg', '2024-10-16 08:00:00', '2024-10-16 08:00:00', 'no', 'cheerful', 'Sunny Days');
INSERT INTO "diary" VALUES (42, '今天尝试了一种新茶，味道特别棒！', 'https://example.com/img42.jpg', '2024-10-15 15:00:00', '2024-10-15 15:00:00', 'no', 'content', 'Tea Time');
INSERT INTO "diary" VALUES (43, '参加了公司的年会，大家都很热闹。', 'https://example.com/img43.jpg', '2024-10-14 19:30:00', '2024-10-14 19:30:00', 'no', 'enthusiastic', 'Celebration');
INSERT INTO "diary" VALUES (44, '今天学习了一种新技能，感觉很有成就感。', 'https://example.com/img44.jpg', '2024-10-13 13:00:00', '2024-10-13 13:00:00', 'no', 'proud', 'Skill Up');
INSERT INTO "diary" VALUES (45, '今天体验了一场特别的展览，印象深刻。', 'https://example.com/img45.jpg', '2024-10-12 11:00:00', '2024-10-12 11:00:00', 'no', 'impressed', 'Gallery Walk');
INSERT INTO "diary" VALUES (46, '尝试了一次户外攀岩，虽然累，但很有成就感。', 'https://example.com/img46.jpg', '2024-10-11 09:30:00', '2024-10-11 09:30:00', 'no', 'adventurous', 'Reach the Top');
INSERT INTO "diary" VALUES (47, '和家人一起做晚饭，其乐融融。', 'https://example.com/img47.jpg', '2024-10-10 18:00:00', '2024-10-10 18:00:00', 'no', 'warm', 'Home Cooking');
INSERT INTO "diary" VALUES (48, '发现了一家隐藏的咖啡馆，环境特别好。', 'https://example.com/img48.jpg', '2024-10-09 15:00:00', '2024-10-09 15:00:00', 'no', 'relaxed', 'Latte Love');
INSERT INTO "diary" VALUES (49, '今天丢了手机，虽然很郁闷，但安全找回来了。', 'https://example.com/img49.jpg', '2024-10-08 12:00:00', '2024-10-08 12:00:00', 'no', 'relieved', 'Lucky Day');
INSERT INTO "diary" VALUES (50, '学习了一整天，感觉脑袋要爆炸了。', 'https://example.com/img50.jpg', '2024-10-07 20:00:00', '2024-10-07 20:00:00', 'no', 'tired', 'Study Marathon');
INSERT INTO "diary" VALUES (51, '今天去海边散步，吹风很舒服。', 'https://example.com/img51.jpg', '2024-10-06 17:00:00', '2024-10-06 17:00:00', 'no', 'calm', 'Ocean Breeze');
INSERT INTO "diary" VALUES (52, '给朋友做了一个小手工礼物，很开心他喜欢。', 'https://example.com/img52.jpg', '2024-10-05 14:00:00', '2024-10-05 14:00:00', 'no', 'happy', 'Crafty Hands');
INSERT INTO "diary" VALUES (53, '今天读了一本很有意思的小说，故事情节非常精彩。', 'https://example.com/img53.jpg', '2024-10-04 22:00:00', '2024-10-04 22:00:00', 'no', 'immersed', 'Story Time');
INSERT INTO "diary" VALUES (54, '早上参加了一个公益活动，认识了很多志同道合的人。', 'https://example.com/img54.jpg', '2024-10-03 09:00:00', '2024-10-03 09:00:00', 'no', 'connected', 'Helping Hands');
INSERT INTO "diary" VALUES (55, '在公园看到了好多小动物，特别有趣。', 'https://example.com/img55.jpg', '2024-10-02 16:00:00', '2024-10-02 16:00:00', 'no', 'playful', 'Wildlife Walk');
INSERT INTO "diary" VALUES (56, '今天写了一个很复杂的代码功能，最后居然通过了所有测试。', 'https://example.com/img56.jpg', '2024-10-01 18:00:00', '2024-10-01 18:00:00', 'no', 'accomplished', 'Code Complete');
INSERT INTO "diary" VALUES (57, '下雨天一个人在家，安静地听了一下午音乐。', 'https://example.com/img57.jpg', '2024-09-30 14:00:00', '2024-09-30 14:00:00', 'no', 'melancholy', 'Rainy Days');
INSERT INTO "diary" VALUES (58, '今天看了一场演唱会，太燃了！', 'https://example.com/img58.jpg', '2024-09-29 20:00:00', '2024-09-29 20:00:00', 'no', 'excited', 'Live and Loud');
INSERT INTO "diary" VALUES (59, '今天整理了很多旧照片，回忆满满。', 'https://example.com/img59.jpg', '2024-09-28 10:00:00', '2024-09-28 10:00:00', 'no', 'nostalgic', 'Old Days');
INSERT INTO "diary" VALUES (60, '今天体验了一个新的运动项目，很有挑战性。', 'https://example.com/img60.jpg', '2024-09-27 17:00:00', '2024-09-27 17:00:00', 'no', 'energetic', 'Sports Spirit');
INSERT INTO "diary" VALUES (61, '在家做了一个新的菜谱，味道超级棒！', 'https://example.com/img61.jpg', '2024-09-26 19:00:00', '2024-09-26 19:00:00', 'no', 'satisfied', 'Cooking Adventures');
INSERT INTO "diary" VALUES (62, '今天画了一幅风景画，虽然不完美，但很开心。', 'https://example.com/img62.jpg', '2024-09-25 16:00:00', '2024-09-25 16:00:00', 'no', 'creative', 'Brush Strokes');
INSERT INTO "diary" VALUES (63, '晚上看了流星，许了一个愿望。', 'https://example.com/img63.jpg', '2024-09-24 21:30:00', '2024-09-24 21:30:00', 'no', 'hopeful', 'Shooting Star');
INSERT INTO "diary" VALUES (64, '尝试了一次骑马，虽然一开始有点害怕，但后来很享受。', 'https://example.com/img64.jpg', '2024-09-23 11:00:00', '2024-09-23 11:00:00', 'no', 'adventurous', 'Gallop Free');
INSERT INTO "diary" VALUES (65, '今天开了一个视频会议，感觉效率很高。', 'https://example.com/img65.jpg', '2024-09-22 14:00:00', '2024-09-22 14:00:00', 'no', 'productive', 'Team Work');
INSERT INTO "diary" VALUES (66, '今天和朋友去看了日落，风景特别美。', 'https://example.com/img66.jpg', '2024-09-21 18:30:00', '2024-09-21 18:30:00', 'no', 'peaceful', 'Sunset Glow');
INSERT INTO "diary" VALUES (67, '尝试了新的健身课程，全身肌肉都在抗议。', 'https://example.com/img67.jpg', '2024-09-20 08:00:00', '2024-09-20 08:00:00', 'no', 'exhausted', 'Body Burn');
INSERT INTO "diary" VALUES (68, '今天在图书馆待了一整天，学到了好多新知识。', 'https://example.com/img68.jpg', '2024-09-19 17:00:00', '2024-09-19 17:00:00', 'no', 'focused', 'Library Days');
INSERT INTO "diary" VALUES (69, '和同事一起完成了一个大项目，真的很有成就感！', 'https://example.com/img69.jpg', '2024-09-18 16:00:00', '2024-09-18 16:00:00', 'no', 'proud', 'Victory');
INSERT INTO "diary" VALUES (70, '中午在餐厅点错了菜，但意外发现特别好吃。', 'https://example.com/img70.jpg', '2024-09-17 12:30:00', '2024-09-17 12:30:00', 'no', 'surprised', 'Delicious Mistake');
INSERT INTO "diary" VALUES (71, '今天帮邻居修好了一个小电器，他特别感激。', 'https://example.com/img71.jpg', '2024-09-16 15:00:00', '2024-09-16 15:00:00', 'no', 'helpful', 'Good Neighbor');
INSERT INTO "diary" VALUES (72, '发现了一首特别有共鸣的歌，单曲循环了一整天。', 'https://example.com/img72.jpg', '2024-09-15 19:00:00', '2024-09-15 19:00:00', 'no', 'emotional', 'Heartstrings');
INSERT INTO "diary" VALUES (73, '今天学习了一个新的编程框架，开始有些晕，后来慢慢上手了。', 'https://example.com/img73.jpg', '2024-09-14 10:00:00', '2024-09-14 10:00:00', 'no', 'challenged', 'Learning Curve');
INSERT INTO "diary" VALUES (74, '夜晚和朋友在河边散步，聊了很多心事。', 'https://example.com/img74.jpg', '2024-09-13 21:00:00', '2024-09-13 21:00:00', 'no', 'connected', 'Night Talks');
INSERT INTO "diary" VALUES (75, '今天种下了一些新的植物，希望它们快快长大。', 'https://example.com/img75.jpg', '2024-09-12 08:30:00', '2024-09-12 08:30:00', 'no', 'hopeful', 'Growing Dreams');
INSERT INTO "diary" VALUES (76, '参加了一场派对，认识了很多有趣的人。', 'https://example.com/img76.jpg', '2024-09-11 20:00:00', '2024-09-11 20:00:00', 'no', 'excited', 'Party Time');
INSERT INTO "diary" VALUES (77, '今天终于修好了家里的漏水问题，心情舒畅。', 'https://example.com/img77.jpg', '2024-09-10 14:00:00', '2024-09-10 14:00:00', 'no', 'relieved', 'Fixed It');
INSERT INTO "diary" VALUES (78, '早晨看了一场日出，心情特别平静。', 'https://example.com/img78.jpg', '2024-09-09 06:00:00', '2024-09-09 06:00:00', 'no', 'peaceful', 'Morning Light');
INSERT INTO "diary" VALUES (79, '今天学习做了甜点，虽然卖相不太好，但味道不错。', 'https://example.com/img79.jpg', '2024-09-08 15:00:00', '2024-09-08 15:00:00', 'no', 'satisfied', 'Sweet Escape');
INSERT INTO "diary" VALUES (80, '整理了家里的旧物品，发现了许多有趣的回忆。', 'https://example.com/img80.jpg', '2024-09-07 11:00:00', '2024-09-07 11:00:00', 'no', 'nostalgic', 'Memory Lane');
INSERT INTO "diary" VALUES (81, '今天去博物馆参观，增长了不少知识。', 'https://example.com/img81.jpg', '2024-09-06 13:00:00', '2024-09-06 13:00:00', 'no', 'inspired', 'Cultural Insights');
INSERT INTO "diary" VALUES (82, '下午和朋友们去公园野餐，特别开心。', 'https://example.com/img82.jpg', '2024-09-05 16:00:00', '2024-09-05 16:00:00', 'no', 'happy', 'Picnic Time');
INSERT INTO "diary" VALUES (83, '晚上和家人一起打了几盘桌游，其乐融融。', 'https://example.com/img83.jpg', '2024-09-04 20:30:00', '2024-09-04 20:30:00', 'no', 'warm', 'Game Night');
INSERT INTO "diary" VALUES (84, '今天去海边冲浪，虽然摔了几次，但特别刺激。', 'https://example.com/img84.jpg', '2024-09-03 17:00:00', '2024-09-03 17:00:00', 'no', 'adventurous', 'Wave Rider');
INSERT INTO "diary" VALUES (85, '发现了一家超棒的书店，买了几本新书。', 'https://example.com/img85.jpg', '2024-09-02 15:00:00', '2024-09-02 15:00:00', 'no', 'excited', 'Book Haven');
INSERT INTO "diary" VALUES (86, '尝试了一种新的插花艺术，家里顿时充满了生机。', 'https://example.com/img106.jpg', '2024-08-10 10:00:00', '2024-08-10 10:00:00', 'no', 'creative', 'Blooming Hearts');
INSERT INTO "diary" VALUES (87, '参加了一场城市探秘活动，发现了很多有趣的地方。', 'https://example.com/img107.jpg', '2024-08-09 14:30:00', '2024-08-09 14:30:00', 'no', 'adventurous', 'Urban Mystery');
INSERT INTO "diary" VALUES (88, '今天终于鼓起勇气向老板提出了加薪申请。', 'https://example.com/img108.jpg', '2024-08-08 15:00:00', '2024-08-08 15:00:00', 'no', 'nervous', 'Brave Steps');
INSERT INTO "diary" VALUES (89, '下雨天没有出门，在家里做了一顿大餐犒劳自己。', 'https://example.com/img109.jpg', '2024-08-07 18:00:00', '2024-08-07 18:00:00', 'no', 'cozy', 'Rainy Treats');
INSERT INTO "diary" VALUES (90, '晨跑的时候遇到了一位热心的老爷爷，聊得很开心。', 'https://example.com/img110.jpg', '2024-08-06 07:30:00', '2024-08-06 07:30:00', 'no', 'happy', 'Morning Stories');
INSERT INTO "diary" VALUES (91, '今天在图书馆借到了期待已久的书。', 'https://example.com/img111.jpg', '2024-08-05 16:00:00', '2024-08-05 16:00:00', 'no', 'excited', 'Library Treasures');
INSERT INTO "diary" VALUES (92, '发现自己种的第一盆多肉植物终于开花了！', 'https://example.com/img112.jpg', '2024-08-04 09:00:00', '2024-08-04 09:00:00', 'no', 'proud', 'Growing Joy');
INSERT INTO "diary" VALUES (93, '参加了一个在线摄影分享会，学到了很多新技巧。', 'https://example.com/img113.jpg', '2024-08-03 20:00:00', '2024-08-03 20:00:00', 'no', 'inspired', 'Shutter Dreams');
INSERT INTO "diary" VALUES (94, '在海边捡到了一颗特别的贝壳，决定把它留作纪念。', 'https://example.com/img114.jpg', '2024-08-02 16:00:00', '2024-08-02 16:00:00', 'no', 'peaceful', 'Ocean Whisper');
INSERT INTO "diary" VALUES (95, '给自己买了一束鲜花，感觉生活充满了仪式感。', 'https://example.com/img115.jpg', '2024-08-01 18:00:00', '2024-08-01 18:00:00', 'no', 'content', 'Floral Bliss');
INSERT INTO "diary" VALUES (96, '去一家网红咖啡馆打卡，品尝了他们的招牌甜品。', 'https://example.com/img116.jpg', '2024-07-31 15:00:00', '2024-07-31 15:00:00', 'no', 'delighted', 'Sweet Moments');
INSERT INTO "diary" VALUES (97, '尝试了一次新的瑜伽课程，身心放松了不少。', 'https://example.com/img117.jpg', '2024-07-30 10:00:00', '2024-07-30 10:00:00', 'no', 'relaxed', 'Zen Vibes');
INSERT INTO "diary" VALUES (98, '今天在公司举办的趣味运动会上拿了第一名！', 'https://example.com/img118.jpg', '2024-07-29 17:00:00', '2024-07-29 17:00:00', 'no', 'triumphant', 'Victory Cheers');
INSERT INTO "diary" VALUES (99, '和朋友们去了一个新开的密室逃脱，玩得很开心。', 'https://example.com/img119.jpg', '2024-07-28 19:30:00', '2024-07-28 19:30:00', 'no', 'excited', 'Escape Adventure');
INSERT INTO "diary" VALUES (100, '今天整理了自己的旧照片，发现了许多美好的回忆。', 'https://example.com/img120.jpg', '2024-07-27 20:00:00', '2024-07-27 20:00:00', 'no', 'nostalgic', 'Memory Lane');
INSERT INTO "diary" VALUES (101, '在公园里偶遇了一只流浪狗，给它带来了一些食物。', 'https://example.com/img121.jpg', '2024-07-26 14:00:00', '2024-07-26 14:00:00', 'no', 'caring', 'Kindness Acts');
INSERT INTO "diary" VALUES (102, '晚上在天台上拍摄了一组夜景照片，星空特别美。', 'https://example.com/img122.jpg', '2024-07-25 22:30:00', '2024-07-25 22:30:00', 'no', 'calm', 'Under the Stars');
INSERT INTO "diary" VALUES (103, '今天参加了一个社区环保活动，认识了很多志同道合的人。', 'https://example.com/img123.jpg', '2024-07-24 10:00:00', '2024-07-24 10:00:00', 'no', 'fulfilled', 'Green Harmony');
INSERT INTO "diary" VALUES (104, '尝试了自制手工冰淇淋，味道意外地好。', 'https://example.com/img124.jpg', '2024-07-23 16:00:00', '2024-07-23 16:00:00', 'no', 'satisfied', 'Sweet Chill');
INSERT INTO "diary" VALUES (105, '和家人一起去爬山，虽然很累但很有意义。', 'https://example.com/img125.jpg', '2024-07-22 17:00:00', '2024-07-22 17:00:00', 'no', 'grateful', 'Mountain Breeze');

-- ----------------------------
-- Table structure for sqlite_sequence
-- ----------------------------
DROP TABLE IF EXISTS "sqlite_sequence";
CREATE TABLE "sqlite_sequence" (
  "name",
  "seq"
);

-- ----------------------------
-- Records of sqlite_sequence
-- ----------------------------
INSERT INTO "sqlite_sequence" VALUES ('diary', 105);

-- ----------------------------
-- Auto increment value for diary
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 105 WHERE name = 'diary';

PRAGMA foreign_keys = true;
