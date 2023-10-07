using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextListClicker : MonoBehaviour
{
    [SerializeField] private string[] textList;
    [SerializeField] private float[] waitTimes;
    [SerializeField] private List<int> revealIndices;

    [SerializeField] private Revealer revealer;

    private TextMeshProUGUI tmp;

    private int counter = 1;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = textList[0];
    }
    private void Start()
    {
        Interactable.canInteract = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameManager.canInteract)
        {
            if (counter < textList.Length)
            {
                tmp.text = textList[counter];
                StartCoroutine(WaitTime());
                if (revealIndices.Contains(counter))
                {
                    revealer.Reveal();
                }
                counter++;
            }
            else
            {
                Interactable.canInteract = true;
                tmp.text = "";
            }
        }
    }
    private IEnumerator WaitTime()
    {
        GameManager.canInteract = false;
        yield return new WaitForSeconds(waitTimes[counter]);
        GameManager.canInteract = true;
        yield break;
    }
}
