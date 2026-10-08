using dz_4.enums;

namespace dz_4.structs
{
    public struct Grandfather
    {
        public string Name;
        public GrumpinessLevel Grumpiness;
        public string[] Phrases;
        public int Bruises;

        public Grandfather(string name, GrumpinessLevel grumpiness, string[] phrases)
        {
            Name = name;
            Grumpiness = grumpiness;
            Phrases = phrases;
            Bruises = 0;
        }

        /// <summary>
        /// роверяет лексику деда на наличие "матерных" слов
        /// </summary>
        /// <param name="grandfather"></param>
        /// <param name="swearWords"></param>
        /// <returns></returns>
        public static int CheckPhrases(Grandfather grandfather, params string[] swearWords)
        {
            int bruises = 0;
            foreach (string phrase in grandfather.Phrases)
            {
                foreach (string swear in swearWords)
                {
                    if (phrase.ToLower().Contains(swear.ToLower()))
                        bruises++;
                }
            }
            return bruises;
        }
    }
}