using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject controlsPanel;


	public void OpenControls()
	{
        controlsPanel.SetActive(true);
        Time.timeScale = 0f;
	}

    public void CloseControls()
	{
        controlsPanel.SetActive(false);
        Time.timeScale = 1f;
	}
}
