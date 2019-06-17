using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockAch : MonoBehaviour
{
   // public static LockAch Instance { get; private set; }

    //ScoreObjects
    public GameObject imageObject;
    public GameObject imageObjectScoreHardMode;

    //DeathObjects
    public GameObject imageObjectDeath;
    public GameObject imageObjectDeathHardMode;

    //SecretPortals
    public GameObject imageObjectSecretPortal;
    public GameObject imageObjectSecretWaterPortal;

    //Timed Events Normal
    public GameObject imageObjectDungeonNormal;
    public GameObject imageObjectSecondNormal;
    public GameObject imageObjectWaterNormal;
    public GameObject imageObjectFireNormal;
    public GameObject imageObjectSFinalNormal;

    //Timed Events Hard
    public GameObject imageObjectDungeonHard;
    public GameObject imageObjectSecondHard;
    public GameObject imageObjectWaterHard;
    public GameObject imageObjectFireHard;
    public GameObject imageObjectSFinalHard;

    //SecretCandy Events Normal
    public GameObject imageCandyDungeonNormal;
    public GameObject imageCandyWaterNormall;
    public GameObject imageCandyWaterSecretNormal;
    public GameObject imageCandyFireNormal;
    public GameObject imageCandyFinalNormal;

    //SecretCandy Events Hard
    public GameObject imageCandyDungeonHard;
    public GameObject imageCandyWaterHard;
    public GameObject imageCandyWaterSecretHard;
    public GameObject imageCandyFireHard;
    public GameObject imageCandyFinalHard;

    //Score values
    public static int value = 0;
    public static int valueScoreHardMode = 0;

    //Death values
    public static int valueDeath = 0;
    public static int valueDeathHardMode = 0;

    //SecretPortal Values
    public static int valueSecretPortal = 0;
    public static int valueSecretWaterPortal = 0;

    //Normal Timed Events
    public static int valueTimedDungeon = 0;
    public static int valueTimedSecond = 0;
    public static int valueTimedWater = 0;
    public static int valueTimedFire = 0;
    public static int valueTimedFinal = 0;

    //Hard Timed Events
    public static int valueTimedDungeon1 = 0;
    public static int valueTimedSecond1 = 0;
    public static int valueTimedWater1 = 0;
    public static int valueTimedFire1 = 0;
    public static int valueTimedFinal1 = 0;

    //SecretCandy NormalMode
    public static int valueCandyDungeon = 0;
    public static int valueWaterCandy = 0;
    public static int valueWaterCandySecret = 0;
    public static int valueFireCandy = 0;
    public static int valueFinalCandy = 0;

    //SecretCandy HardMode
    public static int valueCandyDungeon1 = 0;
    public static int valueWaterCandy1 = 0;
    public static int valueWaterCandySecret1 = 0;
    public static int valueFireCandy1 = 0;
    public static int valueFinalCandy1 = 0;


    //Score and Death Ach
    public HighScoreAchievement highScoreAchievement;
    public HighScoreAchievement1 highScoreAchievement1;

    //SecretPortals Ach
    public SecretPortalAch secretPortalAch;

    //Timed Ach
    public TimerAch timerAch;

    //SecretCandy Ach
    public GlobalAchievements globalAch;
    public GlobalAchievements1 globalAch1;
    public GlobalAchievements2 globalAch2;
    public GlobalAchievements3 globalAch3;
    public GlobalAchievements4 globalAch4;

    private void Awake()
    {

        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //    imageObject.SetActive(true);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

     void Update()
    {
        //HighScore
        if (highScoreAchievement.scoreCode == 4)
        {
            IsUnlocked();
        }
        else
        {
            IsLocked();
        }
        if(highScoreAchievement1.scoreCode1 == 5)
        {
            IsUnlocked1();
        }
        else
        {
            IsLocked1();
        }

        //DeathScore
        if (highScoreAchievement.deathCode == 2)
        {
            IsUnlocked2();
        }
        else
        {
            IsLocked2();
        }
        if (highScoreAchievement1.deathCode1 == 3)
        {
            IsUnlocked3();
        }
        else
        {
            IsLocked3();
        }

        //SecretPortal

        if (secretPortalAch.secretPortalCode == 2)
        {
            IsUnlocked4();
        }
        else
        {
            IsLocked4();
        }
        if (secretPortalAch.secretPortalCode1 == 3)
        {
            IsUnlocked5();
        }
        else
        {
            IsLocked5();
        }

        //Timer
        if (timerAch.timerCode == 150)
        {
            IsUnlocked6();
        }
        else
        {
            IsLocked6();
        }
        if (timerAch.timerCode1 == 65)
        {
            IsUnlocked7();
        }
        else
        {
            IsLocked7();
        }
        if (timerAch.timerCode2 == 150)
        {
            IsUnlocked8();
        }
        else
        {
            IsLocked8();
        }
        if (timerAch.timerCode3 == 150)
        {
            IsUnlocked9();
        }
        else
        {
            IsLocked9();
        }
        if (timerAch.timerCode4 == 150)
        {
            IsUnlocked10();
        }
        else
        {
            IsLocked10();
        }

        //HardModeTimer
        if (timerAch.timerCode5 == 200)
        {
            IsUnlocked11();
        }
        else
        {
            IsLocked11();
        }
        if (timerAch.timerCode6 == 80)
        {
            IsUnlocked12();
        }
        else
        {
            IsLocked12();
        }
        if (timerAch.timerCode7 == 200)
        {
            IsUnlocked13();
        }
        else
        {
            IsLocked13();
        }
        if (timerAch.timerCode8 == 200)
        {
            IsUnlocked14();
        }
        else
        {
            IsLocked14();
        }
        if (timerAch.timerCode9 == 200)
        {
            IsUnlocked15();
        }
        else
        {
            IsLocked15();
        }

        //SecretCandy Normal Mode

        if (globalAch.candyCode == 1)
        {
            IsUnlocked16();
        }
        else
        {
            IsLocked16();
        }
        if (globalAch1.candyCodeWater == 2)
        {
            IsUnlocked17();
        }
        else
        {
            IsLocked17();
        }
        if (globalAch2.candyCodeWaterHidden == 3)
        {
            IsUnlocked18();
        }
        else
        {
            IsLocked18();
        }
        if (globalAch3.candyCodeFire == 4)
        {
            IsUnlocked19();
        }
        else
        {
            IsLocked19();
        }
        if (globalAch4.candyCodeLastLevel == 5)
        {
            IsUnlocked20();
        }
        else
        {
            IsLocked20();
        }

        //SecretCandy HardMode

        if (globalAch.candyCodeHardMode == 6)
        {
            IsUnlocked21();
        }
        else
        {
            IsLocked21();
        }
        if (globalAch1.candyCodeWaterHardMode == 7)
        {
            IsUnlocked22();
        }
        else
        {
            IsLocked22();
        }
        if (globalAch2.candyCodeWaterHiddenhardMode == 8)
        {
            IsUnlocked23();
        }
        else
        {
            IsLocked23();
        }
        if (globalAch3.candyCodeFireHardMode == 9)
        {
            IsUnlocked24();
        }
        else
        {
            IsLocked24();
        }
        if (globalAch4.candyCodeLastLevelHardMode == 10)
        {
            IsUnlocked25();
        }
        else
        {
            IsLocked25();
        }
    }

    //HighScore
     void IsLocked()
    {
        imageObject.SetActive(true);
    }
     void IsUnlocked()
    {
        imageObject.SetActive(false);
    }
    void IsLocked1()
    {
        imageObjectScoreHardMode.SetActive(true);
    }
    void IsUnlocked1()
    {
        imageObjectScoreHardMode.SetActive(false);
    }

    //Deaths
    void IsLocked2()
    {
        imageObjectDeath.SetActive(true);
    }
    void IsUnlocked2()
    {
        imageObjectDeath.SetActive(false);
    }
    void IsLocked3()
    {
        imageObjectDeathHardMode.SetActive(true);
    }
    void IsUnlocked3()
    {
        imageObjectDeathHardMode.SetActive(false);
    }

    //SecretPortal
    void IsLocked4()
    {
        imageObjectSecretPortal.SetActive(true);
    }
    void IsUnlocked4()
    {
        imageObjectSecretPortal.SetActive(false);
    }
    void IsLocked5()
    {
        imageObjectSecretWaterPortal.SetActive(true);
    }
    void IsUnlocked5()
    {
        imageObjectSecretWaterPortal.SetActive(false);
    }

    //Timer 
    void IsLocked6()
    {
        imageObjectDungeonNormal.SetActive(true);
    }
    void IsUnlocked6()
    {
        imageObjectDungeonNormal.SetActive(false);
    }
    void IsLocked7()
    {
        imageObjectSecondNormal.SetActive(true);
    }
    void IsUnlocked7()
    {
        imageObjectSecondNormal.SetActive(false);
    }
    void IsLocked8()
    {
        imageObjectWaterNormal.SetActive(true);
    }
    void IsUnlocked8()
    {
        imageObjectWaterNormal.SetActive(false);
    }
    void IsLocked9()
    {
        imageObjectFireNormal.SetActive(true);
    }
    void IsUnlocked9()
    {
        imageObjectFireNormal.SetActive(false);
    }
    void IsLocked10()
    {
        imageObjectSFinalNormal.SetActive(true);
    }
    void IsUnlocked10()
    {
        imageObjectSFinalNormal.SetActive(false);
    }

    //HardMode Timer
    void IsLocked11()
    {
        imageObjectDungeonHard.SetActive(true);
    }
    void IsUnlocked11()
    {
        imageObjectDungeonHard.SetActive(false);
    }
    void IsLocked12()
    {
        imageObjectSecondHard.SetActive(true);
    }
    void IsUnlocked12()
    {
        imageObjectSecondHard.SetActive(false);
    }
    void IsLocked13()
    {
        imageObjectWaterHard.SetActive(true);
    }
    void IsUnlocked13()
    {
        imageObjectWaterHard.SetActive(false);
    }
    void IsLocked14()
    {
        imageObjectFireHard.SetActive(true);
    }
    void IsUnlocked14()
    {
        imageObjectFireHard.SetActive(false);
    }
    void IsLocked15()
    {
        imageObjectSFinalHard.SetActive(true);
    }
    void IsUnlocked15()
    {
        imageObjectSFinalHard.SetActive(false);
    }


    //SecretCandy NormalMode

    void IsLocked16()
    {
        imageCandyDungeonNormal.SetActive(true);
    }
    void IsUnlocked16()
    {
        imageCandyDungeonNormal.SetActive(false);
    }
    void IsLocked17()
    {
        imageCandyWaterNormall.SetActive(true);
    }
    void IsUnlocked17()
    {
        imageCandyWaterNormall.SetActive(false);
    }
    void IsLocked18()
    {
        imageCandyWaterSecretNormal.SetActive(true);
    }
    void IsUnlocked18()
    {
        imageCandyWaterSecretNormal.SetActive(false);
    }
    void IsLocked19()
    {
        imageCandyFireNormal.SetActive(true);
    }
    void IsUnlocked19()
    {
        imageCandyFireNormal.SetActive(false);
    }
    void IsLocked20()
    {
        imageCandyFinalNormal.SetActive(true);
    }
    void IsUnlocked20()
    {
        imageCandyFinalNormal.SetActive(false);
    }

    //SecretCandy HardMode

    void IsLocked21()
    {
        imageCandyDungeonHard.SetActive(true);
    }
    void IsUnlocked21()
    {
        imageCandyDungeonHard.SetActive(false);
    }
    void IsLocked22()
    {
        imageCandyWaterHard.SetActive(true);
    }
    void IsUnlocked22()
    {
        imageCandyWaterHard.SetActive(false);
    }
    void IsLocked23()
    {
        imageCandyWaterSecretHard.SetActive(true);
    }
    void IsUnlocked23()
    {
        imageCandyWaterSecretHard.SetActive(false);
    }
    void IsLocked24()
    {
        imageCandyFireHard.SetActive(true);
    }
    void IsUnlocked24()
    {
        imageCandyFireHard.SetActive(false);
    }
    void IsLocked25()
    {
        imageCandyFinalHard.SetActive(true);
    }
    void IsUnlocked25()
    {
        imageCandyFinalHard.SetActive(false);
    }
}

