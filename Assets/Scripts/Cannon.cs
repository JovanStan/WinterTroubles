using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float radius = 2f;
    public float damage = 30;
    public float reload = 2f;
    public Transform gun;

    private Circle circle;
    private Transform target = null;
    public ParticleType type;
    public Transform position;
        void Start()
    {
        StartCoroutine(Shoot());
        circle = GetComponentInChildren<Circle>();
        //circle._horizRadius = radius;
        //circle._vertRadius = radius;
    }

    
    void Update()
    {
        FindTarget();
    }

	private void LateUpdate()
	{
		if(target != null)
		{
            gun.transform.LookAt(target);
		}
	}

	private void FindTarget()
	{
        int layerMask = 1 << LayerMask.NameToLayer("Enemy");
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        target = null;
        int minID = int.MaxValue;
        foreach(Collider c in hitColliders)
		{
            int id = c.GetComponent<EnemyController>().id;
            if(minID > id)
            {
				target = c.transform;
                minID = id;
			}
		}
	}

    IEnumerator Shoot()
	{
		while (true)
		{
            if(target != null)
			{
                target.GetComponent<EnemyController>().Hit(damage);
                Particles.instance.CreateParticles(type, position.position);
                yield return new WaitForSeconds(reload);
			}
			else
			{
                yield return new WaitForSeconds(.1f);
			}
		}
	}

    public void UpgradeCanon()
	{
        radius += 1;
        circle._horizRadius = radius;
        circle._vertRadius = radius;
    }
}
