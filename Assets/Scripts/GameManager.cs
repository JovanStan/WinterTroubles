using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI castelText, redSugarText;

    public static GameManager instance;

    public int redSugar;

    public GameObject[] canons;
    public int[] cost;
    public int[] upgrades;
    public Transform canonsParent;
    private GameObject[] platforms;

    public GameObject smallEnemy, bigEnemy;
    public Transform[] spawns;
    public Transform enemyParent;
    private int IDG = 0;

    public int wave = 0;
    public float waveHealth = 10;
    public float waveSpeed = .1f;
    public int waveNumber = 30;
    public int waveLeft = 30;

    public Animator anim;
    public TextMeshProUGUI waveUI;
    public TextMeshProUGUI enemyUI;

	public AudioSource sfx;
	public void PlaySfx()
	{
		sfx.Play();
	}

	private void Awake()
	{
		instance = this;
        UpdateRedSugar();
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        StartCoroutine("Wave");
    }

	private void Start()
	{
        UpdateEnemies();
	}

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.instance.pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        UpdateEnemies();
    }

    private void UpdateWave()
    {
        waveUI.text = "WAVE " + wave;
        anim.SetTrigger("show");
    }

    private void UpdateEnemies()
    {
        string left = waveLeft < 10 ? "0" + waveLeft : waveLeft.ToString();
        enemyUI.text = "Wave " + wave + ": " + left;
    }

	public void UpdateCastle(float health)
	{
        castelText.text = health.ToString();
	}

    public void EnemyKilled(int reward)
	{
        redSugar += reward;
        UpdateRedSugar();
	}

    private void UpdateRedSugar()
	{
        redSugarText.text = redSugar.ToString();
	}

    public GameObject PlaceCanon(Vector3 pos, int type)
	{
        int price = cost[type];

        if(redSugar < price)
		{
            return null;
		}
		else
		{
            redSugar -= price;
            AudioManager.instance.PlaySfx(0);
            UpdateRedSugar();
            GameObject canon = Instantiate(canons[type], pos, Quaternion.identity, canonsParent);

            return canon;
		}
	}

    public void UpgradeCanon(Cannon canon)
	{
        int price = upgrades[0];

        if(redSugar >= price)
		{
            redSugar -= price;
            UpdateRedSugar();
            AudioManager.instance.PlaySfx(1);
            canon.UpgradeCanon();
            HidePanels();
        }
		else
		{
           
		}
	}

    public void HidePanels()
	{
        for(int i = 0; i < platforms.Length; i++)
		{
            platforms[i].GetComponent<PlatformBuilding>().panelCreate.SetActive(false);
            platforms[i].GetComponent<PlatformBuilding>().panelUpgrade.SetActive(false);
        }
	}

    IEnumerator SpawnEnemy()
	{
        GameObject enemy;
        if(Random.Range(0f, 1f) < .9f)
		{
            enemy = smallEnemy;
		}
		else
		{
            enemy = bigEnemy;
		}
        Vector3 position = spawns[Random.Range(0, spawns.Length)].position;
        yield return new WaitForSeconds(.5f);

        GameObject e = Instantiate(enemy, position, Quaternion.identity, enemyParent);
        e.GetComponent<EnemyController>().maxHealth += wave * waveHealth;
		e.GetComponent<EnemyController>().id = IDG++;
		e.GetComponent<NavMeshAgent>().speed += wave * waveSpeed;
	}

    public void EnemyDied()
	{
        waveLeft--;
        if(waveLeft == 0)
		{
            wave++;
            waveNumber += 2;
            waveLeft = waveNumber;
            StartCoroutine("Wave");
		}
	}

    IEnumerator Wave()
	{
        yield return new WaitForSeconds(2f);
        UpdateWave();
        UpdateEnemies();

		yield return new WaitForSeconds(2f);

		for (int i = 0; i < waveNumber; i++)
		{
            StartCoroutine("SpawnEnemy");
            yield return new WaitForSeconds(5f);
		}
	}

    public void PauseUnpause()
	{
		if (PauseMenu.instance.pausePanel.activeInHierarchy)
		{
            PauseMenu.instance.pausePanel.SetActive(false);
            Time.timeScale = 1f;
		}
		else
		{
            PauseMenu.instance.pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
	}
}
