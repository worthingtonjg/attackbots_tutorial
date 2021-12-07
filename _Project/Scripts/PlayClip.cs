using UnityEngine;
using System.Collections;

public class PlayClip : MonoBehaviour {
    public AudioClip clip;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void PlayAudioClip()
    {
        audioSource.PlayOneShot(clip);
        Debug.Log("Playing Clip");
    }
}
