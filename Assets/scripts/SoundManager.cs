﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public static SoundManager Instance = null;

	public AudioClip goalBloop;
	public AudioClip LossBuzz;
	public AudioClip hitPaddleBloop;
	public AudioClip WinSound;
	public AudioClip WallBloop;

	private AudioSource soundEffectAudio;

	// Use this for initialization
	void Start () {
		if (Instance == null)
		{
			Instance = this;
		} else if (Instance != this)
		{
			Destroy (gameObject);
		}

//		AudioSource[] sources = GetComponents<AudioSource> ();

//		foreach (AudioSource source in sources) {
//			if (source.clip == null) {
//				soundEffectAudio = source;
//			}
//		}*/

		AudioSource theSource = GetComponent<AudioSource> ();
		soundEffectAudio = theSource;
	}

	public void PlayOneShot(AudioClip clip) {
		soundEffectAudio.PlayOneShot (clip);
	}
}
