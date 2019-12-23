using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showNote : MonoBehaviour
{
	public GameObject[] listObjectsCanTakeAppareance;
    // Start is called before the first frame update
    void Start()
    {
        GameObject p = listObjectsCanTakeAppareance[Random.Range(0, listObjectsCanTakeAppareance.Length)];
		
		GameObject newInstance = Instantiate(p, transform);
		newInstance.transform.parent = transform;


    }

    // Update is called once per frame
    void Update()
    {
    }
}
