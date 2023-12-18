namespace api
{
    public class Censor
    {
        /// <summary>
        /// Lista słów, które mają zostać ocenzurowane w tekście
        /// </summary>
        public List<string> Blacklist { get; set; } = new List<string>();

        /// <summary>
        /// Funkcja cenzurująca pojedyncze słowo.
        /// 
        /// Słowa, które znajdują się na liście <see cref="Blacklist"/> mają zostać zamienione
        /// na pierwszą literę oraz taką liczbę gwiazdek, ile miało oryginalne słowo,
        /// np. "bomba" na "b****"
        /// </summary>
        /// <param name="word">Słowo nieocenzurowane</param>
        /// <returns>Słowo ocenzurowane</returns>
        public string CensorWord(string word)
        {
            if (Blacklist.Any(blacklistedWord => word.ToLower() == blacklistedWord.ToLower()))
            {
                char firstLetter = word[0];
                string stars = new string('*', word.Length - 1);
                return $"{firstLetter}{stars}";
            }
            else
            {
                return word;
            }
        }

        /// <summary>
        /// Funkcja cenzurująca cały tekst, który możę się składać z wielu słów.
        /// 
        /// Można zignorować znaki przestankowe (,."?! itp.) oraz nadmiarowe spacje w środku tekstu.
        /// </summary>
        /// <param name="text">Tekst nieocenzurowany</param>
        /// <returns>Tekst ocenzurowany</returns>
        public string CensorText(string text)
        {
            var words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CensorWord(words[i]);
            }

            return string.Join(" ", words);
        }
    }
}
