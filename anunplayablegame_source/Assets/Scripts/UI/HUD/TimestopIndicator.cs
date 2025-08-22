using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimestopIndicator : MonoBehaviour
{
    [SerializeField] Image indicatorImage;
    [SerializeField] Sprite pausedSprite;
    [SerializeField] Sprite playSprite;
    [Space]
    Accessibility accessibility;
    [SerializeField] PauseMenu pauseMenu;

    private void Start()
    {
        accessibility = Accessibility.Instance;
    }

    private void Update()
    {
        if (accessibility.timeStop)
        {
            if (!indicatorImage.enabled) { indicatorImage.enabled = true; }

            // time is paused
            if (Time.timeScale == 0 && !pauseMenu.isOpen)
            {
                indicatorImage.sprite = pausedSprite;
            }
            // time is moving
            else if (Time.timeScale != 0 && !pauseMenu.isOpen)
            {
                 indicatorImage.sprite = playSprite;
            }
        }
        else if (indicatorImage.enabled) { indicatorImage.enabled = false; }
    }

}
