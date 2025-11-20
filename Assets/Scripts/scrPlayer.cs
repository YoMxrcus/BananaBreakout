using NUnit.Framework.Constraints;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scrPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed = 10;
    public float stamina = 100f;
    bool canJump;
    bool canMove = true;
    public int lives = 5;
    public int playerDamage = 1;
    public Slider staminaBar;
    public GameObject slingshot;
    public AudioSource sound;
    public AudioClip slingshotSound, strechSound, monkeySound1, monkeySound2, monkeySound3, monkeySound4;
    public GameObject panPause;
    public GameObject gameOver;
    public Animator anim;
    int eggs;
    int banana;
    public TMP_Text txtPlayerHealth;
    public TMP_Text txtEggs;
    public TMP_Text txtBanana;
    public bool isInvincible = false;
    bool isLeft;


    //Powerup detection variables
    public string currentPowerUp = "";
    bool isPoweredUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        staminaBar.gameObject.SetActive(true);
        panPause.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        UpdateData();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
            transform.position += movement;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce((new Vector2(0.0f, 250)) * 1.5f);
            Debug.Log("Jump");
            
        }
        if (stamina >= 100f)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (isLeft)
                { 
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    rb.AddForce((new Vector2(-200.0f, 0.0f)) * 1.5f);
                    stamina = 0; UpdateData();
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    rb.AddForce((new Vector2(200, 0.0f)) * 1.5f);
                    stamina = 0; UpdateData();
                }
               
            }
        }
        if (stamina < 100)
        { stamina += 0.05f; UpdateData(); }


        if (Input.GetKeyDown(KeyCode.A))
        { transform.rotation = Quaternion.Euler(0, 180, 0); isLeft = true;}

        if (Input.GetKeyDown(KeyCode.D))
        { transform.rotation = Quaternion.Euler(0, 0, 0); isLeft = false;}
        

        // Movement Animations
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        { anim.SetBool("IsMoving", true); }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        { anim.SetBool("IsMoving", false); }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (banana > 0)
            {
                banana--;
                lives++;
                UpdateData();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (eggs > 0)
            {
                eggs--;
                isInvincible = true;
                UpdateData();
                Invoke("EndInvincibility", 5f);
            }
            
        }
    }
        void OnCollisionStay2D(Collision2D collision)
        {
            canJump = true;
        }
    void OnCollisionExit2D(Collision2D collision)
        {
            canJump = false;
        }
        void EndInvincibility()
        {
            isInvincible = false;
        }
        void Launch()
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce((new Vector2(1000.0f, 300.0f)) * 1.5f);
            sound.Stop();
            sound.PlayOneShot(slingshotSound);
            canMove = true;
        }
    public void Paused()
    {
        panPause.SetActive(true);
    }
    public void GameOver()
    {
        panPause.SetActive(true);
    }
    public void Resume()
    {
        panPause.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void QuitBtn()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void HandleGameOver()
    {
        //displays end game panel
        gameOver.SetActive(true);
        //stops player movement
        Time.timeScale = 0;
    }
    public void UpdateData()
    {
        txtPlayerHealth.text = "X: " + lives;
        txtEggs.text = "" + eggs;
        txtBanana.text = "" + banana;
        staminaBar.value = stamina;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "slingshot":
                canMove = false;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                Destroy(other.gameObject);
                Vector2 pos = new Vector2(transform.position.x + 1f, transform.position.y - 2f);
                GameObject instance = Instantiate(slingshot, pos, Quaternion.Euler(0, 0, -2.932f));
                sound.PlayOneShot(strechSound);
                Invoke("Launch", 2f);
                break;

            case "enemy":
                if (!isInvincible) 
                {
                    sound.PlayOneShot(monkeySound3);
                    lives--;
                } 
                UpdateData();
                if (lives == 0)
                {
                    HandleGameOver();
                }
                break;
            
            case "DroppedSpike":
                if (!isInvincible) 
                {
                    //sound.PlayOneShot(hit);
                    lives = 0;
                    HandleGameOver();
                }
                break;


            case "Finish":
                Time.timeScale = 0;
                SceneManager.LoadScene("win");
                break;

            //////////////////////// HAZARDS ////////////////////////

            case "ThornWalls":
                //Does no damage to player if the durian power up is active
                if (currentPowerUp == "Durian")
                {
                    break;
                }

                //Damages players health by 1 when touched
                lives --;
                UpdateData();
                if (lives == 0)
                {
                    HandleGameOver();
                }
                break;
            

            //Acts as a deathplane
            case "Water":
                lives = 0;
                UpdateData();
                HandleGameOver();
                break;

            case "Boulders":
                //Allows the player to break obstacles with the egg power up
                if (currentPowerUp == "Eggs")
                {
                    other.gameObject.SetActive(false);
                }
                //Blocks the players path if they don't have the egg power up
                break;

            //////////////////////// POWERUPS ////////////////////////

            case "Durian":
                //Increases players damage by 10
                if (!isPoweredUp)
                {
                    isPoweredUp = true;
                    currentPowerUp = "Durian";
                    playerDamage += 1;
                }
                break;

            case "Eggs":
                //Increases players damage by 30
                sound.PlayOneShot(monkeySound1);

                eggs++;
                UpdateData();
                Destroy(other.gameObject);
                /*if (!isPoweredUp)
                {
                    isPoweredUp = true;
                    currentPowerUp = "Eggs";
                    playerDamage += 1;
                }
                */
                break;

            case "Bongos":
                //Gives player max stamina for 15 seconds
                if (!isPoweredUp)
                {
                    isPoweredUp = true;
                    currentPowerUp = "Bongos";
                }
                break;

            case "Banana":
                sound.PlayOneShot(monkeySound2);
                banana++;
                Destroy(other.gameObject);
                //Increases players health by 10 if they're not at 100 already
                UpdateData();
                break;
        }
    }
}