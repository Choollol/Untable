using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum Action
    {
        None, Destroy, Progress, Activate
    }
    [SerializeField] protected Action action;
    [SerializeField] protected string interactSoundName;

    public static bool canInteract = true;

    private bool canUse = true;
    private void OnMouseDown()
    {
        if (GameManager.canInteract && canInteract && canUse)
        {
            if (action != Action.Activate)
            {
                Interact();
            }
        }
    }

    protected virtual IEnumerator OnInteract()
    {
        yield break;
    }
    public void Interact()
    {
        GameManager.canInteract = false;
        if (interactSoundName != "" && interactSoundName != null)
        {
            AudioManager.PlaySound(interactSoundName);
        }
        StartCoroutine(OnInteract());
    }
}
