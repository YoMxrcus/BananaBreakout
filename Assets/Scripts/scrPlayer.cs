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
    public AudioClip slingshotSound, strechSound, monkeySound1, monkeySound2, monkeySound3, monkeySound4, eggSound, bananaSound, bongoSound;
    public GameObject panPause;
    public GameObject gameOver;
    public Animator anim;
    int eggs;
    int banana;
    int bongo;
    public TMP_Text txtPlayerHealth, txtEggs, txtBanana, txtBongo;
    public bool isInvincible = false;
    bool isLeft;

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

            Vector2 inputDirection = new Vector2(horizontalInput, 0f);

            Vector3 movement = new Vector3(inputDirection.x, 0f, 0f) * speed * Time.deltaTime;

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
            if (Input.GetKeyDown(KeyCode.LeftShift))
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
        { transform.rotation = Quaternion.Euler(0, 180, 0); isLeft = true; }

        if (Input.GetKeyDown(KeyCode.D))
        { transform.rotation = Quaternion.Euler(0, 0, 0); isLeft = false; }


        // Movement Animations
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        { anim.SetBool("IsMoving", true); }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        { anim.SetBool("IsMoving", false); }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            sound.PlayOneShot(bananaSound);
            if (banana > 0)
            {
                banana--;
                lives++;
                UpdateData();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            sound.PlayOneShot(eggSound);
            if (eggs > 0)
            {
                eggs--;
                stamina = 100;
                UpdateData();


            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            sound.PlayOneShot(bongoSound);
            if (bongo > 0)
            {
                bongo--;
                isInvincible = true; Invoke("EndInvincibility", 5f);
                UpdateData();
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
        Time.timeScale = 0f;
    }
    public void GameOver()
    {
        panPause.SetActive(true);
    }
    public void Resume()
    {
        panPause.SetActive(false);
        Time.timeScale = 1f;
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
        txtBongo.text = "" + bongo;
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
            case "Finish2":
                Time.timeScale = 0;
                SceneManager.LoadScene("EndOfGame");
                break;

            //////////////////////// HAZARDS ///////////////////////
            //Acts as a deathplane
            case "Water":
                lives = 0;
                UpdateData();
                HandleGameOver();
                break;

            //////////////////////// POWERUPS ////////////////////////


            case "Eggs":
                //Increases players damage by 30
                sound.PlayOneShot(monkeySound1);

                eggs++;
                UpdateData();
                Destroy(other.gameObject);
             
                break;

            case "Bongos":
                //Gives player max stamina for 15 seconds
                //sound.PlayOneShot(monkeySound1);
                sound.PlayOneShot(monkeySound1);

                bongo++;
                UpdateData();
                Destroy(other.gameObject);
                break;

            case "Banana":
                sound.PlayOneShot(monkeySound2);
                banana++;
                Destroy(other.gameObject);
                //Increases players health by 10 if they're not at 100 already
                UpdateData();
                break;

            case "Dart":
                if (!isInvincible)
                {
                    Destroy(other.gameObject);
                    lives--;
                }
                UpdateData();
                if (lives == 0)
                {
                    HandleGameOver();
                }
                break;
        }
    }
}