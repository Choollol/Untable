using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DragDropInteractable : Interactable
{
    private bool doFollowMouse = false;

    [SerializeField] private bool doSnap;
    [SerializeField] private Vector2 snapPosition;
    [SerializeField] private Interactable interactableToActivate;

    private bool didSnap = false;
    private void Update()
    {
        if (doFollowMouse)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.SetZ(0);
        }
        else
        {
            if (doSnap && Vector2.Distance(transform.position, snapPosition) < 0.07f)
            {
                transform.position = snapPosition;
                if (!didSnap)
                {
                    interactableToActivate.Interact();
                }
                didSnap = true;
            }
        }
    }
    protected override IEnumerator OnInteract()
    {
        doFollowMouse = true;
        GameManager.canInteract = true;
        yield break;
    }
    private void OnMouseUp()
    {
        doFollowMouse = false;
    }
}
