using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartScene()
    {
        
        string currentSceneName = SceneManager.GetActiveScene().name;

        
        SceneManager.LoadScene(currentSceneName);
    }
}
