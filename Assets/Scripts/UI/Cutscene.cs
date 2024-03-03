using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public GameObject button;
    void Start()
    {
        StartCoroutine(showButton());
    }

    IEnumerator showButton()
	{
        yield return new WaitForSeconds(19f);
        button.SetActive(true);
	}

    public void StartGame()
	{
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 0f;
	}
}
