﻿using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Newtonsoft.Json;

public class Tweet : MonoBehaviour {

	static double MapPixels = 1024;
	GameObject WorldMap;
	CoordinateCorverter CC;
	CoordinateCorverter.CoordinateXY c;

	double Latitude;
    double Longitude;

	// Use this for initialization
	void Start () {

	}

	public void Build(double Latitude, double Longitude){
		this.Latitude = Latitude;
		this.Longitude = Longitude;
		WorldMap = GameObject.FindGameObjectWithTag("Respawn");
		CC = new CoordinateCorverter();
		c = CC.Convert (Latitude, Longitude);
		PinDot(c);
		this.transform.parent = WorldMap.transform;
	}

	void PinDot(CoordinateCorverter.CoordinateXY xy){
		float x = (float)((xy.x - (MapPixels/2))* this.transform.localScale.x * WorldMap.transform.localScale.x);
		float y = (float)((xy.y - (MapPixels/2))* this.transform.localScale.y * WorldMap.transform.localScale.y);
		this.transform.position = new Vector2(x,-y);
	}

    void TryJSON()
    {
        string JSONString = @"{ 'id' : 524850056202321900, 'text' : 'Developed countries, please take note! Cuba sending doctors to Liberia to help fight #ebola #EbolaOutbreak that's solidarity. No quarantine!', 'in_reply_to_status_id' : null, 'in_reply_to_user_id' : null, 'coordinates' : { 'type' : 'Point', 'coordinates' : [  9.756636,  4.083536 ] }, 'place' : { 'place_type' : 'country', 'full_name' : 'Cameroon', 'country' : 'Cameroon', 'bounding_box' : { 'type' : 'Polygon', 'coordinates' : [ 	[ 	[ 	8.4737697, 	1.6525963 ], 	[ 	8.4737697, 	13.0848048 ], 	[ 	16.1912099, 	13.0848048 ], 	[ 	16.1912099, 	1.6525963 ] ] ] } }, 'entities' : { 'hashtags' : [ 	{ 	'text' : 'ebola', 	'indices' : [ 	85, 	91 ] }, 	{ 	'text' : 'EbolaOutbreak', 	'indices' : [ 	92, 	106 ] } ] }, 'favorited' : false, 'retweeted' : false, 'lang' : 'en', 'timestamp_ms' : 1413968979304, 'created_at' : ISODate('2014-10-22T09:09:39.418Z'), '_id' : ObjectId('54477453ea3137aa1a717546') }
";
        TweetData JSONTweet = new TweetData();
        JSONTweet = JsonConvert.DeserializeObject<TweetData>(JSONString);
        print(JSONTweet.getText());
    }
}
