using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;


	
namespace UnityStandardAssets._2D
{
	public class WaterController : MonoBehaviour {
		int i=0;
		
		public float m_Speed = -5f;
		public float m_Size = 0.03f;

		float min_y;
		float max_y;

		private Rigidbody2D m_Rigidbody2D;

        private void Awake(){

			m_Rigidbody2D = GetComponent<Rigidbody2D>();

			m_Rigidbody2D.transform.localScale = new Vector3(m_Size,m_Size,m_Size);

			Destroy (this.gameObject, 1f);
        }

		private void Update(){
			
			m_Rigidbody2D.velocity = new Vector2(0,m_Speed);

			m_Rigidbody2D.transform.localScale = new Vector3(m_Size*i,m_Size*i,m_Size);
			i++;

		}

    }
}
