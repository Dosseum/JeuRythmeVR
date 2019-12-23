using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Controller") {
			 Application.LoadLevel(Application.loadedLevel);
		}
	}
}
