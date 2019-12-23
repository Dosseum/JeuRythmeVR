using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidOnDrum : MonoBehaviour
{
	public GameObject plaque;
	public AudioSource son;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	
	// On considere different null
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Controller") {
			/*son.Play();
			son.pitch = Random.Range(0.5f, 1.5f);*/
			
			if(plaque != null) {
				GameObject validPlay = plaque.transform.Find("ValidPlay").gameObject;
				validPlay.GetComponent<ValidPlay>().sonAudio = son;
				if(!validPlay.GetComponent<ValidPlay>().isPressed) {
					validPlay.GetComponent<ValidPlay>().isPressed = true;
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Controller") {
			if(plaque != null) {
				GameObject validPlay = plaque.transform.Find("ValidPlay").gameObject;
				if(validPlay.GetComponent<ValidPlay>().isPressed) {
					validPlay.GetComponent<ValidPlay>().isPressed = false;
				}
			}
		}
	}
	
	
}
