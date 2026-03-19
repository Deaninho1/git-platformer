using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string NextLevelName;
  public void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(NextLevelName);
        Time.timeScale = 1;
    }
}
