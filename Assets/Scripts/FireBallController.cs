using System;
using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
	public class FireBallController : MonoBehaviour
	{
		
		private Rigidbody2D m_Rigidbody2D;
		
		private void Awake(){
			m_Rigidbody2D = GetComponent<Rigidbody2D> ();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
		private void Update(){
			//m_Rigidbody2D.transform.localPosition = new Vector3 (0,UnityEngine.Random.value,0);
		}
	}
}
