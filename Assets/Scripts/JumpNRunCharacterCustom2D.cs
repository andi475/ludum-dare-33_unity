using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;


	
namespace UnityStandardAssets._2D
{
	public class JumpNRunCharacterCustom2D : MonoBehaviour {
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
		
		public GameObject water_prefab;
		public string m_active_gear_name;

		private GameObject watering_can;

		private Animator m_Anim;
		private Rigidbody2D m_Rigidbody2D;
        private void Awake(){
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
			watering_can = this.gameObject.transform.Find("watering_can").gameObject;
        }

		
		public void GearUp(string gear_name){
			if(gear_name=="watering_can"){
				m_active_gear_name="watering_can";
			}
		}
		public void work(float work_time){
			work_end_time = Time.time + work_time;
			m_Rigidbody2D.velocity = new Vector2 (0, 0);
		}
		
		
		
		private void Update(){


			AnalogInputX = CrossPlatformInputManager.GetAxis("Horizontal");
			JumpInput = CrossPlatformInputManager.GetButton("Jump") || CrossPlatformInputManager.GetAxis("Vertical")>0;

			if (Time.time > work_end_time) {

				//jumping
				if (!oldJumpInput && JumpInput) {
					m_Rigidbody2D.AddForce (new Vector2 (0f, m_JumpForce));
				}
				oldJumpInput = JumpInput;

				//move by keyboard input
				if (Math.Abs (m_Rigidbody2D.velocity.x) < m_MaxSpeed || Math.Sign (AnalogInputX) != Math.Sign (m_Rigidbody2D.velocity.x)) {
					m_Rigidbody2D.AddForce (new Vector2 (AnalogInputX * m_MovementForce, 0f));
				}

				// animator
				if (m_Rigidbody2D.velocity.x > 0) {
					m_Anim.Play ("RobotWalkRight");
				} else if (m_Rigidbody2D.velocity.x < 0) {
					m_Anim.Play ("RobotWalkLeft");
				} else {
					m_Anim.Play ("RobotIdle");
				}
			
			} else {
				m_Anim.Play ("work");
			}


			//Planzen Gießen
			if (m_active_gear_name == "watering_can") {

				float water_offset = -0.2f;
				if (m_Rigidbody2D.velocity.x > 0.1) {
					water_offset = 0.2f;
					watering_can.transform.localScale = new Vector2 (-1, 1);
				} else {
					water_offset = -0.2f;
					watering_can.transform.localScale = new Vector2 (1, 1);
				}
				if (CrossPlatformInputManager.GetButton ("Action") && Time.time > nextWater) {
					nextWater = Time.time + fireRate;
					Instantiate (water_prefab, m_Rigidbody2D.position + new Vector2 (water_offset, 0.1f), Quaternion.identity);
				}
			} else {
				watering_can.transform.localScale = new Vector2 (0, 0);
			}
		}

    }
}
