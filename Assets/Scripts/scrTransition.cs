using UnityEngine;
using UnityEngine.SceneManagement;

public class scrTransition : MonoBehaviour
{
    public GameObject panTransition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panTransition.SetActive(false);
    }
    public void startBtn()
    {
        panTransition.SetActive(true);
        Invoke("LoadLevel1", 5);
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
    public void ToLevelTwo()
    {
        panTransition.SetActive(true);
        Invoke("LoadLevel2", 5);
    }
}