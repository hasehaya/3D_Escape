using System.Collections;

using UnityEngine;

public class AppReview :MonoBehaviour
{
    private static AppReview instance;
    public static AppReview Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AppReview>();
            }
            return instance;
        }
    }
    public IEnumerator Request()
    {
#if UNITY_IOS
        UnityEngine.iOS.Device.RequestStoreReview();

#elif UNITY_ANDROID
        var reviewManager = new Google.Play.Review.ReviewManager();
        var requestFlowOperation = reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;

        if (requestFlowOperation.Error != Google.Play.Review.ReviewErrorCode.NoError)
        {
            // �G���[�������K�v�ȏꍇ�����ɒǉ�
            Debug.LogError(requestFlowOperation.Error);
            yield break;
        }

        var playReviewInfo = requestFlowOperation.GetResult();
        var launchFlowOperation = reviewManager.LaunchReviewFlow(playReviewInfo);
        yield return launchFlowOperation;

        if (launchFlowOperation.Error != Google.Play.Review.ReviewErrorCode.NoError)
        {
            // �G���[�������K�v�ȏꍇ�����ɒǉ�
            Debug.LogError(launchFlowOperation.Error);
            yield break;
        }
#else
        Debug.Log("RequestReview Not supported.");
#endif
        yield break;
    }
}