using UnityEngine;
using UnityEngine.SceneManagement;

public class FailPanel : MonoBehaviour
{
    public GameObject failPanelUI; 

    public void ShowFailPanel()
    {
        failPanelUI.SetActive(true); 
    }

    public void BackToMenu()
    {
        
        SceneManager.LoadScene("BootScene");
    }
}
