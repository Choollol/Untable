using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revealer : MonoBehaviour
{
    private int revealCounter = 0;

    [SerializeField] private GameObject tableRoom;
    [SerializeField] private GameObject fullRoom;
    [SerializeField] private GameObject world;

    private SpriteRenderer tableBackground;
    private SpriteRenderer fullBackground;
    private SpriteRenderer worldBackground;

    [SerializeField] private Rigidbody2D tableRB;
    private void Awake()
    {
        tableBackground = tableRoom.transform.GetChild(0).GetComponent<SpriteRenderer>();   
        fullBackground = fullRoom.transform.GetChild(0).GetComponent<SpriteRenderer>();   
        worldBackground = world.transform.GetChild(0).GetComponent<SpriteRenderer>();

        world.transform.localScale = Vector3.one * 10;

        tableRB.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void Reveal()
    {
        switch (revealCounter)
        {
            case 0:
                {
                    StartCoroutine(RevealRoom());
                    break;
                }
            case 1:
                {
                    StartCoroutine(RevealWorld());
                    break;
                }
            case 2:
                {
                    StartCoroutine(RevealTable());
                    break;
                }
        }
        revealCounter++;
    }
    private IEnumerator RevealRoom()
    {
        yield return new WaitForSeconds(1);
        AudioManager.PlaySound("Reveal Sound");
        while (tableBackground.color.a > 0)
        {
            tableBackground.color -= new Color(0, 0, 0, 0.5f * Time.deltaTime);

            if (tableRoom.transform.localScale.x > 0.5f)
            {
                float scaleDecrement = 0.3f * Time.deltaTime;
                tableRoom.transform.localScale -= Vector3.one * scaleDecrement;
                tableRoom.transform.position -= new Vector3(0, scaleDecrement / 2);

                fullRoom.transform.localScale -= Vector3.one * scaleDecrement;
                //fullRoom.transform.position -= new Vector3(0, scaleDecrement / 2);
            }
            if (tableRoom.transform.localScale.x < 0.5f)
            {
                tableRoom.transform.localScale = Vector3.one * 0.5f;
            }
            if (fullRoom.transform.localScale.x < 0.5f)
            {
                fullRoom.transform.localScale = Vector3.one * 0.5f;
            }
            yield return null;
        }
        AudioManager.StopSound("Reveal Sound");
        yield break;
    }
    private IEnumerator RevealWorld()
    {
        yield return new WaitForSeconds(1);
        AudioManager.PlaySound("Reveal Sound");
        while (fullBackground.color.a > 0)
        {
            fullBackground.color -= new Color(0, 0, 0, 0.5f * Time.deltaTime);

            float scaleDecrement = 0.7f * Time.deltaTime;
            if (tableRoom.transform.localScale.x > 0)
            {
                tableRoom.transform.localScale -= Vector3.one * scaleDecrement;
            }
            if (fullRoom.transform.localScale.x > 0)
            {
                fullRoom.transform.localScale -= Vector3.one * scaleDecrement;
            }
            if (world.transform.localScale.x > 0.5f)
            {
                world.transform.localScale -= Vector3.one * scaleDecrement * 12;
            }
            if (fullRoom.transform.localScale.x < 0)
            {
                fullRoom.transform.localScale = Vector3.zero;
            }
            yield return null;
        }
        fullRoom.SetActive(false);
        AudioManager.StopSound("Reveal Sound");
        yield break;
    }
    private IEnumerator RevealTable()
    {
        yield return new WaitForSeconds(1);
        AudioManager.PlaySound("Reveal Sound");
        tableRoom.transform.localScale = Vector3.one * 10;
        tableRoom.transform.position = new Vector3(0, 0, 10);
        while (tableBackground.color.a < 1)
        {
            tableBackground.color += new Color(0, 0, 0, 0.5f * Time.deltaTime);

            if (tableRoom.transform.localScale.x > 1)
            {
                float scaleIncrement = 5f * Time.deltaTime;
                tableRoom.transform.localScale -= Vector3.one * scaleIncrement;
            }
            if (tableRoom.transform.localScale.x < 1)
            {
                tableRoom.transform.localScale = Vector3.one;
            }
            yield return null;
        }
        tableRB.constraints = RigidbodyConstraints2D.None;
        AudioManager.StopSound("Reveal Sound");
        yield break;
    }
}
