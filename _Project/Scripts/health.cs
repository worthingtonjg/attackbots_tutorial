using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour {
    public float TotalHealth;
    public float Health;
    public Image healthBar;
    public GameObject explosionPrefab;
    public float HealthPickupValue = 10;

    private GameObject player;
    private PlayClip clipPlayer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(object amount)
    {
        UpdateHealth(-((float)amount));

        if (Health <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                GameObject clone = Instantiate(explosionPrefab, gameObject.transform.position + Vector3.up, Quaternion.identity) as GameObject;
                clone.SetActive(true);

                gameObject.SetActive(false);
            }

            if(gameObject.tag == "Player")
            {
                SceneLoader.LoadScene("GameOver");
            }
        }
    }

    public void Pickup(object healthPickup)
    {
        if (gameObject.tag != "Player") return;

        GameObject health = (GameObject)healthPickup;

        if (health.tag != "Health") return;

        UpdateHealth(HealthPickupValue);

        Debug.Log("Health Pickup += " + HealthPickupValue);

        health.SetActive(false);
    }

    private void UpdateHealth(float amount)
    {
        Health += amount;
        if (Health > TotalHealth) Health = TotalHealth;

        if(healthBar != null)
        healthBar.fillAmount = Health / TotalHealth;
    }
}
