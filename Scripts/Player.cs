using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public Camera mainCamera;
    public float speed;
    public Text scoreText;
    public float seconds;
    public int Health;
    public int deaths;
    public Text deathsText;

    public AudioSource MoveSound;
    public AudioSource CoinSound;
    public AudioSource SpeedSound;
    public AudioSource JumpSound;
    public AudioSource CandySound;
    public AudioSource TimerSound;
    public AudioSource DoorSound;
    public AudioSource WarpSound;
    public AudioSource KnightSound;
    public AudioSource DeathSound;
    public AudioSource lavaDeath;
    public AudioSource waterDeathSound;
    public AudioSource checkPointSound;


    public GameObject LoadingScreen;
    public float delay = 2.5f;
    public string newGameLevel;
    public Animator loadingScreen;
    public Animator Fade;
    public Animator fade;

    public float jumpHeight = 8;
   
   
   



    private Rigidbody rb;
    private int score;
    private int count;
    private bool isFalling = false;

    public WallSpikeTrigger WallSpikeTrigger;
    public FloorSpikeTrigger FloorSpikeTrigger;
    public SwooshTrigger SwooshTrigger;

  
    
    public myTimer2 myTimer2;
   

    private bool IsTiming = false;

    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100;
    }

    //Kills player when falling off the game level in the Y direction.
    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -225;

    void Start()
    {
        rb = GetComponent<Rigidbody>();                                        // Looks for Rigidbody.
         
        rb.useGravity = true;                                                 // isGravity is set to true.
         
        rb.isKinematic = false;                                              // isKinematic is set to false. 

        isFalling = false;                                                  // isFalling is set to false.

        score = PlayerPrefs.GetInt ("CurrentScore");                       // Score is set to Player Prefs.
         
        setScoreText();                                                   // Looks for score text.

        count = 0;                                                       // Counter is set to 0.

        speed = 3005;                                                   // Speed of ball is set to 3005.

        seconds = 0;                                                   // Seconds is set to 0.

        deaths = PlayerPrefs.GetInt("DeathCurrentLives");             // Deaths is set to Player Prefs.

        setDeathsText();                                             // Looks fr death text.


        GetComponent<Collider>().enabled = true;                    // Collider is set to true.

        scoreText = GameObject.Find("ScoreText").GetComponentInChildren<Text>();      // Looks for score text on the player and player clone.

       

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


        //Sound when moving
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveSound.Play();
        }
        else
        {
            //sounds stops 
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                MoveSound.Stop();
            }
            //command for jumping plus sound
            if (Input.GetKeyDown(KeyCode.Space) && !isFalling)
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                JumpSound.Play();
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Space) && !isFalling)
                {
                    JumpSound.Stop();
                }
                isFalling = true;
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
        Vector3 moveHorizontal = mainCamera.transform.right * Input.GetAxisRaw("Horizontal") * 80;
        Vector3 moveVertical = mainCamera.transform.forward * Input.GetAxisRaw("Vertical") * 80;

        rb.AddForce(moveHorizontal + moveVertical);
    }


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
        //Collect Candy Object
        if (other.gameObject.CompareTag("Candy"))
        {
            count = count + 1;
            score = score + 6000;
            CandySound.Play();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("CurrentScore", score);
            setScoreText();
        }
        if(other.gameObject.tag == "CheckPoint")
        {
            checkPointSound.Play();
            yield return new WaitForSeconds(.2f);
            Destroy(other.gameObject);
        }
        //Death Event
        if (other.gameObject.CompareTag("Mine"))
        {
            GetComponent<Collider>().enabled = false;
            rb.useGravity = false;
            rb.isKinematic = true;
            count = count + 1;
            deaths = deaths + 1;
            setDeathsText();
            DeathSound.Play();
            PlayerPrefs.SetInt("DeathCurrentLives", deaths);
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
            
            
        }
        //Death Event
        if (other.gameObject.CompareTag("Mine2"))
        {
            GetComponent<Collider>().enabled = false;
            rb.useGravity = false;
            rb.isKinematic = true;
            count = count + 1;
            deaths = deaths + 1;
            setDeathsText();
            waterDeathSound.Play();
            PlayerPrefs.SetInt("DeathCurrentLives", deaths);
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


        }
        //Death Event
        if (other.gameObject.tag == "Lava")
        {
            GetComponent<Collider>().enabled = false;
            rb.useGravity = false;
            rb.isKinematic = true;
            count = count + 1;
            deaths = deaths + 1;
            setDeathsText();
            lavaDeath.Play();
            PlayerPrefs.SetInt("DeathCurrentLives", deaths);
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
        }

        // First Level Key
        if (other.gameObject.tag == "Key")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.0f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
           SceneManager.LoadScene("LoadingScreen 4");         
        }
        // First_1 Level Key
        if (other.gameObject.tag == "Key4")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.0f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 5");
        }

        // Water Normal and Destroyed Level Keys
        if (other.gameObject.tag == "Key1")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.0f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 7");
        }

        // Water Normal and Destroyed_1 Level Keys
        if (other.gameObject.tag == "Key6")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.0f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 10");
        }

        // Escape Level Key
        if (other.gameObject.tag == "Key2")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.0f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 1");
        }

        // Escape_1 Level Key
        if (other.gameObject.tag == "Key5")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.0f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 12");
        }

        // Fire Level Key
        if (other.gameObject.tag == "Key3")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.0f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            GetComponent<Animator>().SetTrigger("Fade");               // For lava sound.
            fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 8");
        }

        // Fire_1 Level Key
        if (other.gameObject.tag == "Key7")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            DoorSound.Play();
            yield return new WaitForSeconds(1.0f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            GetComponent<Animator>().SetTrigger("Fade");               // For lava sound.
            fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 11");
        }

        // Secret path portal first level
        if (other.gameObject.tag == "Portal")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            WarpSound.Play();
            yield return new WaitForSeconds(.5f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 7");
        }

        // Secret path portal first_1 level
        if (other.gameObject.tag == "Portal2")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            WarpSound.Play();
            yield return new WaitForSeconds(.5f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 10");
        }

        // Secret path portal Water Normal level
        if (other.gameObject.tag == "Portal1")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            WarpSound.Play();
            yield return new WaitForSeconds(.5f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 2");
        }

        // Secret path portal Water Normal_1 level
        if (other.gameObject.tag == "Portal3")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            WarpSound.Play();
            yield return new WaitForSeconds(.5f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LoadingScreen 13");
        }

        // Knight Trigger
        if (other.gameObject.tag == "Knight")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            KnightSound.Play();
            yield return new WaitForSeconds(1.3f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("End_Credits");
        }

        // Knight Trigger
        if (other.gameObject.tag == "Knight1")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            KnightSound.Play();
            yield return new WaitForSeconds(1.3f);
            LoadingScreen.SetActive(true);
            GetComponent<Animator>().SetTrigger("Fader");
            loadingScreen.SetTrigger("Fader");
            GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("End_Credits 1");
        }
     
        //Add time Water Coin Level   
        if (other.gameObject.tag == "Timer2")
        {
            count = count + 1;
            myTimer2.myCoolTimer += 50;
            TimerSound.Play();
            Destroy(other.gameObject);
        }
       
    }
      
    
    //Sets score to UI board
    void setScoreText()
    {

        if (scoreText != null)
         scoreText.text = "Score:" + score.ToString();
        PlayerPrefs.SetInt("CurrentScore", score);
    }
    // Sets Death counter to UI board
    void setDeathsText()
    {

        if (deathsText != null)
            deathsText.text = "Deaths:" + deaths.ToString();
        PlayerPrefs.SetInt("DeathCurrentLives", deaths);
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

  

