using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtils : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int builtIndex)
    {
        SceneManager.LoadScene(builtIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
