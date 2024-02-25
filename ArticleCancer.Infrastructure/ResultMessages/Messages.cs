using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla eklenmiştir.";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla silinmiştir.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla geri alınmıştır.";
            }
        }
		public static class Announcement
		{
			public static string Add(string articleTitle)
			{
				return $"{articleTitle} başlıklı duyuru başarıyla eklenmiştir.";
			}
			public static string Update(string articleTitle)
			{
				return $"{articleTitle} başlıklı duyuru başarıyla güncellenmiştir.";
			}
			public static string Delete(string articleTitle)
			{
				return $"{articleTitle} başlıklı duyuru başarıyla silinmiştir.";
			}
            public static string HardDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı duyuru başarıyla kalıcı olarak silinmiştir.";
            }
            public static string UndoDelete(string articleTitle)
			{
				return $"{articleTitle} başlıklı duyuru başarıyla geri alınmıştır.";
			}
		}
		public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla eklenmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla geri alınmıştır.";
            }
        }
        public static class New
        {
            public static string Add(string newTitle)
            {
                return $"{newTitle} başlıklı haber başarıyla eklenmiştir.";
            }
            public static string Update(string newTitle)
            {
                return $"{newTitle} başlıklı haber başarıyla güncellenmiştir.";
            }
            public static string Delete(string newTitle)
            {
                return $"{newTitle} başlıklı haber başarıyla silinmiştir.";
            }
            public static string UndoDelete(string newTitle)
            {
                return $"{newTitle} başlıklı haber başarıyla geri alınmıştır.";
            }
        }
        public static class VideoBlog
        {
            public static string Add(string newTitle)
            {
                return $"{newTitle} başlıklı video başarıyla eklenmiştir.";
            }
            public static string Update(string newTitle)
            {
                return $"{newTitle} başlıklı video başarıyla güncellenmiştir.";
            }
            public static string Delete(string newTitle)
            {
                return $"{newTitle} başlıklı video başarıyla silinmiştir.";
            }
            public static string UndoDelete(string newTitle)
            {
                return $"{newTitle} başlıklı video başarıyla geri alınmıştır.";
            }
        }
        public static class ToDo
        {
            public static string Add(string newTitle)
            {
                return $"{newTitle} başlıklı görev başarıyla eklenmiştir.";
            }
            public static string Update(string newTitle)
            {
                return $"{newTitle} başlıklı görev başarıyla güncellenmiştir.";
            }
            public static string Delete(string newTitle)
            {
                return $"{newTitle} başlıklı görev başarıyla silinmiştir.";
            }
            public static string Completed(string newTitle)
            {
                return $"{newTitle} başlıklı görev başarıyla Tamamlandı.";
            }
            public static string NonCompleted(string newTitle)
            {
                return $"{newTitle} başlıklı görev  Tamamlanmadı.";
            }

        }
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla eklenmiştir.";
            }
            public static string Update(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla güncellenmiştir.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla silinmiştir.";
            }
        }
        public static class Message
        {
            public static string Send(string messageName)
            {
                return $"{messageName} başlıklı mesaj başarıyla eklenmiştir.";
            }

        }
    }
}
