using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{
		public Spawner Spawner;
	private DateTime StartTime;
	private int TimerSeconds;

		// Use this for initialization
		void Start ()
		{
		StartTime = DateTime.Now;
		TimerSeconds = 1;
		}

		// Update is called once per frame
		void Update ()
		{
				float h = Input.GetAxis ("Horizontal");
				float i = Input.GetAxis ("Vertical");

				float x = this.transform.position.x;
				float y = this.transform.position.y;

				// Minus för att vi flyttar kartan, inte kameran
				this.transform.position = new Vector2 (x - (h * 0.2f), y - (i * 0.2f));

				if (Input.GetKey ("x")) {
						float s = 0.01f;

						x = this.transform.localScale.x;
						y = this.transform.localScale.y;
						this.transform.localScale = new Vector2 (x + s, y + s);
				}
				if (Input.GetKey ("z")) {
						float s = 0.01f;

						x = this.transform.localScale.x;
						y = this.transform.localScale.y;
						this.transform.localScale = new Vector2 (x - s, y - s);
				}
				if (Input.GetKeyDown ("c")) {
				}
				if (Input.GetKeyDown ("v")) {
				}
				if (TimerDone()) {
					Spawner.CurrentTimelineTime += 1;
					Spawner.TimelineMoved = true;
					TimerReset();
				}
		}

	public bool TimerDone ()
	{
		return (DateTime.Now - StartTime).Seconds > TimerSeconds;
	}

	private void TimerReset ()
	{
		StartTime = DateTime.Now;
	}
}
