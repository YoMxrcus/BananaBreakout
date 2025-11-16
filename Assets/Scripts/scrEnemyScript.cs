using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scrEnemyScript : MonoBehaviour
{
    public int enemyHealth;
    public int enemySpeed;
    public int enemyDamage;

    public GameObject enemyGorilla, enemySnake, enemyCrocodile, enemyPoacher;

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
            case "Gorilla":

                break;

            case "Snake":

                break;

            case "Crocodile":

                break;

            case "Poacher":

                break;
        }
    }

}
