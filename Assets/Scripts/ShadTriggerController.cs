using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class ShadTriggerController : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
				other.BroadcastMessage("GearUp", "watering_can");

			}
		}

	}
}
