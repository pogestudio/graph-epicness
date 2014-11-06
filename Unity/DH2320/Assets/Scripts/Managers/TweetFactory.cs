using UnityEngine;
using System.Collections;

public class TweetFactory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		printOneData();
	}

	public void printOneData() {
		TweetData data = DataFromJson();
		data.printDesc();
	}
	public TweetData DataFromJson()
	{
		string Description  = "{ \"id\" : 524850056202321900, \"text\" : \"Developed countries, please take note! Cuba sending doctors to Liberia to help fight #ebola #EbolaOutbreak thats solidarity. No quarantine!\", \"in_reply_to_status_id\" : \"\", \"in_reply_to_user_id\" : \"\", \"coordinates\" : { \"type\" : \"Point\", \"coordinates\" : [  9.756636,  4.083536 ] }, \"place\" : { \"place_type\" : \"country\", \"full_name\" : \"Cameroon\", \"country\" : \"Cameroon\", \"bounding_box\" : { \"type\" : \"Polygon\", \"coordinates\" : [ 	[ 	[ 	8.4737697, 	1.6525963 ], 	[ 	8.4737697, 	13.0848048 ], 	[ 	16.1912099, 	13.0848048 ], 	[ 	16.1912099, 	1.6525963 ] ] ] } }, \"entities\" : { \"hashtags\" : [ 	{ 	\"text\" : \"ebola\", 	\"indices\" : [ 	85, 	91 ] }, 	{ 	\"text\" : \"EbolaOutbreak\", 	\"indices\" : [ 	92, 	106 ] } ] }, \"favorited\" : false, \"retweeted\" : false, \"lang\" : \"en\", \"timestamp_ms\" : 1413968979304}";
				JSONObject j = new JSONObject(Description);

		TweetData data = new TweetData();

		data.fillTweetWithData(j);
		return data;
	}
}
