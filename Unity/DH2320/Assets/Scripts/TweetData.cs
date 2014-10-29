using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class TweetData
{
		public string text;
		public IList<string> hashTags;

		public void fillTweetWithData (JSONObject jsonObject)
		{

				this.text = jsonObject.GetField ("text").ToString ();
				Debug.Log (jsonObject.GetField ("entities").type);
				if (jsonObject.GetField ("entities").type == JSONObject.Type.OBJECT) {
						Debug.Log ("were inside array");
						this.hashTags = new List<string> ();
						JSONObject hashTagList = jsonObject.GetField ("entities").list [0];
						foreach (JSONObject j in hashTagList.list) {
								Debug.Log ("J IS " + j.ToString ());

								this.hashTags.Add (j.GetField ("text").ToString ());
						}
//
//			for(int i = 0; i < jsonObject.GetField("entities").list; i++){
//				string key = (string)obj.keys[i];
//				JSONObject j = (JSONObject)obj.list[i];
//				Debug.Log(key);
//				accessData(j);
//			}
				}


		}
	
		public void printDesc ()
		{
				Debug.Log ("tweet is " + this.text);
				Debug.Log ("hashtag1 is " + this.hashTags [0]);

		}
}
