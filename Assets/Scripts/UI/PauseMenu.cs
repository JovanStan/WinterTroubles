using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
	public static PauseMenu instance;

	public GameObject pausePanel;

	public AudioMixer mixer;

	private void Awake()
	{
		instance = this;
	}

	void Update()
    {

    }

	public void SetGameVolume(float volume)
	{
		mixer.SetFloat("inGameVolume", volume);
	}

	public void Resume()
	{
		GameManager.instance.PauseUnpause(); 
	}

	public void Menu()
	{
		SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1f;
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void Pause()
	{
		GameManager.instance.PauseUnpause();
	}
}
