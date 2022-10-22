using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ChocoUtil.Algorithms;
public class InterpTests
{
    [UnityTest]
    public IEnumerator GetStepsTest()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        
        float ansT = 0;
        const float testDuration = 1.1f;
        float startTime = Time.time;
        foreach(float t in Interp.GetSteps(testDuration, Ease.Linear, false))
        {
            Assert.IsTrue(Mathf.Approximately(t, ansT), $"Expected {ansT}, but got {t}");
            yield return null;
            ansT = Ease.Linear((Time.time - startTime) / testDuration);
        }
        
        ansT = 0;
        startTime = Time.time;
        foreach(float t in Interp.GetSteps(testDuration, Ease.InQuad, false))
        {
            Assert.IsTrue(Mathf.Approximately(t, ansT), $"Expected {ansT}, but got {t}");
            yield return null;
            ansT = Ease.InQuad((Time.time - startTime) / testDuration);
        }
    }
}
