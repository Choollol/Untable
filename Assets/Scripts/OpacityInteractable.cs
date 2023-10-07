using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityInteractable : Interactable
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float opacityDecrementAmount;

    private float startingOpacity;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        startingOpacity = spriteRenderer.color.a;
    }
    protected override IEnumerator OnInteract()
    {
        spriteRenderer.color -= new Color(0, 0, 0, opacityDecrementAmount);
        if (spriteRenderer.color.a <= 0 && startingOpacity != 0)
        {
            if (name == "Lightbulb")
            {
                GetComponent<SummonInteractable>().Interact();
            }
            if (action == Action.Progress)
            {
                GameManager.NextStage();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (spriteRenderer.color.a >= 1 && startingOpacity != 1)
        {
            if (name == "Lightbulb")
            {
                AudioManager.PlaySound("Lightbulb Lit");
                yield return new WaitForSeconds(1);
                GameManager.NextStage();
            }
            if (action == Action.Progress)
            {
                yield return new WaitForSeconds(5);
                GameManager.NextStage();
            }
        }
        GameManager.canInteract = true;
        yield break;
    }
}
