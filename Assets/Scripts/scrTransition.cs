using UnityEngine;
using UnityEngine.SceneManagement;

public class scrTransition : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("LoadLevelUno", 5);
    }
    public void startBtn()
    {
        SceneManager.LoadScene("TransitionAnim");
    }
    public void nextBtn()
    {
        SceneManager.LoadScene("TransitionAnim");

    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("LevelUno");
  
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
