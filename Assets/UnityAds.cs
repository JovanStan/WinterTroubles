using UnityEngine.Advertisements;
using UnityEngine;

public class UnityAds : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static UnityAds instance;

    public string id;
    public string interstelarName;
	public string rewardedName;

	private void Awake()
	{
		Initialize();
        
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}

	private void Update()
	{
		//ShowInterstitial();
        //ShowRewarded();
	}

	public void Initialize()
    {
        Advertisement.Initialize(id, false, this);
    }

    public void ShowRewarded()
    {
        Advertisement.Load(rewardedName, this);
    }

    public void ShowInterstitial()
    {
        Advertisement.Load(interstelarName, this);
    }
    
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads connected");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError("UNITY ADS NOT INITIALIZED");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {

    }
}
