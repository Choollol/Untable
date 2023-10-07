using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonInteractable : Interactable
{
    [SerializeField] private GameObject summon;
    protected override IEnumerator OnInteract()
    {
        summon.SetActive(true);
        if (action == Action.Destroy)
        {
            Destroy(gameObject);
        }
        GameManager.canInteract = true;
        yield break;
    }
}
