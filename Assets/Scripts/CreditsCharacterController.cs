
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;



namespace UnityStandardAssets._2D{
	public class CreditsCharacterController : MonoBehaviour {
		int i;
		
		float work_end_time = 0f;
		
		float AnalogInputX = 0f;
		bool JumpInput = false;
		bool oldJumpInput = false;
		
		public float m_MaxSpeed = 10f;
		public float m_JumpForce = 400f;
		public float m_MovementForce = 30f;
		
		public float fireRate = 0.009f;
		private float nextWater = 0.0f;
		

		private Animator m_Anim;
		private Rigidbody2D m_Rigidbody2D;
		private Collider2D m_Collider2D;
		private void Awake(){
			m_Anim = GetComponent<Animator>();
			m_Rigidbody2D = GetComponent<Rigidbody2D>();
			m_Collider2D = GetComponent<Collider2D>();
		}
		

		
		private void Update(){

			// animator
			if (m_Rigidbody2D.velocity.x > 0) {
				m_Anim.Play ("RobotWalkRight");
			} else if (m_Rigidbody2D.velocity.x < 0) {
				m_Anim.Play ("RobotWalkLeft");
			} else {
				m_Anim.Play ("RobotIdle");
			}
		}

			

		
		void OnGUI() {
			GUI.color = Color.white;
			GUI.Label(new Rect(200, 100, 400, 30), "thanks for playing");
			GUI.Label(new Rect(200, 130, 400, 30), "Music: Tom");
			GUI.Label(new Rect(200, 150, 400, 30), "Graphics: Felix");
			GUI.Label(new Rect(200, 170, 400, 30), "Graphics: Lennart");
			GUI.Label(new Rect(200, 190, 400, 30), "Game Mechanics: Andi");
			//GUI.Label(new Rect(200, 210, 400, 30), "Special Thanks to Toby");

		}

	}
	
}
