using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.CheckSpelling
{
    public class ReplaceWordEventArgs : SpellingEventArgs
    {
        private string _ReplacementWord;

        /// <summary>
        ///     Class sent to the event handler when the ReplacedWord Event is fired
        /// </summary>
        public ReplaceWordEventArgs(string replacementWord, string word, int wordIndex, int textIndex)
            : base(word, wordIndex, textIndex)
        {
            _ReplacementWord = replacementWord;
        }

        /// <summary>
        ///     The word to use in replacing the misspelled word
        /// </summary>
        public string ReplacementWord
        {
            get { return _ReplacementWord; }
        }
    }
}
