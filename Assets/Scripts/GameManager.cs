using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class GameManager :MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    public static bool isClearRemocon = false;
    [SerializeField] GameObject tutorial;
    private void Start()
    {
        StartCoroutine(AnimetionSkip());
        if (DataManager.Instance.Flag.isTutorialCompleted)
        {
            tutorial.SetActive(false);
        }
        else
        {
            tutorial.SetActive(true);
        }
        isClearRemocon = DataManager.Instance.Flag.isClearRemocon;
    }

    public void ClearRemocon()
    {
        isClearRemocon = true;
        DataManager.Instance.Flag.isClearRemocon = true;
        DataManager.Instance.Save();
    }

    private IEnumerator AnimetionSkip()
    {
        Time.timeScale = 5;
        yield return new WaitForSecondsRealtime(10f);
        Time.timeScale = 1;
    }
}
