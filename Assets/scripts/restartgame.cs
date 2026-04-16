using UnityEngine;

public class restartgame : MonoBehaviour
{
  
  public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("game scene");
        Time.timeScale = 1;
        
    }
}
