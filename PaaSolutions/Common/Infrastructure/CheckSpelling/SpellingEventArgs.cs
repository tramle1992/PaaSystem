using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.CheckSpelling
{
    public class SpellingEventArgs
    {
        private int _TextIndex;
        private string _Word;
        private int _WordIndex;

        /// <summary>
        ///     Constructor used to pass in properties
        /// </summary>
        public SpellingEventArgs(string word, int wordIndex, int textIndex)
        {
            _Word = word;
            _WordIndex = wordIndex;
            _TextIndex = textIndex;
        }

        /// <summary>
        ///     Text index of the WordEvent
        /// </summary>
        public int TextIndex
        {
            get { return _TextIndex; }
        }

        /// <summary>
        ///     Word that caused the WordEvent
        /// </summary>
        public string Word
        {
            get { return _Word; }
        }

        /// <summary>
        ///     Word index of the WordEvent
        /// </summary>
        public int WordIndex
        {
            get { return _WordIndex; }
        }
    }
}
