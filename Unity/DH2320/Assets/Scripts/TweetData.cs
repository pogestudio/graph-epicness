using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class TweetData
{
		public struct CoordinateLL
		{
				public double Latitude;
				public double Longitude;
		}

		public string text;
		public CoordinateLL coordinate;
		public IList<string> hashTags;
		
		private bool _isWFormatted;



		public bool fillTweetWithData (JSONObject jsonObject)
		{
				_isWFormatted = true;
				_isWFormatted = _isWFormatted && jsonObject.GetField ("text").type == JSONObject.Type.STRING;
				if (!_isWFormatted) {
						return _isWFormatted;
				}
				this.text = jsonObject.GetField ("text").ToString ();
				Debug.Log ("type is: " + jsonObject.GetField ("text").type + " text is : " + this.text);
		
				Debug.Log (this.text);
				//Debug.Log (jsonObject.GetField ("entities").type);
				if (jsonObject.GetField ("coordinates").type == JSONObject.Type.OBJECT) {
						//Debug.Log ("jsonobject isS " + jsonObject.GetField ("coordinates").list [1]);

						this.coordinate = new CoordinateLL ();
						JSONObject list = jsonObject.GetField ("coordinates").list [1];
						//Debug.Log ("list isss. " + list);
						this.coordinate.Latitude = Convert.ToDouble (list [0].ToString ());
						//Debug.Log (list);
						this.coordinate.Longitude = Convert.ToDouble (list [1].ToString ());
						//Debug.Log ("coordinates:::: " + this.coordinate.Latitude + "  " + this.coordinate.Longitude);
				}
				if (jsonObject.GetField ("entities").type == JSONObject.Type.OBJECT) {
						this.hashTags = new List<string> ();
						JSONObject hashTagList = jsonObject.GetField ("entities").list [0];
						foreach (JSONObject j in hashTagList.list) {
								//Debug.Log ("J IS " + j.ToString ());
								this.hashTags.Add (j.GetField ("text").ToString ());
						}
				}
				
				return _isWFormatted;

		}
	
		public void printDesc ()
		{
				Debug.Log ("DESCRIPTION\n  TWEET " + this.text);
				Debug.Log ("  HASHTAGS");
				int index = 0;
				foreach (string hashtag in this.hashTags) {
						Debug.Log ("    " + index++ + " " + hashtag);
				}
		
				Debug.Log ("  COORDINATES\n    LAT: " + this.coordinate.Latitude);
				Debug.Log ("    LON: " + this.coordinate.Longitude);
		}
		
	
}