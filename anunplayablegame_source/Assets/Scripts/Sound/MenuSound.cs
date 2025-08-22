using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class MenuSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] AudioClip hoverSound;
    [SerializeField] AudioClip pressedSound;

    [SerializeField] bool guaranteeClickSound = false;

    Selectable selectable;

    private void Awake()
    {
        selectable = GetComponent<Selectable>();   
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // only play sound if selectable is interactable
        if (!selectable.interactable) { return; }

        SoundController.Instance.PlayMenuSoundEffect(hoverSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // only play sound if selectable is interactable
        if (!selectable.interactable && !guaranteeClickSound) { return; }

        SoundController.Instance.PlayMenuSoundEffect(pressedSound, guaranteeClickSound);
    }

}
