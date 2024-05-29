using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAdMob : MonoBehaviour
{
    private BannerView bannerView;
    // Start is called before the first frame update
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3914842506228488/7731097771";
#elif UNITY_IPHONE
                    string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
                    string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
}
