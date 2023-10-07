using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public static bool canInteract;
    private static bool canTransition;

    public int stage = 0;

    [SerializeField] private GameObject transition;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        canInteract = true;
        canTransition = true;

        SceneManager.LoadSceneAsync("Stage 0", LoadSceneMode.Additive);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Restart") && canTransition)
        {
            StartCoroutine(LoadStage(stage));
        }
    }
    public static void NextStage()
    {
        instance.stage++;
        Instance.StartCoroutine(Instance.LoadStage(instance.stage - 1));
    }
    private IEnumerator LoadStage(int oldStage)
    {
        transition.SetActive(true);
        canInteract = false;
        canTransition = false;
        SceneManager.UnloadSceneAsync("Stage " + oldStage);
        SceneManager.LoadSceneAsync("Stage " + stage, LoadSceneMode.Additive);
        switch (stage)
        {
            case 1:
                {
                    
                    break;
                }
            case 2:
                {
                    break;
                }
        }
        yield return new WaitForSeconds(1f);
        transition.SetActive(false);
        canInteract = true;
        canTransition = true;
        yield break;
    }
}
