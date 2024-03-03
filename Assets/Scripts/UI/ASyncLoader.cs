using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ASyncLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen, mainMenu;

    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Button playButton;
    

    public void LoadLevelButton(string levelToLoad)
	{
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelASync(levelToLoad));  
    }


    IEnumerator LoadLevelASync(string levelToLoad)
	{
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

		while(!loadOperation.isDone)
		{
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;

			if (loadOperation.isDone)
			{
                playButton.gameObject.SetActive(true);
			}
		}
	}

}
