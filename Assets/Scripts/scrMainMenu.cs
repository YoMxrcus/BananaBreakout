using UnityEngine;
using UnityEngine.SceneManagement;

public class scrMainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HelpMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HelpMenu.SetActive(false);
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
        SceneManager.LoadScene("Level1");
    }
    public void HelpBtn()
    {
        MainMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }
    public void BackBtn()
    {
        MainMenu.SetActive(true);
        HelpMenu.SetActive(false);
    }
}
