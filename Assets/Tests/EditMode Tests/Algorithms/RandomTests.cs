using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ChocoUtil.Algorithms.Tests
{
    public class RandomTests
    {
        [Test]
        public void TotalWeightTest()
        {
            const float w0 = 2.0f, w1 = 1.0f, w2 = 5.0f, w3 = 5.0f, w4 = 4.0f;
            var choices = new WeightedValue<int>[]
            {
                new(w0, 0),
                new(w1, 1),
                new(w2, 2),
                new(w3, 3),
                new(w4, 4),
            };
            const float ans = w0 + w1 + w2 + w3 + w4;
            float wt = Random.TotalWeight(choices);
            Assert.IsTrue(Mathf.Approximately(wt, ans), $"Expected: {ans}, but got: {wt}");
        }
        [Test]
        public void SelectTest()
        {
            const int NUM_TRIALS = 10000;
            const float SAFE_RANGE = 0.05f;
            var choices = new WeightedValue<int>[]
            {
                new(1.0f, 0),
                new(1.0f, 1),
                new(1.0f, 2),
                new(1.0f, 3),
                new(1.0f, 4),
            };
            float totalWeight = Random.TotalWeight(choices);
            Dictionary<int, int> histogram = new();
            foreach (var choice in choices) histogram[choice.value] = 0;
            for (int round = 0; round < NUM_TRIALS; round++)
            {
                int selected = Random.Select(choices);
                histogram[selected] = histogram[selected] + 1;
            }
            foreach (var choice in choices)
            {
                float expectedFrequency = choice.weight / totalWeight;
                float actualFrequency = (float)histogram[choice.value] / NUM_TRIALS;
                if (Mathf.Abs(expectedFrequency - actualFrequency) > SAFE_RANGE)
                {
                    Assert.Inconclusive($"For choice {choice.value}, " +
                        $"expected frequency: {expectedFrequency}, " +
                        $"actual frequency: {actualFrequency}, " +
                        $"difference is more than {SAFE_RANGE}.");
                }
            }
        }
    }
}