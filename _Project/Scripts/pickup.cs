using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {
    public float rotateSpeed = .5f;
    public Vector3 rotateDirection = new Vector3(0, 0, 1f);
    public AudioClip clip;

    private GameObject player;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(rotateDirection, rotateSpeed);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.PlayOneShot(clip);
            other.gameObject.SendMessage("Pickup", gameObject, SendMessageOptions.DontRequireReceiver);
            Debug.Log("Pickup " + gameObject.tag);
        }
    }
}
