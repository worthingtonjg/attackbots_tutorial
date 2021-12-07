using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour {
    public string NextLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!string.IsNullOrEmpty(NextLevel))
            {
                SceneLoader.LoadScene(NextLevel);
            }
        }
    }
}
