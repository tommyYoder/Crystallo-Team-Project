using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAch : MonoBehaviour
{
    public Player player;

    
    // Update is called once per frame
    void Update()
    {
        if (player.score >= 30000)
        {
            ScoreMet();
        }
        if(player.deaths <= 10)
        {
            DeathMet();
        }
    }

    public void ScoreMet()
    {
        HighScoreAchievement.scoreCount = 4;
        //LockAch.Instance.imageObject.SetActive(false);
    }
    public void DeathMet()
    {
        HighScoreAchievement.deathCount = 2;
    }
 
}
