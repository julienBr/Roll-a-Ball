using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
    public void Quit()
    {
        Application.Quit();
    }
}