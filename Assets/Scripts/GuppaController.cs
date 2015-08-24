using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;


	
namespace UnityStandardAssets._2D
{
	public class GuppaController : MonoBehaviour {
		int i;

		public float m_Speed = 0.4f;
		public float m_Distance = 1f;

		bool go_left=false;
		float min_x;
		float max_x;

		private Animator m_Anim;
		private Rigidbody2D m_Rigidbody2D;

        private void Awake(){
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
			min_x=m_Rigidbody2D.position.x;
			max_x=m_Rigidbody2D.position.x+m_Distance;
        }

		private void Update(){

			if(m_Rigidbody2D.position.x<min_x){
				go_left=false;
			}
			if(m_Rigidbody2D.position.x>max_x){
				go_left=true;
			}
			
			//move by keyboard input
			if(go_left){
				m_Rigidbody2D.velocity = new Vector2(-m_Speed,0);
			}
			else{
				m_Rigidbody2D.velocity = new Vector2(m_Speed,0);
			}

		}

    }
}
