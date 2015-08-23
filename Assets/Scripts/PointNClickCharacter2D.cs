using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

namespace UnityStandardAssets._2D
{
	public class PointNClickCharacter2D : MonoBehaviour {
		int i;
		RaycastHit2D[] hitInfoArray;
		
		Vector2 KlickTargetPoint;
		Vector2 DirectionToKlickTargetPoint;
		bool walkingToKlickTarget = false;
		
		float AnalogInX = 0f;
		float AnalogInY = 0f;

        public float m_MaxSpeed = 10f;

		private Animator m_Anim;
		private Rigidbody2D m_Rigidbody2D;
		private CircleCollider2D m_CircleCollider2D;

        private void Awake(){
            m_Anim = GetComponent<Animator>();
			m_CircleCollider2D = GetComponent<CircleCollider2D>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

		private void Update(){
			if(Input.GetMouseButtonDown(0)){
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				hitInfoArray = Physics2D.RaycastAll (ray.origin, ray.direction);
				for(i=0;i<hitInfoArray.Length;i++){
					Debug.Log("hit: " + hitInfoArray[i].collider.ToString() + " at " + hitInfoArray[i].point.x +","+ hitInfoArray[i].point.y);

					KlickTargetPoint = hitInfoArray[i].point;
					walkingToKlickTarget = true;
				}
			}

			Vector2 CharacterPosition = m_Rigidbody2D.position+m_CircleCollider2D.offset;

			AnalogInX = CrossPlatformInputManager.GetAxis("Horizontal");
			AnalogInY = CrossPlatformInputManager.GetAxis("Vertical");

			if(AnalogInX != 0 || AnalogInY != 0){
				walkingToKlickTarget = false;
			}
			if( Vector2.Distance(CharacterPosition,KlickTargetPoint) < 0.2 ){
				walkingToKlickTarget = false;
			}

			if (walkingToKlickTarget) {
				//move towards klick target point
				DirectionToKlickTargetPoint = (KlickTargetPoint - CharacterPosition).normalized;
				m_Rigidbody2D.velocity = DirectionToKlickTargetPoint*m_MaxSpeed;
			}
			else{
				//move by keyboard input
				m_Rigidbody2D.velocity = new Vector2(AnalogInX*m_MaxSpeed, AnalogInY*m_MaxSpeed*0.7f);
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
