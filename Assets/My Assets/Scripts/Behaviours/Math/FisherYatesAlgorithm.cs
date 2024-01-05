using System.Collections.Generic;

namespace My_Assets.Scripts
{
    /// <summary>
    /// A static class providing an implementation of the Fisher-Yates shuffle algorithm.
    /// The ShuffleList<T> method shuffles the elements of a generic List<T> in a random order.
    /// code ref: https://www.geeksforgeeks.org/shuffle-a-given-array-using-fisher-yates-shuffle-algorithm/
    /// </summary>
    public static class FisherYatesAlgorithm
    {
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