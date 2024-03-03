using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;

    public static AudioManager instance;

	private void Awake()
	{
		instance = this;
	}

	public void PlaySfx(int number)
	{
		sfx[number].Play();
	}

}
