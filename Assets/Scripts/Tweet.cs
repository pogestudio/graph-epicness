using UnityEngine;
using System.Collections;

public class Tweet : MonoBehaviour
{

		static double MapPixels = 1024;
		GameObject WorldMap;
		CoordinateCorverter CC;
		CoordinateCorverter.CoordinateXY c;
		TweetData Data;

		double Latitude;
		double Longitude;
		
		float timeLived = 0;
		float lifeSpan = 5f;
		float startOpacity = 0.6f;
		float endOpacity = 0.1f;

		public void Build ()
		{
				this.Latitude = this.Data.coordinate.Longitude;
				this.Longitude = this.Data.coordinate.Latitude;
				WorldMap = GameObject.FindGameObjectWithTag ("Respawn");
				CC = new CoordinateCorverter ();
				c = CC.Convert (Latitude, Longitude);
				PinDot (c);
				this.transform.parent = WorldMap.transform;
				this.transform.localScale = new Vector3 (0.005f, 0.005f, 1f);
		}
		
		public void addData (TweetData data)
		{
				this.Data = data;
		}

		void PinDot (CoordinateCorverter.CoordinateXY xy)
		{
				float x = (float)((xy.x - (MapPixels / 2)) * this.transform.localScale.x * WorldMap.transform.localScale.x + WorldMap.transform.localPosition.x);
				float y = (float)((xy.y - (MapPixels / 2)) * this.transform.localScale.y * WorldMap.transform.localScale.y - WorldMap.transform.localPosition.y);
				this.transform.position = new Vector2 (x, -y);
		}
		
		void Update ()
		{
		
				timeLived += Time.deltaTime;
				SpriteRenderer thisRenderer = gameObject.GetComponent<SpriteRenderer> (); 
				Color oldColor = thisRenderer.color;
				float opacity = opacityForTime (timeLived);
				thisRenderer.color = new Color (oldColor.r, oldColor.g, oldColor.b, opacity);
				
				//Debug.Log ("Opacity " + opacity + " for time" + timeLived);
		}
		
		float opacityForTime (float time)
		{
		
				float c = -0.870551f;
				float progress = Mathf.Min (1, time / lifeSpan);
				return endOpacity + (startOpacity - endOpacity) * (1 - progress);
		}
}