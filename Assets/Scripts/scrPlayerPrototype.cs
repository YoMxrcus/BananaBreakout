using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrPlayerPrototype : MonoBehaviour
{
    public int playerHealth = 100;
    public int speed = 10;
    public string currentPowerUp = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
         switch (other.tag)
        {
            case "ThornWalls":
                if (currentPowerUp == "Durian")
                {
                    break;
                }
                    playerHealth -= 10;
                    GameObject.Find("GameManager").GetComponent<scrGameManager>().UpdateData(playerHealth);
                break;

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
                break;
        }
    }

    //void PowerUpTimer;

}
