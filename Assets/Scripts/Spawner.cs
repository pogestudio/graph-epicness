using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Spawner : MonoBehaviour
{

		public GameObject TweetDot;
		public DateTime CurrentTimelineTime;
		public DateTime OldTimelineTime;
		private Queue<TweetData> tweetDatasToBeSpawned;
		public ArrayList TestTweets;
		public bool TimelineMoved;
	

		// Use this for initialization
		void Start ()
		{
//for now, spawner decides when to add stuff.
				CurrentTimelineTime = new DateTime (1970, 1, 1, 0, 0, 0, 0).AddSeconds (Math.Round (1413964928192 / 1000d)).ToLocalTime ();	// Based off of test data input - needs to be made generic.
				OldTimelineTime = CurrentTimelineTime;
				TimelineMoved = false;
				tweetDatasToBeSpawned = new Queue<TweetData> ();
				GameObject factoryGO = GameObject.Find ("TweetFactory");
				TweetFactory tweetFactory = factoryGO.GetComponentInChildren<TweetFactory> ();
				this.TestTweets = tweetFactory.testTweetDatas ();
				foreach (TweetData data in TestTweets) {
						//tweetDatasToBeSpawned.Enqueue (data);
				}
				

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (TimelineMoved) {
						foreach (TweetData tweet in TestTweets) {
								if (tweet.DateTime < CurrentTimelineTime && tweet.DateTime > OldTimelineTime) {
										addTweetDatasToQueue (tweet);
								}
						}
						OldTimelineTime = CurrentTimelineTime;
						TimelineMoved = false;
				}
				//for now, always 
				bool shouldSpawnNext = shouldSpawnNextInQueue (this.tweetDatasToBeSpawned);
		
				while (shouldSpawnNext) {
						if (tweetDatasToBeSpawned.Peek () == null) {
								Debug.Log ("null is at heast: " + tweetDatasToBeSpawned.Peek ());
						}
						GameObject tweetGameObject = (GameObject)Instantiate (TweetDot);
						Tweet tweetScriptForObject = tweetGameObject.GetComponentInChildren<Tweet> ();
			
						TweetData nextData = tweetDatasToBeSpawned.Dequeue ();
						tweetScriptForObject.addData (nextData);
						tweetScriptForObject.Build ();
			
						shouldSpawnNext = shouldSpawnNextInQueue (this.tweetDatasToBeSpawned);
				}
		}
	
		private bool shouldSpawnNextInQueue (Queue<TweetData> queue)
		{
				return queue.Count > 0;
		}
		
		public void addTweetDatasToQueue (TweetData dataToAdd)
		{
				this.tweetDatasToBeSpawned.Enqueue (dataToAdd);
		}
}
