using UnityEngine;
using UnityEngine.SceneManagement;

public class scrMainMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("Level2");
    }
}
