
using UnityEngine;

public class TutorialManager :MonoBehaviour
{
    [SerializeField] GameObject finger;
    [SerializeField] GameObject hint;
    public void OnClickScreen()
    {
        SE.Play("pe");
        if (finger.activeSelf)
        {
            finger.SetActive(false);
            hint.SetActive(true);
        }
        else
        {
            finger.SetActive(true);
            hint.SetActive(false);
            TutorialComplete();
        }
    }
    public void OnClickSkipButton()
    {
        finger.SetActive(true);
        hint.SetActive(false);
        TutorialComplete();
    }
    void TutorialComplete()
    {
        DataManager.Instance.Flag.isTutorialCompleted = true;
        gameObject.SetActive(false);
    }
}
