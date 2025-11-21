using UnityEngine;
using UnityEngine.SceneManagement;

public class scrTransition : MonoBehaviour
{
    public GameObject panTransition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panTransition.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void startBtn()
    {
        panTransition.SetActive(true);
        Debug.Log("Start");
        Invoke("LoadLevelOne", 5);
    }
    public void nextBtn()
    {
        SceneManager.LoadScene("TransitionAnim");

    }

    public void LoadLevelOne()
    {
        Debug.Log("Load");
        SceneManager.LoadScene("LevelUno");
        Debug.Log("Loaded");
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