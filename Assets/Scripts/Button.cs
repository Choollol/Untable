using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private bool canClick;
    private void OnMouseDown()
    {
        if (canClick)
        {
            Pressed();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            Pressed();
        }
    }
    private void Pressed()
    {
        AudioManager.PlaySound("Button Click");
        GameManager.NextStage();
    }
}
