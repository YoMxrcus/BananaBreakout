/*using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrGameManager : MonoBehaviour
{
    public TMP_Text txtPlayerHealth;
    public GameObject gameOver, youWin;
    AudioSource sound;
    public AudioClip winSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleGameOver()
    {
        //displays end game panel
        gameOver.SetActive(true);
        //stops player movement
        Time.timeScale = 0;
    }

    public void UpdateData(int hp)
    {
        txtPlayerHealth.text = "Health: " + GameObject.Find("Player").GetComponent<scrPlayer>().lives;
    }
}
*/