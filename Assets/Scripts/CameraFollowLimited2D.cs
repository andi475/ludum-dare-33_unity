using UnityEngine;
using System.Collections;

public class CameraFollowLimited2D : MonoBehaviour {
	
	Rigidbody2D m_Rigidbody2D;

	[SerializeField] private Rigidbody2D Target = new Rigidbody2D();
	
	[SerializeField] private float m_MaxX = 9999f; 
	[SerializeField] private float m_MinX = -9999f; 
	[SerializeField] private float m_MaxY = 9999f; 
	[SerializeField] private float m_MinY = -9999f; 
	
	[SerializeField] private float m_OffsetY = -3f; 

	[SerializeField] private float m_speed = 11.475f; 

	Vector2 follow_position;

	// Use this for initialization
	void Start () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update(){
		follow_position = new Vector2 (Target.position.x,Target.position.y+m_OffsetY);
		float limitedX = follow_position.x;
		float limitedY = follow_position.y;
		if(follow_position.x > m_MaxX) limitedX = m_MaxX;
		if(follow_position.x < m_MinX) limitedX = m_MinX;
		if(follow_position.y > m_MaxY) limitedY = m_MaxY;
		if(follow_position.y < m_MinY) limitedY = m_MinY;
		
		Vector2 start = m_Rigidbody2D.transform.position;
		Vector2 end = new Vector2(limitedX,limitedY);

		// camera position moves towards target position:
		m_Rigidbody2D.MovePosition(Vector2.Lerp(start,end,Time.deltaTime*m_speed));

	}
}
