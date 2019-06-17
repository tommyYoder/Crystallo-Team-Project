using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAch1 : MonoBehaviour
{
    public Player player;

    
    // Update is called once per frame
    void Update()
    {
      
        if(player.score >= 25000)
        {
            ScoreMetHardMode();
        }
        if (player.deaths <= 5)
        {
            DeathMet1();
        }
    }

  
    public void ScoreMetHardMode()
    {
        HighScoreAchievement1.scoreCount1 = 5;
    }
    public void DeathMet1()
    {
        HighScoreAchievement1.deathCount1 = 3;
    }
}
