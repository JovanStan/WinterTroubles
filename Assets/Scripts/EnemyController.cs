using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    public float rotateSpeed = 200f;
    public Transform model;

    public float health = 0;
    public float maxHealth = 100;
    public int reward = 20;
    public int id;

    public RectTransform healthUI;

	void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Vector3.zero);

        health = maxHealth;

    }

    
    void Update()
    {
        model.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    public void Hit(float dmg)
	{
        health -= dmg;
        Particles.instance.CreateParticles(ParticleType.HIT, transform.position);

        healthUI.localScale = new Vector3(health / maxHealth, 1, 1);

        if (health <= 0)
		{
            health = 0;
		}

        if(health == 0)
		{
            GameManager.instance.EnemyKilled(reward);
            Die();
		}

	}

    public void Die()
	{
        GameManager.instance.EnemyDied();
        Particles.instance.CreateParticles(ParticleType.EXPLOSION, transform.position);
        Destroy(gameObject);
	}
}
