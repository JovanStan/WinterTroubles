using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public GameObject losePanel;
    
    public static LoseScreen instance;

	private void Awake()
	{
		instance = this;
	}

	public void Restart()
	{
		SceneManager.LoadScene("Gameplay");
		Time.timeScale = 1f;
	}

    public void Menu()
	{
        SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1f;
	}

   
}
