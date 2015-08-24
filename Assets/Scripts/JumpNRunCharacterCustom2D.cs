using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;


	
namespace UnityStandardAssets._2D
{
	public class JumpNRunCharacterCustom2D : MonoBehaviour {
		int i;

		
		float AnalogInputX = 0f;
		bool JumpInput = false;
		bool oldJumpInput = false;

		public float m_MaxSpeed = 10f;
		public float m_JumpForce = 400f;
		public float m_MovementForce = 30f;
		
		public GameObject water_prefab;

		private Animator m_Anim;
		private Rigidbody2D m_Rigidbody2D;
        private void Awake(){
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

		public float fireRate = 0.009f;
		private float nextWater = 0.0f;






		private void Update(){


			AnalogInputX = CrossPlatformInputManager.GetAxis("Horizontal");
			JumpInput = CrossPlatformInputManager.GetButton("Jump") || CrossPlatformInputManager.GetAxis("Vertical")>0;

			//jumping
			if(!oldJumpInput && JumpInput){
				m_Rigidbody2D.AddForce( new Vector2( 0f , m_JumpForce ) );
			}
			oldJumpInput = JumpInput;

			//move by keyboard input
			if(Math.Abs(m_Rigidbody2D.velocity.x) < m_MaxSpeed || Math.Sign(AnalogInputX) != Math.Sign(m_Rigidbody2D.velocity.x) ){
				m_Rigidbody2D.AddForce( new Vector2( AnalogInputX*m_MovementForce , 0f ) );
			}

			// animator
			if (m_Rigidbody2D.velocity.x > 0) {
				m_Anim.Play("RobotWalkRight");
			}
			else if (m_Rigidbody2D.velocity.x < 0) {
				m_Anim.Play("RobotWalkLeft");
			}
			else{
				m_Anim.Play("RobotIdle");
			}


			//Planzen Gießen
			if (CrossPlatformInputManager.GetButton ("Action") && Time.time > nextWater) {
				nextWater = Time.time + fireRate;
				Instantiate(water_prefab, m_Rigidbody2D.position + new Vector2(-0.2f, 0.1f), Quaternion.identity);
			}

		}

    }
}
