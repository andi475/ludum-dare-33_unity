using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;


	
namespace UnityStandardAssets._2D
{
	public class MovingPlatformController : MonoBehaviour {
		int i;

		public float m_Speed = 0.4f;
		public float m_Distance = 1f;

		bool go_down=false;
		float min_y;
		float max_y;

		private Animator m_Anim;
		private Rigidbody2D m_Rigidbody2D;

        private void Awake(){
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
			min_y=m_Rigidbody2D.position.y;
			max_y=m_Rigidbody2D.position.y+m_Distance;
        }

		private void Update(){

			if(m_Rigidbody2D.position.y<min_y){
				go_down=false;
			}
			if(m_Rigidbody2D.position.y>max_y){
				go_down=true;
			}
			
			//move by keyboard input
			if(go_down){
				m_Rigidbody2D.velocity = new Vector2(0,-m_Speed);
			}
			else{
				m_Rigidbody2D.velocity = new Vector2(0,m_Speed);
			}

		}

    }
}
