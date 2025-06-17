using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void PlayApp()
    {
        SceneManager.LoadScene(1);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void AppMenu()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(1);
    }

}
