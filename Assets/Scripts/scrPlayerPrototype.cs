using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrPlayerPrototype : MonoBehaviour
{
    //Player variables
    public int playerHealth = 100;
    public int speed = 10;
    public int playerDamage = 30;

    //Powerup detection variables
    public string currentPowerUp = "";
    bool isPoweredUp = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Player throws a punch if they are in range of an enemy
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {

            //////////////////////// HAZARDS ////////////////////////

            case "ThornWalls":
                //Does no damage to player if the durian power up is active
                if (currentPowerUp == "Durian")
                {
                    break;
                }

                //Damages players health by 10 when touched
                playerHealth -= 10;
                GameObject.Find("GameManager").GetComponent<scrGameManager>().UpdateData(playerHealth);
                break;

            //Damages players health by 30 when touched
            case "SpikeStakes":
                playerHealth -= 30;
                GameObject.Find("GameManager").GetComponent<scrGameManager>().UpdateData(playerHealth);
                break;

            //Acts as a deathplane
            case "Water":
                playerHealth = 0;
                GameObject.Find("GameManager").GetComponent<scrGameManager>().UpdateData(playerHealth);
                GameObject.Find("GameManager").GetComponent<scrGameManager>().HandleGameOver();
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
                    playerDamage += 10;
                }
                break;

            case "Eggs":
                //Increases players damage by 30
                if (!isPoweredUp)
                {
                    isPoweredUp = true;
                    currentPowerUp = "Eggs";
                    playerDamage += 30;
                }
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
                //Increases players health by 10 if they're not at 100 already
                if (playerHealth < 100)
                {
                    playerHealth += 10;
                    GameObject.Find("GameManager").GetComponent<scrGameManager>().UpdateData(playerHealth);
                }
                break;

        }

    }
}
