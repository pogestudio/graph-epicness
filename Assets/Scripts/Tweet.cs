using UnityEngine;
using System.Collections;

public class Tweet : MonoBehaviour
{

		static double MapPixels = 4096;
		GameObject WorldMap;
		CoordinateCorverter CC;
		CoordinateCorverter.CoordinateXY c;
		TweetData Data;

		double Latitude;
		double Longitude;
		
		float timeLived = 0;
		float lifeSpan = 5f;
		float startOpacity = 0.6f;
		float endOpacity = 0.2f;

		public void Build ()
		{
				this.Latitude = this.Data.coordinate.Longitude;
				this.Longitude = this.Data.coordinate.Latitude;
				WorldMap = GameObject.FindGameObjectWithTag ("Respawn");
				CC = new CoordinateCorverter ();
				c = CC.Convert (Latitude, Longitude);
				PinDot (c);
				this.transform.parent = WorldMap.transform;
				this.transform.localScale = new Vector3 (0.05f, 0.05f, 1f);
		}
		
		public void addData (TweetData data)
		{
				this.Data = data;
		}

		public void OnMouseDown ()
		{
				Debug.Log (Data.text);
		}

		void PinDot (CoordinateCorverter.CoordinateXY xy)
		{
				SpriteRenderer thisRenderer = gameObject.GetComponent<SpriteRenderer> (); 
				//thisRenderer.color = new Color (1f, 0.92f, 0.016f);
				thisRenderer.color = new Color (0.92f, 0f, 0.016f);
				float x = (float)((xy.x - (MapPixels / 2)) * this.transform.localScale.x * WorldMap.transform.localScale.x + WorldMap.transform.localPosition.x);
				float y = (float)((xy.y - (MapPixels / 2)) * this.transform.localScale.y * WorldMap.transform.localScale.y - WorldMap.transform.localPosition.y);
				this.transform.position = new Vector2 (x, -y);
		}
		
		void Update ()
		{
		
				timeLived += Time.deltaTime;
				SpriteRenderer thisRenderer = gameObject.GetComponent<SpriteRenderer> (); 
				//Color oldColor = thisRenderer.color;
				float opacity = opacityForTime (timeLived);
				float green = ColorForTime (timeLived);
				thisRenderer.color = new Color (1f, green, 0.016f, opacity);
				this.transform.localScale = ScaleForTime (timeLived);
				
				
				//Debug.Log ("Opacity " + opacity + " for time" + timeLived);
		}
		
		float opacityForTime (float time)
		{
		
				float c = -0.870551f;
				float progress = Mathf.Min (1, time / lifeSpan);
				return endOpacity + (startOpacity - endOpacity) * (1 - progress);
		}

		float ColorForTime (float time)
		{
				//float progress = Mathf.Max (0.016f, (1 - time / lifeSpan));
				float progress = Mathf.Min (0.92f, time / lifeSpan);
				//Debug.Log (progress);
				return progress;
		}

		Vector3 ScaleForTime (float time)
		{
				float progress = Mathf.Max (0.25f, lifeSpan / time);
				Vector3 vector = new Vector3 (0.05f * progress, 0.05f * progress, 1f);
				return vector;
		}
}