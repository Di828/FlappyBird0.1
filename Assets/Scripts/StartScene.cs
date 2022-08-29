using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void StartButtonClick()
    {        
        SceneManager.LoadScene("Game");
    }
    public void BirdButtonClick()
    {
        SceneManager.LoadScene("BirdsSelect");
    }
    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
