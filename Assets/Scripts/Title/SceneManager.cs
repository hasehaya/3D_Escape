using System.Collections;
using System.Timers;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager :MonoBehaviour
{
    private static SceneManager instance;
    public static SceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneManager>();
            }
            return instance;
        }
    }
    [SerializeField] Image cover;
    bool isStart = false;
    float timer = 0;
    private void Update()
    {
        if (isStart)
        {
            timer += Time.deltaTime;
            cover.color = new Color(255, 255, 255, Mathf.Abs(timer / 2.3f));
        }
    }
    public void GoToGame()
    {
        StartCoroutine(ChangeScene("Game"));
    }
    public void GoToTitle()
    {
        Debug.Log("GoToTitle");
        AdMobInterstitial.instance.ShowAdMobInterstitial();
        Debug.Log("ShowAdMobInterstitial");
        AdMobBanner.instance.BannerDestroy();
        DataManager.Instance.Save();
        StartCoroutine(ChangeScene("Title"));
    }
    public void Clear()
    {
        DataManager.Instance.Save();
        StartCoroutine(ChangeScene("Title"));
    }
    IEnumerator ChangeScene(string sceneName)
    {
        isStart = true;
        yield return new WaitForSeconds(2.05f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
