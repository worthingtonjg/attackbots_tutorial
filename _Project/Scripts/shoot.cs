using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
    public float firingSpeed = 1f;
    public float bulletSpeed = 20f;
    public float bulletLife = 3f;
    public bool autoFire = false;
    public Transform gun;
    public AudioClip clip;
    public GameObject bulletPrefab;

    private float lastFire;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        lastFire = Time.time - firingSpeed;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (autoFire)
        {
            Shoot();
        }

        if(Input.GetButton("Fire1") && gameObject.tag == "Player")
        {
            Shoot();
        }
	}

    public void Shoot()
    {
        if (Time.time >= lastFire + firingSpeed)
        {
            lastFire = Time.time;
            var clone = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody>().velocity = gun.transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
            clone.GetComponent<projectile>().SetFiredBy(gameObject.tag);
            Destroy(clone.gameObject, bulletLife);
            audioSource.PlayOneShot(clip);
        }
    }
}
