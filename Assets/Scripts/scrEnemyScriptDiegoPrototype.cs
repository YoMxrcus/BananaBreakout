using UnityEngine;

public class scrEnemyScriptDiegoPrototype : MonoBehaviour
{
    //Enemy variables
    public float EnemyHealth;
    public float EnemyDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Gorilla":
                EnemyHealth = 150;
              //PlayerHealth -= 50;
                break;

            case "Crocodile":
                EnemyHealth = 75;

                break;

            case "Snake":
                EnemyHealth = 40;

                break;

            case "Poacher":
                EnemyHealth = 100;

                break;
        }
    }
}
