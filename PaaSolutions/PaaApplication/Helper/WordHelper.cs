using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = NetOffice.WordApi;

namespace PaaApplication.Helper
{
    public class WordHelper
    {
        public static void RemoveAllBookmarks(Word.Document doc)
        {
            if (doc == null)
                return;
            foreach(Word.Bookmark bm in doc.Bookmarks)
            {
                bm.Delete();
            }
        }
    }
}
