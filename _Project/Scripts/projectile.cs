using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {
    public float damage = 10;
    private string firedByTag = "";

    void OnTriggerEnter(Collider other)
    {
        if (firedByTag == other.tag) return;
        if (other.isTrigger) return;

        Debug.Log(other.tag);
        Destroy(gameObject);
        other.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
    }

    public void SetFiredBy(string tag)
    {
        firedByTag = tag;
        Debug.Log("Fired by: " + tag);
    }
}
