using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;


	
namespace UnityStandardAssets._2D
{
	public class JumpNRunCharacterCustom2D : MonoBehaviour {
		int i;
		RaycastHit2D[] hitInfoArray;

		Vector2 KlickTargetPoint;
		Vector2 DirectionToKlickTargetPoint;
		bool walkingToKlickTarget = false;
		
		float AnalogInputX = 0f;
		bool JumpInput = false;
		bool oldJumpInput = false;

		public float m_MaxSpeed = 10f;
		public float m_JumpForce = 400f;
		public float m_MovementForce = 30f;

		private Animator m_Anim;
		private Rigidbody2D m_Rigidbody2D;

        private void Awake(){
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

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
		}

    }
}
