using UnityEngine;
using System.Collections.Generic;

public class zone : MonoBehaviour {
    public List<GameObject> Listeners;
  
    // Use this for initialization
	void Start () {
        Listeners.ForEach(l => {
            l.SetActive(false);
        });
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Zone Entered - Waking up room");
            Listeners.ForEach(l => {
                l.SendMessage("WakeUp", SendMessageOptions.DontRequireReceiver);
            });
        }
    }

    public void DoorOpened()
    {
        Debug.Log("Door Opened - Waking up room");
        Listeners.ForEach(l => {
            l.SetActive(true);
        });
    }
}
