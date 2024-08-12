using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore;
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        Debug.Log(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
