using UnityEngine;
using UnityEngine.SceneManagement;

public class scrMainMenu : MonoBehaviour
{
    public GameObject panTransition;
    // Update is called once per frame
    void Start()
    {
        panTransition.SetActive(false);
    }
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
        SceneManager.LoadScene("TransitionAnim");
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
        SceneManager.LoadScene("TransitionAnim");
    }

    public void ToLevelTwo()
    {
        panTransition.SetActive(true);
        Invoke("LoadLevel2", 5);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
