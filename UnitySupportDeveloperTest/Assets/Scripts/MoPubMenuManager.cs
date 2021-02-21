using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manager for the MoPub Ad Menu UI buttons
/// </summary>
public class MoPubMenuManager : MonoBehaviour
{
    // Array of strings for Banner Ad Units
    private readonly string[] _bannerAdUnits = { "b195f8dd8ded45fe847ad89ed1d016da" };

    // Array of strings for Interstitial Ad Units
    private readonly string[] _interstitialAdUnits = { "24534e1901884e398f1253216226017e", "f241e74af2894cb78688a53e2925dec9" };

    // Array of strings for Rewarded Video Ad Units
    private readonly string[] _rewardedAdUnits =
        { "920b6145fb1546cf8b5cf2ac34638bb7", "0d7bb471015c4d40bd9232524dd1bdc9" };


    private void Start()
    {
        MoPub.LoadConsentDialog();
    }

    /// <summary>
    /// Handle MoPub Menu Initialization Button Pressed event.
    /// </summary>
    public void OnInitializeMoPubPressed()
    {
        MoPub.InitializeSdk(MoPubManager.Instance.SdkConfiguration);

        MoPub.LoadBannerPluginsForAdUnits(_bannerAdUnits);
        MoPub.LoadInterstitialPluginsForAdUnits(_interstitialAdUnits);
        MoPub.LoadRewardedVideoPluginsForAdUnits(_rewardedAdUnits);
    }

    /// <summary>
    /// Handle MoPub Menu Load Interstitial Ad Button Pressed event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// </summary>
    public void OnLoadInterstitialAd(int pAdUnitIndex)
    {
        MoPub.RequestInterstitialAd(_interstitialAdUnits[pAdUnitIndex]);
    }

    /// <summary>
    /// Handle MoPub Menu Show Interstitial Ad Button Pressed event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// </summary>
    public void OnShowInterstitialAd(int pAdUnitIndex)
    {
        MoPub.ShowInterstitialAd(_interstitialAdUnits[pAdUnitIndex]);
    }

    /// <summary>
    /// Handle MoPub Menu Load Rewarded Video Ad Button Pressed event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// </summary>
    public void OnLoadRewardedVideoAd(int pAdUnitIndex)
    {
        MoPub.RequestRewardedVideo(_rewardedAdUnits[pAdUnitIndex]);
    }

    /// <summary>
    /// Handle MoPub Menu Show Rewarded Video Ad Button Pressed event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// </summary>
    public void OnShowRewardedVideoAd(int pAdUnitIndex)
    {
        MoPub.ShowRewardedVideo(_rewardedAdUnits[pAdUnitIndex]);
    }
}
