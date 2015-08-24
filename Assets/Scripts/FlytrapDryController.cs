using UnityEngine;
using System.Collections;
using System;

namespace UnityStandardAssets._2D
{

public class FlytrapDryController : MonoBehaviour {
	int i = 0;

	public GameObject flytrap_prefab;

	
	private Rigidbody2D m_Rigidbody2D;
	private void Awake(){
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}


		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "water"){
				i++;
			}
			if (i>15){
				Instantiate(flytrap_prefab, m_Rigidbody2D.position, Quaternion.identity);
				Destroy (this.gameObject, 0f);
			}
		}

		/*
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "player"){
			i++;
			Application.LoadLevel(Application.loadedLevelName);
		}
		if (i>15){
			Instantiate(flytrap_prefab, m_Rigidbody2D.position, Quaternion.identity);
			Destroy (this.gameObject, 0f);
		}
	}
	*/

	// Update is called once per frame
	void Update () {
	
	}
}

}