using System.Collections.Generic;

namespace My_Assets.Scripts
{
    public static class FisherYatesAlgorithm
    {
        // Shuffle the list using Fisher-Yates algorithm  ref https://www.geeksforgeeks.org/shuffle-a-given-array-using-fisher-yates-shuffle-algorithm/
        public static void ShuffleList<T>(List<T> list)
        {
            System.Random random = new System.Random();
            int listLength = list.Count;
            for (int i = listLength - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}