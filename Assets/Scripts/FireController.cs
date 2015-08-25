using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
	
	
	private Rigidbody2D m_Rigidbody2D;
	private void Awake(){
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
		transform.Rotate(Vector3.forward * 120 * Time.deltaTime);
	}
}
