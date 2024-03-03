using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float health = 1000;

	private void Start()
	{
		GameManager.instance.UpdateCastle(health);
	}

	private void OnCollisionEnter(Collision collision)
	{
		EnemyController e = collision.gameObject.GetComponent<EnemyController>();

		if (e)
		{
			health -= e.health;

			if(health <= 0)
			{
				health = 0;
				LoseScreen.instance.losePanel.SetActive(true);
				Time.timeScale = 0f;
			}

			GameManager.instance.UpdateCastle(health);
			e.Die();
		}
	}
}
