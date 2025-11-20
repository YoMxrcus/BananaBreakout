using UnityEngine;
using UnityEngine.SceneManagement;

public class scrMainMenu : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip bgMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitBtn()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void StartBtn()
    {
        SceneManager.LoadScene("LevelUno");
    }
    public void HelpBtn()
    {
        SceneManager.LoadScene("Help");
    }
    public void BackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void CreditBtn() 
    {
        SceneManager.LoadScene("Credits");
    }
    public void Nextbtn()
    {
        SceneManager.LoadScene("Level2");
    }
}
