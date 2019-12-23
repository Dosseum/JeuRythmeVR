using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidPlay : MonoBehaviour
{
	
	public bool isPressed = false;
	public GameObject animationWhenOk;
	GameObject notePressed = null;
	bool wasOkWhenPressed = false;
	public AudioSource sonAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
	
		// Obliger a release après avoir taper une note
		if(wasOkWhenPressed == true && !isPressed) {
			wasOkWhenPressed = false;
		}
		
        if( (isPressed && notePressed == null && !wasOkWhenPressed) ) {
			// Si on rate on fait un flash rouge sur l'écran de la camera
			GameManager.score--;
			GameManager.UpdateScore();
			if(GameManager.score < 0) {
				GameObject GO = GameObject.Find("GameOver");
				GO.GetComponent<UnityEngine.UI.Text>().enabled = true;
				// J'appelle le stopgame
				GameObject.Find("SpawnManager").GetComponent<SpawnManager>().StopGame();
			}
			GameObject.Find("FailSound").GetComponent<AudioSource>().Play();
			wasOkWhenPressed = true;
		//	GameObject.Find("Musique").GetComponent<AudioSource>().volume = 0;
			GameObject.Find("SpawnManager").GetComponent<SpawnManager>().failMusique = true;
			
		}
		if(isPressed && notePressed != null && !wasOkWhenPressed) {
			Material myMat = Resources.Load("bleu", typeof(Material)) as Material;
			notePressed.GetComponent<Renderer>().material = myMat;
			GameManager.score++;
			GameManager.UpdateScore();
			Instantiate(animationWhenOk, notePressed.transform.position, Quaternion.identity);
			Destroy(notePressed);
			notePressed = null;
			wasOkWhenPressed = true;
			sonAudio.Play();
			sonAudio.pitch = Random.Range(0.5f, 1.5f);
			//GameObject.Find("Musique").GetComponent<AudioSource>().volume = 1;
			GameObject.Find("SpawnManager").GetComponent<SpawnManager>().failMusique = false;
		}
		
		
    }
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Controller") {
			if(!isPressed) {
				isPressed = true;
			}
		}
		
		if(other.gameObject.tag == "Note") {
			notePressed = other.gameObject;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Controller") {
			if(isPressed) {
				isPressed = false;
			}
		}
		
		if(other.gameObject.tag == "Note") {
			notePressed = null;
		}
	}
}
