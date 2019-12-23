using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

	public float startSpeed = 0.001f;
	public bool wasPlayed = false;
//	Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
	//	m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
		// Une note ne fait juste que descendre
		this.transform.Translate(-startSpeed,0,0);
    }
}
