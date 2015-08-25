using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
		public class LevelChanger : MonoBehaviour {

		public string name;

			private void OnTriggerEnter2D(Collider2D other)
			{
				if (other.tag == "Player")
				{
				Application.LoadLevel(name);
				}
			}
		}
	}
