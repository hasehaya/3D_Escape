/*
using GoogleMobileAds.Api;

using UnityEngine;

public class AdMobNativeAd :MonoBehaviour
{
    private GameObject icon;
    private bool nativeAdLoaded;
    private NativeAd nativeAd;

#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/2247696110";
#elif UNITY_IPHONE
    string _adUnitId = "ca-app-pub-3940256099942544/3986624511";
#else
    private string _adUnitId = "unused";
#endif
    private void Start()
    {
        RequestNativeAd();
    }
    void Update()
    {
        if (this.nativeAdLoaded)
        {
            this.nativeAdLoaded = false;
            print("show native Ad");
            // Get Texture2D for icon asset of native ad.
            Texture2D iconTexture = this.nativeAd.GetIconTexture();

            icon = GameObject.CreatePrimitive(PrimitiveType.Quad);
            icon.transform.position = new Vector3(1, 1, 1);
            icon.transform.localScale = new Vector3(1, 1, 1);
            icon.GetComponent<Renderer>().material.mainTexture = iconTexture;

            // Register GameObject that will display icon asset of native ad.
            if (!this.nativeAd.RegisterIconImageGameObject(icon))
            {
                // Handle failure to register ad asset.
            }
        }
    }
    private void RequestNativeAd()
    {
        AdLoader adLoader = new AdLoader.Builder(_adUnitId)
            .ForNativeAd()
            .Build();
        adLoader.OnNativeAdLoaded += this.HandleNativeAdLoaded;
        adLoader.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        adLoader.LoadAd(new AdRequest.Builder().Build());
        adLoader.OnAdFailedToLoad += this.HandleNativeAdFailedToLoad;

    }
    private void HandleNativeAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Native ad failed to load");
    }
    private void HandleNativeAdLoaded(object sender, NativeAdEventArgs args)
    {
        Debug.Log("Native ad loaded.");
        this.nativeAd = args.nativeAd;
        this.nativeAdLoaded = true;
    }
    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Native ad failed to load" + args.LoadAdError);
    }
}
*/
