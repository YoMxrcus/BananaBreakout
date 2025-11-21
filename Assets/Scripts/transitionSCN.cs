using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionSCN : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Time.timeScale = 1.0f;
        Invoke("LoadLevel2", 5f);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
