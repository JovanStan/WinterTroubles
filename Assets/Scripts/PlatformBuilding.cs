using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformBuilding : MonoBehaviour
{

    public GameObject panelCreate, panelUpgrade;
    private GameObject canon = null;
    //public GameObject circle;
    
    void Start()
    {

    }

    public void Build(int type)
	{
		switch (type)
		{
            case 0:
                canon = GameManager.instance.PlaceCanon(transform.position, type);
                break;
            case 1:
                canon = GameManager.instance.PlaceCanon(transform.position, type);
                break;
            case 2:
                GameManager.instance.UpgradeCanon(canon.GetComponent<Cannon>());
                break;
            case 3:
                Destroy(canon);
                AudioManager.instance.PlaySfx(2);
                canon = null;
                Particles.instance.CreateParticles(ParticleType.EXPLOSION, transform.position);
                break;
        }
        panelUpgrade.SetActive(false);
        panelCreate.SetActive(false);
	}

	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
            return;
		}

		GameObject panel;
        if (canon == null)
		{
            GameManager.instance.HidePanels();
            panel = panelCreate;
		}
		else
		{
            GameManager.instance.HidePanels();
            panel = panelUpgrade;
		}

		if (panel.activeSelf)
		{
            panel.SetActive(false);
		}
		else
		{
            panel.SetActive(true);
		}
    }

}
