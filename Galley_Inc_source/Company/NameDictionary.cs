using TGL_Practice_2.Persons;

namespace TGL_Practice_2.Company
{
    internal static class RandomPersonGenerator
    {
        private static Random random = new();
        private static string[] _nameArray = new string[] {
            "James",
            "Caytlin",
            "Hank",
            "Mary",
            "Vadim",
            "Dionis",
            "Kris",
            "Pavel",
            "Xardas",
            "Jacob"
        };

        public static Person GetRandomPerson()
        {
            return new Person(_nameArray[random.Next(0,_nameArray.Length - 1)],
                new DateOnly(1985 + random.Next(0, 10), random.Next(1, 12), random.Next(1, 28)));
        }
    }
}
