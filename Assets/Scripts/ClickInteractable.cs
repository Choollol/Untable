using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteractable : Interactable
{
    protected override IEnumerator OnInteract()
    {
        if (action == Action.Destroy)
        {
            Destroy(gameObject);
        }
        else if (action == Action.Progress)
        {
            GameManager.NextStage();
        }
        GameManager.canInteract = true;
        yield break;
    }
}
