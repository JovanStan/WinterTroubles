using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
	public GameObject mainMenuPanel, settingsPanel, creditsPanel;

	public GameObject videoSettingsObjects, volumeSettingsObjects, gameSettingsObjects;
	public Button videoButton, volumeButton, gameButton;


	private void Start()
	{
		gameButton.image.color = new Color(255, 255, 255, 0.3f);
		volumeButton.image.color = new Color(255, 255, 255, 0.3f);
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Gameplay");
		Time.timeScale = 1f;
	}

	public void Settings()
	{
		mainMenuPanel.SetActive(false);
		settingsPanel.SetActive(true);
		videoSettingsObjects.SetActive(true);
		volumeSettingsObjects.SetActive(false);
		gameSettingsObjects.SetActive(false);
		gameButton.image.color = new Color(255, 255, 255, 0.3f);
		volumeButton.image.color = new Color(255, 255, 255, 0.3f);
		videoButton.image.color = new Color(255, 255, 255, 1f);
	}

	public void Credits()
	{
		creditsPanel.SetActive(true);
		mainMenuPanel.SetActive(false);
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void BackCredits()
	{
		creditsPanel.SetActive(false);
		mainMenuPanel.SetActive(true);
	}

	public void BackOptions()
	{
		mainMenuPanel.SetActive(true);
		settingsPanel.SetActive(false);
	}

	public void VolumeObjects()
	{
		videoSettingsObjects.SetActive(false);
		volumeSettingsObjects.SetActive(true);
		gameSettingsObjects.SetActive(false);
		videoButton.image.color = new Color(255, 255, 255, 0.3f);
		gameButton.image.color = new Color(255, 255, 255, 0.3f);
		volumeButton.image.color = new Color(255, 255, 255, 1f);
	}

	public void VideoObjects()
	{
		videoSettingsObjects.SetActive(true);
		volumeSettingsObjects.SetActive(false);
		gameSettingsObjects.SetActive(false);
		videoButton.image.color = new Color(255, 255, 255, 1f);
		gameButton.image.color = new Color(255, 255, 255, 0.3f);
		volumeButton.image.color = new Color(255, 255, 255, 0.3f);
	}

	public void GameObjects()
	{
		videoSettingsObjects.SetActive(false);
		volumeSettingsObjects.SetActive(false);
		gameSettingsObjects.SetActive(true);
		videoButton.image.color = new Color(255, 255, 255, 0.3f);
		gameButton.image.color = new Color(255, 255, 255, 1f);
		volumeButton.image.color = new Color(255, 255, 255, 0.3f);
	}
}
