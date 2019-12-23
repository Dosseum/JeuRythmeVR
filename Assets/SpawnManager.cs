using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] plaques;
	
	public float timeSpawn = 1;
	public float accelerateTime = 10; // toutes les 5 secondes on accelere
	public float startSpeed = 0.01f;
	public const float acceleration = 1.1f;
	public const float decreasedTime = 1.1f;
	
	// Pas seralize
	public bool failMusique = false;
	
	 private Coroutine spawnCorout;
	 private Coroutine speedCorout;



 
	
    // Start is called before the first frame update
    void Start() {
		spawnCorout = StartCoroutine(SpawnCoroutine());
		speedCorout = StartCoroutine(ChangeSpeed());
		GameObject.Find("Musique").GetComponent<AudioSource>().Play();
		GameManager.score = 10;
		failMusique = false;
    }
	
	IEnumerator ChangeSpeed() {
		while(true) {
			yield return new WaitForSeconds(accelerateTime);
			startSpeed *= acceleration;
			timeSpawn /= decreasedTime;
			// Puis on change sur les objets
			foreach (GameObject tmpNote in GameObject.FindGameObjectsWithTag("Note")) {
				tmpNote.GetComponent<Note>().startSpeed = startSpeed;				
			}
		}
	}
	
	IEnumerator SpawnCoroutine() {
		while(true) {
			yield return new WaitForSeconds(timeSpawn);
			// On va en prendre un aléatoire
			GameObject p = plaques[Random.Range(0, plaques.Length)];
//			foreach (GameObject p in plaques) {
				GameObject tmpNote = p.transform.Find("Note").gameObject;
				GameObject newNote = Instantiate(tmpNote, p.transform);
				newNote.active = true;
				newNote.GetComponent<Note>().startSpeed = startSpeed;
				
	//		}

		}
    }
	
	public void StopGame() {
	
		StopCoroutine(spawnCorout);
		StopCoroutine(speedCorout);
		// On détruit toutesl es notes
		GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
		foreach(GameObject n in notes)
			Destroy(n);
		
		GameObject.Find("Musique").GetComponent<AudioSource>().Stop();
			
	}

    // Update is called once per frame
    void Update()
    {
		if(failMusique) {
			GameObject.Find("Musique").GetComponent<AudioSource>().volume -= 0.005f;
		} else {
			GameObject.Find("Musique").GetComponent<AudioSource>().volume += 0.01f;
		}
		if(GameObject.Find("Musique").GetComponent<AudioSource>().volume > 1)
			GameObject.Find("Musique").GetComponent<AudioSource>().volume = 1f;
		if(GameObject.Find("Musique").GetComponent<AudioSource>().volume < 0)
			GameObject.Find("Musique").GetComponent<AudioSource>().volume = 0f;
    }
	
	
}
