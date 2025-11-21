using UnityEngine;
using UnityEngine.SceneManagement;

public class scrTransition : MonoBehaviour
{
    public int level = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(level > 0)
        {
            Invoke("LoadLevel2", 5);
        }
        else
        {
            Invoke("LoadLevel1", 5);
            level++;
        }

    }
    void Update()
    {

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
