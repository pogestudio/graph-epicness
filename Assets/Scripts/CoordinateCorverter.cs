using UnityEngine;
using System.Collections;
using System;

public class CoordinateCorverter : MonoBehaviour
{

		static double MapPixels = 4096;
		static double EarthRadius = 6378137;
		static double MinLatitude = -85.05112878;
		static double MaxLatitude = 85.05112878;
		static double MinLongitude = -180;
		static double MaxLongitude = 180;
	
		public struct CoordinateXY
		{
				public double x, y;
		}

		// Convert degree latitude/longitude to xy-pixels
		public CoordinateXY Convert (double latitude, double longitude)
		{
				CoordinateXY c;
				c.x = (longitude + 180) / 360 * MapPixels; 
				double sinLatitude = Math.Sin (latitude * Math.PI / 180);
				c.y = (0.5 - Math.Log ((1 + sinLatitude) / (1 - sinLatitude)) / (4 * Math.PI)) * MapPixels;
				return c;
		}
}
