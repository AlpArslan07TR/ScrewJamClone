using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    public GameObject winPanelUI;

    
    public void ShowWinPanel()
    {
        winPanelUI.SetActive(true);
    }

    
    public void NextLevel()
    {
        
        SceneManager.LoadScene("Level2");
    }

    public void BackToMenuWin()
    {
        SceneManager.LoadScene("BootScene");
    }
}
