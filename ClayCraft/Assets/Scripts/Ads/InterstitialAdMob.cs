using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterstitialAdMob : MonoBehaviour
{
    private InterstitialAd interstitial;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();

        if (this.interstitial.CanShowAd())
        {
            this.interstitial.Show();
        }
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3914842506228488/1102839198";
#elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
                string adUnitId = "unexpected_platform";
#endif

        string loadedAdUnitId = adUnitId;
        // Initialize an InterstitialAd.
        //this.interstitial = new InterstitialAd(adUnitId); //adicionar "adUnitId como parametro

        // Create an empty ad request.
        AdRequest request = new AdRequest();

        // Load the interstitial with the request.
        InterstitialAd.Load(adUnitId, request, (loadedAd, error) => {
            if (error != null)
            {
                Debug.LogError("Erro ao carregar o anúncio intersticial: ");
            }
            else
            {
                // Acesse o ID do anúncio
                //string loadedAdUnitId = AdUnitId;
                Debug.Log("Anúncio intersticial carregado com sucesso. ID: " + loadedAdUnitId);

                this.interstitial = loadedAd;
                ShowInterstitial();
            }
        });

    }

    private void ShowInterstitial()
    {
        if (CanShowAd())
        {
            this.interstitial.Show();
        }
    }

    private bool CanShowAd()
    {
        return this.interstitial != null && this.interstitial.CanShowAd();
    }

    public void OnButtonClick()
    {
        RequestInterstitial(); // Carrega o anúncio intersticial quando o botão é clicado
    }

}
