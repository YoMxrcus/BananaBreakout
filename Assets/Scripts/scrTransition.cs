using UnityEngine;
using UnityEngine.SceneManagement;

public class scrTransition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Invoke("LoadLevel1", 5);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("LevelUno");
    }
}
