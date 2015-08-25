using UnityEngine;
using System.Collections;
using System;

public class OvenController : MonoBehaviour{
	private bool triggered = false;
	public GameObject[] fire_nozzles;


	private GameObject fire_in_oven;

	private void Awake(){
		fire_in_oven = this.gameObject.transform.Find("fire_in_oven").gameObject;
	}


	private void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player" && !triggered){
			
			other.BroadcastMessage("work", 1f);

			new WaitForSeconds(0.5f);

			fire_in_oven.transform.localScale = new Vector2 (0.4f, 1f);

			fire_nozzles = GameObject.FindGameObjectsWithTag("fire_nozzle");
			
			foreach (GameObject fire_nozzle in fire_nozzles) {
				fire_nozzle.BroadcastMessage("TurnOn");
			}
			triggered = true;
		}
	}
}

