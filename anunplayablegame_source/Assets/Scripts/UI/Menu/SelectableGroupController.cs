using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectableGroupController : MonoBehaviour
{
    List<Selectable> selectables = new List<Selectable>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectables = GetComponentsInChildren<Selectable>().ToList();
    }

    public void DisableInteractability()
    {
        foreach(Selectable selectable in selectables)
        {
            selectable.interactable = false;
        }
    }

    public void EnableInteractability()
    {
        foreach(Selectable selectable in selectables)
        {
            selectable.interactable = true;
        }
    }
}
