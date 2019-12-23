using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour
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
		if(other.gameObject.tag == "Note") {
		//	if(!other.gameObject.GetComponent<Note>().wasPlayed) {
				// GameOver là aussi
				GameManager.score--;
				GameManager.UpdateScore();
				if(GameManager.score < 0) {
					GameObject GO = GameObject.Find("GameOver");
					GO.GetComponent<UnityEngine.UI.Text>().enabled = true;
					// J'appelle le stopgame
					GameObject.Find("SpawnManager").GetComponent<SpawnManager>().StopGame();
				}
				Destroy(other.gameObject);
				GameObject.Find("FailSound").GetComponent<AudioSource>().Play();
		}
	}
}
