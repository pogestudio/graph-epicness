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

		public void Build ()
		{
				this.Latitude = this.Data.coordinate.Latitude;
				this.Longitude = this.Data.coordinate.Longitude;
				WorldMap = GameObject.FindGameObjectWithTag ("Respawn");
				CC = new CoordinateCorverter ();
				c = CC.Convert (Latitude, Longitude);
				PinDot (c);
				this.transform.parent = WorldMap.transform;
		}
		
		public void addData (TweetData data)
		{
				this.Data = data;
		}

		void PinDot (CoordinateCorverter.CoordinateXY xy)
		{
				float x = (float)((xy.x - (MapPixels / 2)) * this.transform.localScale.x * WorldMap.transform.localScale.x);
				float y = (float)((xy.y - (MapPixels / 2)) * this.transform.localScale.y * WorldMap.transform.localScale.y);
				this.transform.position = new Vector2 (x, -y);
		}
}