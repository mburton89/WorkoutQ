using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance;

	public AudioClip nextSet;
	public AudioClip nextExercise;

	public AudioSource audioSource;

	void Awake () {
		Instance = this;
	}

	public void PlayNewSetSound(){
		audioSource.clip = nextSet;
		audioSource.Play ();
	}

	public void PlayNewExerciseSound(){
		audioSource.clip = nextExercise;
		audioSource.Play ();
	}
}
