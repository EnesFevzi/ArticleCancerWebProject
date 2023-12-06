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
    }
}
