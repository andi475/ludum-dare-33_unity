using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;


	
namespace UnityStandardAssets._2D
{
	public class JumpNRunCharacterCustom2D : MonoBehaviour {
		int i;

		string gui_massage = "";

		float work_end_time = 0f;
		
		float AnalogInputX = 0f;
		float oldAnalogInputX = 0f;
		bool JumpInput = false;
		bool oldJumpInput = false;

		bool grounded = false;

		public float m_StartSpeed = 1f;
		public float m_MaxSpeed = 10f;
		public float m_JumpForce = 400f;
		public float m_MovementForce = 30f;
		
		public float fireRate = 0.009f;
		private float nextWater = 0.0f;
		
		public GameObject water_prefab;
		public string m_active_gear_name;
		private GameObject ground_check;
		private GameObject watering_can;

		private Animator m_Anim;
		private Rigidbody2D m_Rigidbody2D;
		private Collider2D m_Collider2D;
        private void Awake(){
			m_Anim = GetComponent<Animator>();
			m_Rigidbody2D = GetComponent<Rigidbody2D>();
			m_Collider2D = GetComponent<Collider2D>();
			ground_check = this.gameObject.transform.Find("ground_check").gameObject;
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

			grounded = ground_check.GetComponent<Collider2D>().IsTouchingLayers();

			if (Time.time > work_end_time) {

				//jumping
				if (!oldJumpInput && JumpInput && grounded) {
					m_Rigidbody2D.AddForce (new Vector2 (0f, m_JumpForce));
				}
				oldJumpInput = JumpInput;

				//bremsen
				if(AnalogInputX==0 && grounded){
					m_Rigidbody2D.velocity=new Vector2(m_Rigidbody2D.velocity.x*0.75f,m_Rigidbody2D.velocity.y);
				}

				//move by keyboard input
					//startgeschwindigkeit setzten
				if ( ( (AnalogInputX > 0.1 && oldAnalogInputX < 0.1) || (AnalogInputX < -0.1 && oldAnalogInputX > -0.1) ) && grounded ) {
					m_Rigidbody2D.velocity = new Vector2 (m_StartSpeed*Math.Sign(AnalogInputX), m_Rigidbody2D.velocity.y);
				}
				oldAnalogInputX=AnalogInputX;

					//kraft hinzufügen
				m_Rigidbody2D.AddForce (new Vector2 (AnalogInputX * m_MovementForce, 0f));

					//geschwindigkeit begrenzen
				if(Math.Abs(m_Rigidbody2D.velocity.x)>m_MaxSpeed){
					m_Rigidbody2D.velocity=new Vector2(m_MaxSpeed*Math.Sign(m_Rigidbody2D.velocity.x),m_Rigidbody2D.velocity.y);
				}

				// animator
				if (m_Rigidbody2D.velocity.x > 0) {
					if(grounded){
						m_Anim.Play ("RobotWalkRight");
					}else{
						m_Anim.Play ("AirRight");
					}
				} else if (m_Rigidbody2D.velocity.x < 0) {
					if(grounded){
						m_Anim.Play ("RobotWalkLeft");
					}else{
						m_Anim.Play ("AirLeft");
					}
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
					Instantiate (water_prefab, m_Rigidbody2D.position + new Vector2 (water_offset, 0.2f), Quaternion.identity);
				}
			} else {
				watering_can.transform.localScale = new Vector2 (0, 0);
			}
		}
		
		void OnGUI() {
			if(gui_massage.Length>0){
				GUI.color = Color.white;
				GUI.Box(new Rect(10, 10, 100, 20), gui_massage);
			}
		}
    }


}
