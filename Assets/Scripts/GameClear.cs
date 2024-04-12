using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class GameClear :MonoBehaviour
{
    [SerializeField] GameObject clearPanel;
    [SerializeField] GameObject clearEffect;
    public void ClearProcess()
    {
        Instantiate(clearEffect);
        StartCoroutine(UnenableTouchClearPanel());
    }
    IEnumerator UnenableTouchClearPanel()
    {
        AdMobBanner.instance.BannerDestroy();
        ItemBox.instance.HideItemBox();
        CameraManager.instance.HideDirectionButton();
        clearPanel.GetComponent<Image>().raycastTarget = false;
        yield return new WaitForSeconds(2f);
        clearPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        StartCoroutine(AppReview.Instance.Request());
        clearPanel.GetComponent<Image>().raycastTarget = true;

    }
}
