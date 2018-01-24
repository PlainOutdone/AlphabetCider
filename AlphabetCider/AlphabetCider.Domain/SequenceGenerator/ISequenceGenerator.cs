using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetCider.SequenceGenerator
{
    public interface ISequenceGenerator
    {
        string GenerateSequence(string secretLetter);
    }

    public class EncryptingSequenceGenerator : ISequenceGenerator
    {
        //Dirty.. but... it was a copy and paste from the readme, so i didn't hand type this
        //Decrpying will see i refactor this haha
        private Dictionary<string, string> encryptionLibrary = new Dictionary<string, string>()
        {
            {"A", "abcdefghijklmnopqrstuvwxyz"},
            {"B", "bcdefghijklmnopqrstuvwxyza"},
            {"C", "cdefghijklmnopqrstuvwxyzab"},
            {"D", "defghijklmnopqrstuvwxyzabc"},
            {"E", "efghijklmnopqrstuvwxyzabcd"},
            {"F", "fghijklmnopqrstuvwxyzabcde"},
            {"G", "ghijklmnopqrstuvwxyzabcdef"},
            {"H", "hijklmnopqrstuvwxyzabcdefg"},
            {"I", "ijklmnopqrstuvwxyzabcdefgh"},
            {"J", "jklmnopqrstuvwxyzabcdefghi"},
            {"K", "klmnopqrstuvwxyzabcdefghij"},
            {"L", "lmnopqrstuvwxyzabcdefghijk"},
            {"M", "mnopqrstuvwxyzabcdefghijkl"},
            {"N", "nopqrstuvwxyzabcdefghijklm"},
            {"O", "opqrstuvwxyzabcdefghijklmn"},
            {"P", "pqrstuvwxyzabcdefghijklmno"},
            {"Q", "qrstuvwxyzabcdefghijklmnop"},
            {"R", "rstuvwxyzabcdefghijklmnopq"},
            {"S", "stuvwxyzabcdefghijklmnopqr"},
            {"T", "tuvwxyzabcdefghijklmnopqrs"},
            {"U", "uvwxyzabcdefghijklmnopqrst"},
            {"V", "vwxyzabcdefghijklmnopqrstu"},
            {"W", "wxyzabcdefghijklmnopqrstuv"},
            {"X", "xyzabcdefghijklmnopqrstuvw"},
            {"Y", "yzabcdefghijklmnopqrstuvwx"},
            {"Z", "zabcdefghijklmnopqrstuvwxy"}
        };

        public string GenerateSequence(string secretLetter)
        {
            if (!encryptionLibrary.ContainsKey(secretLetter.ToUpper())) { throw new ArgumentOutOfRangeException(); }
            return encryptionLibrary[secretLetter.ToUpper()];
        }
    }
}
