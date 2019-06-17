using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    public MonoBehaviour[] disableScripts;
    public MonoBehaviour[] playerDisableScripts;
    public MonoBehaviour[] timerDisableScripts;

    public GameObject mainCamera;
    public float speed;
    public Text scoreText;
    public float seconds;
    public int Health;
    public int deaths;
    public Text deathsText;
    public Animator burnAnim;
    public GameObject lightObject;

    public GameObject deathParticle;

    public GameObject shatteredOrbart;
    public Transform orbartNonShattered;

    public GameObject dustParticle;
    public GameObject lavaParticle;
    public Transform dustSpawnPoint;

    public bool isMoving = false;
    public bool isFalling = false;
    private bool canDoAction = true;

    public SpikeSpeed bounceObject;
    public SpikeSpeed1 bounceObject1;
  

    public AudioSource MoveSound;
    public AudioSource CoinSound;
    public AudioSource underwaterCoinSound;
    public AudioSource SpeedSound;
    public AudioSource JumpSound;
    public AudioSource underwaterJumpSound;
    public AudioSource CandySound;
    public AudioSource TimerSound;
    public AudioSource underwaterTimerSound;
    public AudioSource DoorSound;
    public AudioSource underwaterDoorSound;
    public AudioSource KnightSound;
    public AudioSource DeathSound;
    public AudioSource deathUnderwaterSound;
    public AudioSource lavaDeath;
    public AudioSource checkPointSound;
    public AudioSource underwaterCheckpointSound;
    public AudioSource flameSound;
    public AudioSource equipSound;
    public AudioSource underwaterEquipSound;
    public AudioSource deathLaughSoundMine;
    public AudioSource deathLaughSoundWater;
    public AudioSource deathLaughSoundLava;
    public AudioSource whalesound;

    public GameObject LoadingScreen;
    public Slider slider;
    public Text percText;
    public float delay = 2.5f;
    public string newGameLevel;
    public Animator loadingScreen;
    public Animator Fade;
    public Animator fade;

    public Animator deathScreen;

    public GameObject movingDustParticle;

    public float jumpHeight = 8;
    public Underwater underwater;
    public Underwater1 underwater1;

    public GameObject orbartEye;
    public GameObject keyObject;

    public bool isDead = false;

    public Rigidbody rb;
    public int score;
    private int count;
   

    public WallSpikeTrigger WallSpikeTrigger;
    public FloorSpikeTrigger FloorSpikeTrigger;
    public SwooshTrigger SwooshTrigger;

    public float timer = .05f;

    public myTimer2 myTimer2;
    public myTimer3 myTimer3;
    public myTimer4 myTimer4;


    private bool IsTiming = false;

    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public GameObject gameObject;
        public string playerPrefKey;
    }

    public ButtonPlayerPrefs[] buttons;

    public static int releasedLevelStatic = 1;
    public int releasedLevel;
    public string nextLevel;

    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100;
    }

    //Kills player when falling off the game level in the Y direction.
    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -225;

    // Looks to see if the next level is unlocked. If it's, then the level button is unlocked to play. If not, then the button lock is not activated in the menu screen.
    void Awake()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            releasedLevelStatic = PlayerPrefs.GetInt("Level", releasedLevelStatic);

        }
    }


    void Start()
    {
        AudioListener.pause = false;                                           // Will allow sound to play.
        rb = GetComponent<Rigidbody>();                                        // Looks for Rigidbody.
         
        rb.useGravity = true;                                                 // isGravity is set to true.
         
        rb.isKinematic = false;                                              // isKinematic is set to false. 

        isFalling = false;                                                  // isFalling is set to false.

        score = PlayerPrefs.GetInt ("CurrentScore");                       // Score is set to Player Prefs.
         
        setScoreText();                                                   // Looks for score text.

        count = 0;                                                       // Counter is set to 0.

        speed = 7005;                                                   // Speed of ball is set to 7005.

        seconds = 0;                                                   // Seconds is set to 0.

        deaths = PlayerPrefs.GetInt("DeathCurrentLives");             // Deaths is set to Player Prefs.

        setDeathsText();                                             // Looks fr death text.

        keyObject.SetActive(true);                                  // Makes the key active.

        GetComponent<Collider>().enabled = true;                    // Collider is set to true.

        isDead = false;

        scoreText = GameObject.Find("ScoreText").GetComponentInChildren<Text>();      // Looks for score text on the player and player clone.

        for (int i = 0; i < buttons.Length; i++)                  // Looks to see if the playerPrefKey is greater than the previous key to unlock the level.
        {
            int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey, 0);
        }

    }

    //Speed Power-up timer begind by setting seconds to 0.
    void beginTimer()
    {
        seconds = 0;
        IsTiming = false;
    }

    void Update()
    {
        //Kills player when out of bounds
        if (transform.position.y <= fallBoundary)
            DamagePlayer(9999999);
        setScoreText();
        //Speed Power-up timer lowers seconds when isTiming is true.
        if (IsTiming)
        {
            seconds -= Time.deltaTime;
        }
        if (seconds <= 0)                  // if seconds is 0, then speed returns back to normal and seconds goes back to 5 seconds.
        {
            IsTiming = false;
            count = count - 1;
            speed = speed - 1005;
            seconds = seconds + 5;


        }

        // Looks to see if the player is moving and will play sound depending on if the Left Analog stick is pointed forward.

        if (Input.GetAxisRaw("Vertical") < 0f || Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Horizontal") < 0f
            || Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {

            if (!MoveSound.isPlaying && !isMoving)
            {
                isMoving = true;
                Water();
            }
        }

        // If not, then moving sound will not play.
        else
        {
            isMoving = false;
            MoveSound.Stop();
            MoveSound.loop = false;
            StartCoroutine(Stopping());
        }

        // Allows for the player's speed to increase when L3 is pressed, and go back to normal is not pressed.
        if (Input.GetKeyDown("joystick button 8") || Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed + 1500;
        }
        else
        {
            if (Input.GetKeyUp("joystick button 8") || Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = speed - 1500;
            }
        }

        // Looks to see if L1 is pressed to turn off the eye gameobject with sound.
        if (canDoAction == true && Input.GetKeyDown("joystick button 4") == true && Input.GetKeyDown("joystick button 5") == false)
        {
            orbartEye.SetActive(false);
            equipSound.Play();
            StartCoroutine(Timer());
            NormalEquip();


        }
        // Looks to see if R2 can be pressed to turn on the eye gameobject with sound.
        if (canDoAction == false && Input.GetKeyDown("joystick button 5") == true && Input.GetKeyDown("joystick button 4") == false)
        {
            equipSound.Play();
            orbartEye.SetActive(true);
            StartCoroutine(Timer2());
            NormalEquip();

        }

        // Looks to see if 1 is pressed to turn off the eye gameobject with sound.
        if (canDoAction == true && Input.GetKeyDown(KeyCode.Alpha1) == true && Input.GetKeyDown(KeyCode.Alpha2) == false)
        {
            orbartEye.SetActive(false);
            equipSound.Play();
            StartCoroutine(Timer());
            NormalEquip();


        }
        // Looks to see if 2 can be pressed to turn on the eye gameobject with sound.
        if (canDoAction == false && Input.GetKeyDown(KeyCode.Alpha2) == true && Input.GetKeyDown(KeyCode.Alpha1) == false)
        {
            equipSound.Play();
            orbartEye.SetActive(true);
            StartCoroutine(Timer2());
            NormalEquip();

        }

        //Looks to see if X is pressed on the controller and if underwater is set to false, then normal jump sound will play.
        if (Input.GetKeyDown("joystick button 0") && !isFalling && underwater.isUnderwater == false)
        {

            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            underwater.isUnderwater = false;
            JumpSound.Play();
            underwaterJumpSound.Stop();
            Instantiate(dustParticle, dustSpawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            // If X is pressed on the controller and is underwater, then the underwater jump sound will play.
            if (Input.GetKeyUp("joystick button 0") && !isFalling && underwater.isUnderwater == true)
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isFalling = true;
                underwater.isUnderwater = true;
                JumpSound.Stop();
                underwaterJumpSound.Play();
                Instantiate(dustParticle, dustSpawnPoint.transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown("joystick button 0") && !isFalling && underwater1.isUnderwater == false)
            {

                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                underwater.isUnderwater = false;
                JumpSound.Play();
                underwaterJumpSound.Stop();
                Instantiate(dustParticle, dustSpawnPoint.transform.position, Quaternion.identity);
            }
            else
            {
                // If X is pressed on the controller and is underwater, then the underwater jump sound will play.
                if (Input.GetKeyUp("joystick button 0") && !isFalling && underwater1.isUnderwater == true)
                {
                    rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                    isFalling = true;
                    underwater.isUnderwater = true;
                    JumpSound.Stop();
                    underwaterJumpSound.Play();
                    Instantiate(dustParticle, dustSpawnPoint.transform.position, Quaternion.identity);
                }
            }
        }



        //Looks to see if space bar is pressed and if underwater is set to false, then normal jump sound will play.
        if (Input.GetKeyDown(KeyCode.Space) && !isFalling && underwater.isUnderwater == false)
        {

            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            underwater.isUnderwater = false;
            JumpSound.Play();
            underwaterJumpSound.Stop();
            Instantiate(dustParticle, dustSpawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            // If space bar is pressed and is underwater, then the underwater jump sound will play.
            if (Input.GetKeyUp(KeyCode.Space) && !isFalling && underwater.isUnderwater == true)
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isFalling = true;
                underwater.isUnderwater = true;
                JumpSound.Stop();
                underwaterJumpSound.Play();
                Instantiate(dustParticle, dustSpawnPoint.transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.Space) && !isFalling && underwater1.isUnderwater == false)
            {

                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                underwater.isUnderwater = false;
                JumpSound.Play();
                underwaterJumpSound.Stop();
                Instantiate(dustParticle, dustSpawnPoint.transform.position, Quaternion.identity);
            }
            else
            {
                // If space bar is pressed and is underwater, then the underwater jump sound will play.
                if (Input.GetKeyUp(KeyCode.Space) && !isFalling && underwater1.isUnderwater == true)
                {
                    rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                    isFalling = true;
                    underwater.isUnderwater = true;
                    JumpSound.Stop();
                    underwaterJumpSound.Play();
                    Instantiate(dustParticle, dustSpawnPoint.transform.position, Quaternion.identity);
                }
            }
        }
    }


    // Looks for ground tag before jump sequence is set to true.
    void OnCollisionStay(Collision floor)
    {
        if (floor.transform.tag == "Ground")
            isFalling = false;
        
    }


    //new way to prevent double jumping, thanks to Lord Xtheth in the comments
    public void OnCollisionExit(Collision col)
    {
        isFalling = true;
      
    }


        void FixedUpdate()
    {
        // Moves the player in the horizontal and vertical axis. Camera rotates with each axis that the rigidbody adds force to move the sphere.
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(movementHorizontal, 0.0f, movementVertical);
        movementVector = mainCamera.transform.TransformDirection(movementVector);

        GetComponent<Rigidbody>().AddForce(movementVector * speed * Time.deltaTime);


    }


    public IEnumerator Stopping()
    {
        rb.angularDrag = 15f;
        rb.drag = 8f;

        yield return new WaitForSeconds(.15f);

        rb.angularDrag = 1f;
        rb.drag = .1f;
    }
    // Looks to see if normal rolling sound should play or not.
    public void Water()
    {
        if (underwater.isUnderwater == false)
        {
            MoveSound.Play();
            MoveSound.loop = true;
            MoveSound.volume = 1;
           
        }
        else
        {
            if (underwater.isUnderwater == true)
            {
                MoveSound.Play();
                MoveSound.loop = true;
                MoveSound.volume = .3f;
            }
            else
            {
                if (underwater1.isUnderwater == false)
                {
                    MoveSound.Play();
                    MoveSound.loop = true;
                    MoveSound.volume = 1;
                }
                else
                {
                    if (underwater1.isUnderwater == true)
                    {
                        MoveSound.Play();
                        MoveSound.loop = true;
                        MoveSound.volume = .3f;
                    }
                }
            }
        }
    }


    // Looks to see if you are underwater or not. Plays sound depending on underwater status.
    public void NormalEquip()
    {
        if (underwater.isUnderwater == false)
        {
            equipSound.Play();
            underwaterEquipSound.Stop();
        }
        else
        {
            if (underwater.isUnderwater == true)
            {
                equipSound.Stop();
                underwaterEquipSound.Play();
            }
            if (underwater1.isUnderwater == false)
            {
                equipSound.Play();
                underwaterEquipSound.Stop();
            }
            else
            {
                if (underwater1.isUnderwater == true)
                {
                    equipSound.Stop();
                    underwaterEquipSound.Play();
                }
            }
        }
    }

    

    // Will enable 1 to be pressed again, and then disable 1 when timer is hit. This prevents spamming of the equip sound from playing.
    public IEnumerator Timer()
    {
        canDoAction = true;

        yield return new WaitForSeconds(timer);

        canDoAction = false;
    }

    // Will enable 2 to be pressed again, and then disable 2 when timer is hit. This prevents spamming of the equip sound from playing.
    public IEnumerator Timer2()
    {

        canDoAction = false;

        yield return new WaitForSeconds(timer);

        canDoAction = true;
    }

    // Triggered events for the player.
    IEnumerator OnTriggerEnter(Collider other)
    {
        

        //Speed Booster Power-up
        if (other.gameObject.tag == "Speed")
        {
            count = count + 1;
            speed = speed + 1005;
            SpeedSound.time = 5f;
            SpeedSound.Play();
            SpeedSound.SetScheduledEndTime(AudioSettings.dspTime + (5f - 0f));
            Destroy(other.gameObject);
            IsTiming = true;
        }

        //Destroy Objects
        if (other.gameObject.CompareTag("Pick Up"))
        {
            count = count + 1;
            score = score + 50;
            CoinSound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }
        //Destroy Objects
        if (other.gameObject.CompareTag("Bones"))
        {
            count = count + 1;
            score = score + 50;
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }
        //Collect Coins
        if (other.gameObject.CompareTag("Coin"))
        {
            count = count + 1;
            score = score + 75;
            CoinSound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }
        if (other.gameObject.CompareTag("CoinWater"))
        {
            count = count + 1;
            score = score + 75;
            underwaterCoinSound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }
        //Collect Huge Coin
        if (other.gameObject.CompareTag("Huge"))
        {
            count = count + 1;
            score = score + 1500;
            CoinSound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }
        if (other.gameObject.CompareTag("Candy"))
        {
            count = count + 1;
            GlobalAchievements.candyCount += 1;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        if (other.gameObject.CompareTag("CandyWater"))
        {
            count = count + 1;
            GlobalAchievements1.candyWaterCount += 2;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        if (other.gameObject.CompareTag("CandyWaterHidden"))
        {
            count = count + 1;
            GlobalAchievements2.candyWaterHiddenCount += 3;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        if (other.gameObject.CompareTag("FireCandy"))
        {
            count = count + 1;
            GlobalAchievements3.candyFireCount += 4;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        if (other.gameObject.CompareTag("FinalCandy"))
        {
            count = count + 1;
            GlobalAchievements4.candyLastLevelCount += 5;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        //Collect Candy Object
        if (other.gameObject.CompareTag("Candy1"))
        {
            count = count + 1;
            GlobalAchievements.candyCountHardMode += 6;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        if (other.gameObject.CompareTag("CandyWater1"))
        {
            count = count + 1;
            GlobalAchievements1.candyWaterHardModeCount += 7;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        if (other.gameObject.CompareTag("CandyWaterHidden1"))
        {
            count = count + 1;
            GlobalAchievements2.candyWaterHiddenCountHardMode += 8;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        if (other.gameObject.CompareTag("FireCandy1"))
        {
            count = count + 1;
            GlobalAchievements3.candyFireCountHardMode += 9;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        if (other.gameObject.CompareTag("FinalCandy1"))
        {
            count = count + 1;
            GlobalAchievements4.candyLastLevelCountHardMode += 10;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }

        //Death Event for majority of the levels.
        if (other.gameObject.CompareTag("Mine"))
        {
            isDead = true;
            deathScreen.SetBool("Nothing", true);
            GetComponent<Collider>().enabled = false;
            Instantiate(shatteredOrbart, orbartNonShattered.transform.position, Quaternion.identity);
            ToggleScripts(false);
            TogglePlayerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            count = count + 1;
            deaths = deaths + 1;
            setDeathsText();
            DeathSound.Play();
            MoveSound.volume = 0;
            deathLaughSoundMine.Play();
            bounceObject.speed = 0;
            bounceObject1.speed = 0;
           

            Instantiate(deathParticle, orbartNonShattered.transform.position, Quaternion.identity);


            PlayerPrefs.SetInt("DeathCurrentLives", deaths);

            yield return new WaitForSeconds(1);
            deathScreen.SetBool("FadeIn", true);
            deathScreen.SetBool("Nothing", false);
         

            yield return new WaitForSeconds(2);
            GetComponent<Collider>().enabled = true;
            rb.useGravity = true;
            rb.isKinematic = false;
            WallSpikeTrigger.WallSpikeSound.Stop();
            WallSpikeTrigger.WallSpikeSound.loop = false;
            FloorSpikeTrigger.FloorSpikeSound.Stop();
            FloorSpikeTrigger.FloorSpikeSound.loop = false;
            SwooshTrigger.SwooshSound.Stop();
            SwooshTrigger.SwooshSound.loop = false;
            ToggleScripts(true);
            isDead = false;


            yield return new WaitForSeconds(.5f);
            deathScreen.SetBool("FadeIn", false);
            deathScreen.SetBool("FadeOut", true);
           

            yield return new WaitForSeconds(.35f);
            deathScreen.SetBool("Nothing", true);
            deathScreen.SetBool("FadeOut", false);
            TogglePlayerScripts(true);
            MoveSound.Play();
            MoveSound.volume = 1;
            bounceObject.speed = 3;
            bounceObject1.speed = 4.5f;
        
        }

        //Death Event for underwater level
        if (other.gameObject.CompareTag("Mine2"))
        {
            deathScreen.SetBool("Nothing", true);
            GetComponent<Collider>().enabled = false;
            Instantiate(shatteredOrbart, orbartNonShattered.transform.position, Quaternion.identity);
            ToggleScripts(false);
            TogglePlayerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            count = count + 1;
            deaths = deaths + 1;
            setDeathsText();
            deathUnderwaterSound.Play();
            MoveSound.volume = 0;
            deathLaughSoundWater.Play();
            Instantiate(deathParticle, orbartNonShattered.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("DeathCurrentLives", deaths);

            yield return new WaitForSeconds(1);
            deathScreen.SetBool("FadeIn", true);
            deathScreen.SetBool("Nothing", false);

            yield return new WaitForSeconds(2);
            GetComponent<Collider>().enabled = true;
            rb.useGravity = true;
            rb.isKinematic = false;
            WallSpikeTrigger.WallSpikeSound.Stop();
            WallSpikeTrigger.WallSpikeSound.loop = false;
            FloorSpikeTrigger.FloorSpikeSound.Stop();
            FloorSpikeTrigger.FloorSpikeSound.loop = false;
            SwooshTrigger.SwooshSound.Stop();
            SwooshTrigger.SwooshSound.loop = false;
            whalesound.Stop();
            whalesound.loop = false;
            ToggleScripts(true);

            yield return new WaitForSeconds(.5f);
            deathScreen.SetBool("FadeIn", false);
            deathScreen.SetBool("FadeOut", true);

            yield return new WaitForSeconds(.35f);
            deathScreen.SetBool("Nothing", true);
            deathScreen.SetBool("FadeOut", false);
            TogglePlayerScripts(true);
            MoveSound.Play();
            MoveSound.volume = .3f;
        }

        //Death Event for the fire level
        if (other.gameObject.tag == "Lava")
        {
            deathScreen.SetBool("Nothing", true);
            burnAnim.SetBool("Nothing", false);
            burnAnim.SetBool("Burn", true);
            lightObject.SetActive(false);
            GetComponent<Collider>().enabled = false;
            ToggleScripts(false);
            TogglePlayerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            count = count + 1;
            deaths = deaths + 1;
            setDeathsText();
            lavaDeath.Play();
            MoveSound.volume = 0;
            deathLaughSoundLava.Play();
            Instantiate(lavaParticle, orbartNonShattered.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("DeathCurrentLives", deaths);

            yield return new WaitForSeconds(1);
            deathScreen.SetBool("FadeIn", true);
            deathScreen.SetBool("Nothing", false);

            yield return new WaitForSeconds(.5f);

            burnAnim.SetBool("Burn", false);
            burnAnim.SetBool("FadeIn", true);
            lightObject.SetActive(true);
            

            yield return new WaitForSeconds(2);
            GetComponent<Collider>().enabled = true;
            rb.useGravity = true;
            rb.isKinematic = false;
            WallSpikeTrigger.WallSpikeSound.Stop();
            WallSpikeTrigger.WallSpikeSound.loop = false;
            FloorSpikeTrigger.FloorSpikeSound.Stop();
            FloorSpikeTrigger.FloorSpikeSound.loop = false;
            SwooshTrigger.SwooshSound.Stop();
            SwooshTrigger.SwooshSound.loop = false;
            ToggleScripts(true);
            deathScreen.SetBool("FadeIn", false);
            deathScreen.SetBool("FadeOut", true);

          

            yield return new WaitForSeconds(.35f);
            deathScreen.SetBool("Nothing", true);
            deathScreen.SetBool("FadeOut", false);
            burnAnim.SetBool("FadeIn", false);
            burnAnim.SetBool("Nothing", true);
            TogglePlayerScripts(true);
            MoveSound.Play();
            MoveSound.volume = 1;
        }

        // First Level Key
        if (other.gameObject.tag == "Key")
        {
            if (myTimer2.myCoolTimer >= 150)
            {
                TimerAch.timerCount = 150;
            }
            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }

            keyObject.SetActive(false);
            ToggleTimerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.5f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            AudioListener.pause = true;               // Will stop all sounds from playing.

            yield return new WaitForSeconds(delay);

            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        // Hard mode first level Level Key
        if (other.gameObject.tag == "Key4")
        {
            if (myTimer2.myCoolTimer >= 200)
            {
                TimerAch.timerCount5 = 200;
            }

            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }

            keyObject.SetActive(false);
            ToggleTimerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.5f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            AudioListener.pause = true;               // Will stop all sounds from playing.

            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        // Water Normal and Destroyed water level keys
        if (other.gameObject.tag == "Key1")
        {
            if (myTimer4.myCoolTimer >= 150)
            {
                TimerAch.timerCount2 = 150;
            }

            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }

            keyObject.SetActive(false);
            ToggleTimerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            underwaterDoorSound.Play();
            yield return new WaitForSeconds(1.5f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            AudioListener.pause = true;               // Will stop all sounds from playing.

            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        // Hard mode Water Normal and Destroyed Water Level Keys
        if (other.gameObject.tag == "Key6")
        {
            if (myTimer4.myCoolTimer >= 200)
            {
                TimerAch.timerCount7 = 200;
            }

            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }

            keyObject.SetActive(false);
            ToggleTimerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            underwaterDoorSound.Play();
            yield return new WaitForSeconds(1.5f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            AudioListener.pause = true;               // Will stop all sounds from playing.

            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        // Escape Level Key
        if (other.gameObject.tag == "Key2")
        {
            if (myTimer2.myCoolTimer >= 65)
            {
                TimerAch.timerCount1 = 65;
            }
            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }
            keyObject.SetActive(false);
            ToggleTimerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            bounceObject.GetComponent<Rigidbody>().isKinematic = true;
            movingDustParticle.SetActive(false);



            yield return new WaitForSeconds(1.5f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            flameSound.Stop();
            AudioListener.pause = true;               // Will stop all sounds from playing.


            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        // Hard Mode Escape Level Key
        if (other.gameObject.tag == "Key5")
        {
            if (myTimer2.myCoolTimer >= 80)
            {
                TimerAch.timerCount6 = 80;
            }

            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }
            keyObject.SetActive(false);
            ToggleTimerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            bounceObject1.GetComponent<Rigidbody>().isKinematic = true;
            movingDustParticle.SetActive(false);

            yield return new WaitForSeconds(1.5f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            flameSound.Stop();
            AudioListener.pause = true;               // Will stop all sounds from playing.


            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        // Fire Level Key
        if (other.gameObject.tag == "Key3")
        {
            if (myTimer2.myCoolTimer >= 150)
            {
                TimerAch.timerCount3 = 150;
            }

            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }

            keyObject.SetActive(false);
            ToggleTimerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.5f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            AudioListener.pause = true;               // Will stop all sounds from playing.

            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        // Hard Mode Fire Level Key
        if (other.gameObject.tag == "Key7")
        {
            if (myTimer2.myCoolTimer >= 200)
            {
                TimerAch.timerCount8 = 200;
            }

            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }

            keyObject.SetActive(false);
            ToggleTimerScripts(false);
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.5f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            AudioListener.pause = true;               // Will stop all sounds from playing.

            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        // Knight Trigger
        if (other.gameObject.tag == "Knight")
        {
            if (myTimer2.myCoolTimer >= 150)
            {
                TimerAch.timerCount4 = 150;
            }

            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }
            rb.useGravity = false;
            ToggleTimerScripts(false);
            rb.isKinematic = true;
            KnightSound.Play();
            yield return new WaitForSeconds(2.25f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            AudioListener.pause = true;               // Will stop all sounds from playing.

            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        // Hard Mode Knight Trigger
        if (other.gameObject.tag == "Knight1")
        {
            if (myTimer2.myCoolTimer >= 200)
            {
                TimerAch.timerCount9 += 200;
            }

            if (releasedLevelStatic <= releasedLevel)
            {
                releasedLevelStatic = releasedLevel;
                PlayerPrefs.SetInt("Level", releasedLevelStatic);

            }
            rb.useGravity = false;
            ToggleTimerScripts(false);
            rb.isKinematic = true;
            KnightSound.Play();
            yield return new WaitForSeconds(2.25f);
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            AudioListener.pause = true;               // Will stop all sounds from playing.

            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

            // While loop that allows the game to load in the background. Perfect for loading bars or animations!
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
            }
        }

        //Add time to timer countdown
        if (other.gameObject.tag == "Timer2")
        {
            count = count + 1;
            myTimer2.myCoolTimer += 50;
            TimerSound.Play();
            Destroy(other.gameObject);
        }
        // Add time to bonus normal level
        if (other.gameObject.tag == "Timer3")
        {
            count = count + 1;
            myTimer3.myCoolTimer += 50;
            TimerSound.Play();
            Destroy(other.gameObject);
        }

        //Add time to underwatertimer countdown
        if (other.gameObject.tag == "UnderwaterTimer2")
        {
            count = count + 1;
            myTimer4.myCoolTimer += 50;
            underwaterTimerSound.Play();
            Destroy(other.gameObject);
        }
    }   
    
    //Sets score to UI board
    void setScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + score.ToString();
            PlayerPrefs.SetInt("CurrentScore", score);
        }
    }
    // Sets Death counter to UI board
    void setDeathsText()
    {

        if (deathsText != null)
        {
            deathsText.text = "Deaths:" + deaths.ToString();
            PlayerPrefs.SetInt("DeathCurrentLives", deaths);
        }
    }

    // Allows you to disable the player script.
    protected virtual void TogglePlayerScripts(bool value)
    {
        foreach(var playerScripts in playerDisableScripts)
        {
            playerScripts.enabled = value;
        }
    }

    // Allows you to disable the timer script.
    protected virtual void ToggleTimerScripts(bool value)
    {
        foreach (var timerScripts in timerDisableScripts)
        {
            timerScripts.enabled = value;
        }
    }

    // Allows you to disable the camera script.
    protected virtual void ToggleScripts(bool value)
    {
        foreach(var scripts in disableScripts)
        {
            scripts.enabled = value;
        }
    }
    
    // Death by HP
    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }
}

  

