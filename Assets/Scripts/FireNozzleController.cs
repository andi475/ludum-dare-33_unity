using UnityEngine;
using System.Collections;

public class FireNozzleController : MonoBehaviour {
	
	public GameObject fire_prefab;

	private Rigidbody2D m_Rigidbody2D;
	private void Awake(){
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void TurnOn(){
		Instantiate(fire_prefab, m_Rigidbody2D.position + new Vector2(0f,0f), Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
