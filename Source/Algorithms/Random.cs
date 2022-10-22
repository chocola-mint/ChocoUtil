using System;
using System.Collections.Generic;
using System.Text;

namespace ChocoUtil.Algorithms
{
    public static class Random
    {
        public static float TotalWeight<T>(WeightedValue<T>[] choices)
        {
            float totalWeight = 0;
            for (int i = 0; i < choices.Length; i++)
                totalWeight += choices[i].weight;
            return totalWeight;
        }
        /// <summary>
        /// Select from an array of weighted values.
        /// <br></br>
        /// <br></br>
        /// Time complexity: O(n), where n is the length of the input array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="choices"></param>
        /// <returns>The value selected, randomly.</returns>
        public static T Select<T>(WeightedValue<T>[] choices)
        {
            float totalWeight = TotalWeight(choices);
            float weightKey = UnityEngine.Random.Range(0.0f, totalWeight);
            float currentWeight = 0.0f;
            for(int i = 0; i < choices.Length; i++)
            {
                float nextWeight = currentWeight + choices[i].weight;
                if (nextWeight >= weightKey)
                    return choices[i].value;
                else currentWeight = nextWeight;
            }
            return choices[choices.Length - 1].value;
        }

        /// <summary>
        /// Performs the Fisher-Yates shuffle on the input array.
        /// <br></br><br></br>
        /// Time complexity: O(n), where n is the length of the input array.
        /// <br></br><br></br>
        /// Based on:
        /// <br></br>
        /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#The_modern_algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public static void InplaceShuffle<T>(T[] items)
        {
            int n = items.Length;
            for (int i = n - 1; i >= 1; i--) 
            { 
                // Note: Using int version of Random.Range
                int j = UnityEngine.Random.Range(0, i);
                // Swap i and j
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
        /// <summary>
        /// The immutable version of <see cref="InplaceShuffle{T}(T[])"/>. 
        /// <br></br>
        /// Returns a shuffled copy of the input array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static T[] Shuffle<T>(T[] items)
        {
            T[] copy = new T[items.Length];
            Array.Copy(items, 0, copy, 0, items.Length);
            InplaceShuffle(copy);
            return copy;
        }
    }
}
