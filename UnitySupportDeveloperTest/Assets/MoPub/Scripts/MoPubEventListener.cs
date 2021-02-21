using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Event Listener for MoPub Manager events
/// </summary>
public class MoPubEventListener : MonoBehaviour
{
    [Header("SDK Initialization")]

    [Tooltip("Text for confirming MoPub SDK initialization")]
    [SerializeField]
    private TextMeshProUGUI _MoPubInitializedText;

    [Tooltip("Image for indicating successful MoPub SDK initialization")]
    [SerializeField]
    private Image _MoPubStatusIndicatorImage;

    [Header("Ad Information")]

    [Tooltip("Text for displaying the ad information")]
    [SerializeField]
    private TextMeshProUGUI _adInfoText;

    [Header("Reward System")]

    // Reward Counter for displaying the number of rewards
    [SerializeField]
    private RewardCounter _rewardCounter;

    private void OnEnable()
    {
        // Subscribe to MoPub Manager events
        MoPubManager.OnInterstitialLoadedEvent += OnInterstitialLoadedEvent;
        MoPubManager.OnInterstitialFailedEvent += OnInterstitialFailedEvent;
        MoPubManager.OnInterstitialDismissedEvent += OnInterstitialDismissedEvent;
        MoPubManager.OnInterstitialExpiredEvent += OnInterstitialExpiredEvent;


        MoPubManager.OnRewardedVideoLoadedEvent += OnRewardedVideoLoadedEvent;
        MoPubManager.OnRewardedVideoFailedEvent += OnRewardedVideoFailedEvent;
        MoPubManager.OnRewardedVideoFailedToPlayEvent += OnRewardedVideoFailedToPlayEvent;
        MoPubManager.OnRewardedVideoClosedEvent += OnRewardedVideoClosedEvent;
    }


    private void OnDisable()
    {
        // Unsubscribe to MoPub Manager events
        MoPubManager.OnInterstitialLoadedEvent -= OnInterstitialLoadedEvent;
        MoPubManager.OnInterstitialFailedEvent -= OnInterstitialFailedEvent;
        MoPubManager.OnInterstitialDismissedEvent -= OnInterstitialDismissedEvent;
        MoPubManager.OnInterstitialExpiredEvent -= OnInterstitialExpiredEvent;

        MoPubManager.OnRewardedVideoLoadedEvent -= OnRewardedVideoLoadedEvent;
        MoPubManager.OnRewardedVideoFailedEvent -= OnRewardedVideoFailedEvent;
        MoPubManager.OnRewardedVideoFailedToPlayEvent -= OnRewardedVideoFailedToPlayEvent;
        MoPubManager.OnRewardedVideoClosedEvent -= OnRewardedVideoClosedEvent;
    }

    /// <summary>
    /// Handle MoPub SDK Initialization event.
    /// </summary>
    public void HandleMoPubInitialized()
    {
        // Display the MoPub SDK Initialization information
        _MoPubInitializedText.text = "MoPub SDK Initialization Succsessful!\n" +
            "Should show consent dialog? " + MoPub.ShouldShowConsentDialog;
        _MoPubInitializedText.gameObject.SetActive(true);

        // Set the MoPub SDK Initialization status indicator image color to green
        _MoPubStatusIndicatorImage.color = Color.green;
    }


    // Interstitial Events


    /// <summary>
    /// Handle MoPub SDK Interstitial Ad Loaded event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// </summary>
    private void OnInterstitialLoadedEvent(string pAdUnitId)
    {
        _adInfoText.text = "Interstitial Ad Loaded: " + pAdUnitId;
    }

    /// <summary>
    /// Handle MoPub SDK Interstitial Ad Failed event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// <param name="pError">The error message assocated with this ad.</param>
    /// </summary>
    private void OnInterstitialFailedEvent(string pAdUnitId, string pError)
    {
        _adInfoText.text = pAdUnitId + " Interstitial Ad Failed: " + pError;
    }

    /// <summary>
    /// Handle MoPub SDK Interstitial Ad Dismissed event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// </summary>
    private void OnInterstitialDismissedEvent(string pAdUnitId)
    {
        _adInfoText.text = "Interstitial Ad Dismissed: " + pAdUnitId;
    }

    /// <summary>
    /// Handle MoPub SDK Interstitial Ad Expired event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// </summary>
    private void OnInterstitialExpiredEvent(string pAdUnitId)
    {
        _adInfoText.text = "Interstitial Ad Expired: " + pAdUnitId;
    }


    // Rewarded Video Events


    /// <summary>
    /// Handle MoPub SDK Rewarded Video Ad Loaded event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// </summary>
    private void OnRewardedVideoLoadedEvent(string pAdUnitId)
    {
        _adInfoText.text = "Rewarded Video Ad Loaded: " + pAdUnitId;
    }

    /// <summary>
    /// Handle MoPub SDK Rewarded Video Ad Load Failed event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// <param name="pError">The error message assocated with this ad.</param>
    /// </summary>
    private void OnRewardedVideoFailedEvent(string pAdUnitId, string pError)
    {
        _adInfoText.text = pAdUnitId + " Rewarded Video Ad Load Failed: " + pError;
    }


    /// <summary>
    /// Handle MoPub SDK Rewarded Video Ad Play Failed event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// <param name="pError">The error message assocated with this ad.</param>
    /// </summary>
    private void OnRewardedVideoFailedToPlayEvent(string pAdUnitId, string pError)
    {
        _adInfoText.text = pAdUnitId + " Rewarded Video Ad Play Failed: " + pError;
    }

    /// <summary>
    /// Handle MoPub SDK Rewarded Video Ad Closed event
    /// <param name="pAdUnitId">The Ad Unit ID assocated with this ad.</param>
    /// </summary>
    private void OnRewardedVideoClosedEvent(string pAdUnitId)
    {
        _adInfoText.text = "Rewarded Video Ad Dismissed: " + pAdUnitId;

        // Add the reward to the reward counter display.
        _rewardCounter.AddReward();
    }
}
