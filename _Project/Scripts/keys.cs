using UnityEngine;
using System.Collections;

public class keys : MonoBehaviour {
    public bool HasBlueKey;
    public bool HasRedKey;
    public bool HasYellowKey;
    public bool HasGreenKey;

    public GameObject BlueKey;
    public GameObject GreenKey;
    public GameObject YellowKey;
    public GameObject RedKey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Pickup(object keyObj)
    {
        GameObject key = (GameObject)keyObj;

        if (key.tag == "BlueKey") 
        {
            HasBlueKey = true;
            BlueKey.SetActive(true);
        }
        if (key.tag == "RedKey") 
        {
            HasRedKey = true;
            RedKey.SetActive(true);
        }

        if (key.tag == "YellowKey") 
        {
            HasYellowKey = true;
            YellowKey.SetActive(true);
        }

        if (key.tag == "GreenKey") 
        {
            HasGreenKey = true;
            GreenKey.SetActive(true);
        }

        key.SetActive(false);
    }

    public void UnlockDoor(object doorObj)
    {
        GameObject door = (GameObject)doorObj;

        if(door.tag == "BlueDoor" && HasBlueKey)
        {
            door.SendMessage("Unlock");
        }

        if (door.tag == "RedDoor" && HasRedKey)
        {
            door.SendMessage("Unlock");
        }

        if (door.tag == "YellowDoor" && HasYellowKey)
        {
            door.SendMessage("Unlock");
        }

        if (door.tag == "GreenDoor" && HasGreenKey)
        {
            door.SendMessage("Unlock");
        }
    }
}
