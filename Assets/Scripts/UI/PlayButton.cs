using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Button playButton;

    private void Start()
    {
        
        playButton.onClick.AddListener(OnPlayButtonClick);

        
        AnimateButton();
    }

    private void AnimateButton()
    {
        
        playButton.transform.localScale = Vector3.one;

        
        playButton.transform.DOScale(1.1f, 0.2f).OnComplete(() =>
        {
            playButton.transform.DOScale(1f, 0.2f).SetDelay(0.1f).OnComplete(() =>
            {
                AnimateButton(); 
            });
        });
    }

    private void OnPlayButtonClick()
    {
        
        SceneManager.LoadScene("Level1");
    }
}
