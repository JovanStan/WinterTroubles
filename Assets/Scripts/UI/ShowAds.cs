using System;
using UnityEngine;

public class ShowAds : MonoBehaviour
{
	private const string HourlyAdTimeKey = "LastAdShowTimeHourly";
	private const string ThreeHourAdTimeKey = "LastAdShowTime3Hours";

	private DateTime lastAdShowTimeHourly;
	private DateTime lastAdShowTime3Hours;

	private void Start()
	{
		if (PlayerPrefs.HasKey(HourlyAdTimeKey))
		{
			string hourlyTime = PlayerPrefs.GetString(HourlyAdTimeKey);
			lastAdShowTimeHourly = DateTime.Parse(hourlyTime);
		}
		else
		{
			lastAdShowTimeHourly = DateTime.MinValue;
		}

		if (PlayerPrefs.HasKey(ThreeHourAdTimeKey))
		{
			string threeHourTime = PlayerPrefs.GetString(ThreeHourAdTimeKey);
			lastAdShowTime3Hours = DateTime.Parse(threeHourTime);
		}
		else
		{
			lastAdShowTime3Hours = DateTime.MinValue; 
		}
	}

	private void OnApplicationQuit()
	{
		PlayerPrefs.SetString(HourlyAdTimeKey, lastAdShowTimeHourly.ToString());
		PlayerPrefs.SetString(ThreeHourAdTimeKey, lastAdShowTime3Hours.ToString());
		PlayerPrefs.Save();
	}

	public void ShowAdOnceAnHour()
	{
		if (DateTime.Now - lastAdShowTimeHourly >= TimeSpan.FromHours(1))
		{
			UnityAds.instance.ShowInterstitial();
			lastAdShowTimeHourly = DateTime.Now;
		}
	}

	public void ShowAdOnceEvery3Hours()
	{
		if (DateTime.Now - lastAdShowTime3Hours >= TimeSpan.FromHours(3))
		{
			UnityAds.instance.ShowInterstitial();
			lastAdShowTime3Hours = DateTime.Now;
		}
	}

	public void ShowAd()
	{
		UnityAds.instance.ShowInterstitial();
	}
}
