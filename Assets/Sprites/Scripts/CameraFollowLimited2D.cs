using UnityEngine;
using System.Collections;

public class CameraFollowLimited2D : MonoBehaviour {
	
	Rigidbody2D m_Rigidbody2D;

	[SerializeField] private Rigidbody2D Target = new Rigidbody2D();
	
	[SerializeField] private float m_MaxX = 1; 
	[SerializeField] private float m_MinX = -1; 
	[SerializeField] private float m_MaxY = 0; 
	[SerializeField] private float m_MinY = 0; 
	
	[SerializeField] private float m_speed = 3; 
	
	// Use this for initialization
	void Start () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update(){

		float limitedX = Target.position.x;
		float limitedY = Target.position.y;
		if(Target.position.x > m_MaxX) limitedX = m_MaxX;
		if(Target.position.x < m_MinX) limitedX = m_MinX;
		if(Target.position.y > m_MaxY) limitedY = m_MaxY;
		if(Target.position.y < m_MinY) limitedY = m_MinY;
		
		Vector2 start = m_Rigidbody2D.transform.position;
		Vector2 end = new Vector2(limitedX,limitedY);

		// camera position moves towards target position:
		m_Rigidbody2D.MovePosition(Vector2.Lerp(start,end,Time.deltaTime*m_speed));

	}
}
