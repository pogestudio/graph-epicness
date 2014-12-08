using UnityEngine;
using System.Collections;

public class TweetFactory : MonoBehaviour
{

		private long nextTweetIndex = 0;
		private long tweetIntervalToUse = 2000;

		// Use this for initialization
		void Start ()
		{
	
		}
		
		public ArrayList nextTweetDatasForTag (string hashTag)
		{
		
				ArrayList JSONInStringFormat = TweetFromFileReader.readJsonFromFile ("Assets/TweetDataInJson/testTweets.json", nextTweetIndex, nextTweetIndex + tweetIntervalToUse);
				nextTweetIndex += tweetIntervalToUse + 1;
				//Debug.Log ("Got " + JSONInStringFormat.Count + " json objects from arrayfromjsonstring");
				ArrayList TweetDatas = tweetsFromJSONData (JSONInStringFormat);
				return TweetDatas;
		}
	
		private ArrayList tweetsFromJSONData (ArrayList JSONData)
		{
				ArrayList TweetDatas = new ArrayList ();
				foreach (string jsonString in JSONData) {
			
						JSONObject jsonData = new JSONObject (jsonString);
//						Debug.Log ("json object for a string");
//						Debug.Log (jsonData);
//						
//						if (jsonData.Count != 13) {
//								Debug.Log ("Bailing out on tweetdata, count: " + jsonData.Count);
//								continue;
//						}
						TweetData tweetD = new TweetData ();
						bool wellFormatted = tweetD.fillTweetWithData (jsonData); 
						if (wellFormatted) {
								TweetDatas.Add (tweetD);
						}
						//Debug.Log ("was well formatted: " + wellFormatted);
				}
				Debug.Log ("Got " + TweetDatas.Count + " tweetdatas after parse");
				return TweetDatas;
		}
		
}
