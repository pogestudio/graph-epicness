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



		public void fillTweetWithData (JSONObject jsonObject)
		{

				this.text = jsonObject.GetField ("text").ToString ();
				Debug.Log (jsonObject.GetField ("entities").type);
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


		}
	
		public void printDesc ()
		{
				Debug.Log ("tweet is " + this.text);
				Debug.Log ("hashtag1 is " + this.hashTags [0]);
				Debug.Log ("coordinates are:::: " + this.coordinate.Latitude + "  " + this.coordinate.Longitude);

		}
}