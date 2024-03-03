using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParticleType
{
    PORTAL,
    EXPLOSION, 
    CANNON,
    HIT
}

public class Particles : MonoBehaviour
{
    public GameObject[] particles;

    public static Particles instance;

	private void Awake()
	{
		instance = this;
	}

	public void CreateParticles(ParticleType type, Vector3 pos)
	{
        int index = (int)type;
        GameObject particle = Instantiate(particles[index], pos, Quaternion.identity, transform);
        particle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
	}
}
