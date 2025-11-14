using UnityEngine;

public class scrPlayerPrototype : MonoBehaviour
{
    public float PlayerHealth = 100;

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
                    PlayerHealth;
                }

                else
                {
                    PlayerHealth -= 10;    
                }
                break;

            case "SpikeStakes":
                PlayerHealth -= 30;
                break;

            case "Water":
                PlayerHealth == 0;
                break;

            case "Boulders":
            if (currentPowerUp == "Eggs")
                {
                    other.gameObject.SetActive(false);
                }
                break;
        }
    }

    //void PowerUpTimer;

}
