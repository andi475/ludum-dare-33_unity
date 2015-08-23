using UnityEngine;
using System.Collections;

public class YToZMapping : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.y);

	}
}
