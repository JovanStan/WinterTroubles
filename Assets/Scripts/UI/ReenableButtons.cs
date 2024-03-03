using UnityEngine;
using UnityEngine.UI;

public class ReenableButtons : MonoBehaviour
{
    [SerializeField] private Button startButton;
	[SerializeField] private Button creditsButton;
	[SerializeField] private Button basicInfoButton;
	[SerializeField] private Button exitButton;

	public void DisableButtons()
	{
		startButton.interactable = false;
		creditsButton.interactable = false;
		basicInfoButton.interactable = false;
		exitButton.interactable = false;
	}

	public void EnableButtons()
	{
		startButton.interactable = true;
		creditsButton.interactable = true;
		basicInfoButton.interactable = true;
		exitButton.interactable = true;
	}
}
