using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

		public GameObject TweetDot;
		public DateTime CurrentTimelineTime;
		private Queue<TweetData> tweetDatasToBeSpawned;
		public ArrayList tweetsFromFile;
		public bool TimelineMoved;
	public TweetFactory TweetFactory;

		public Text currentTimeText;	
		public Text numberOfTweetText;
		private int numberOfTweets = 0;
	private DateTime StartTime;
	private int TimerSeconds;
	

		// Use this for initialization
		void Start ()
		{
//for now, spawner decides when to add stuff.
				tweetDatasToBeSpawned = new Queue<TweetData> ();
				GameObject factoryGO = GameObject.Find ("TweetFactory");
				TweetFactory = factoryGO.GetComponentInChildren<TweetFactory> ();
				tweetsFromFile = TweetFactory.nextTweetDatasForTag ("ebola");
//				foreach (TweetData data in TestTweets) {
//						//tweetDatasToBeSpawned.Enqueue (data);
//				}
			
				numberOfTweetText = GameObject.FindGameObjectWithTag("numberOfTweets").GetComponent<Text>();
				currentTimeText = GameObject.FindGameObjectWithTag("currentTime").GetComponent<Text>();

				TweetData FirstObject = (TweetData)tweetsFromFile [0];
				CurrentTimelineTime = FirstObject.DateTime;
				TimelineMoved = false;
				TimerReset ();
		TimerSeconds = 1;
			
	}
	
		// Update is called once per frame
		void Update ()
		{
				if (TimelineMoved) {
						TimelineMoved = false;
						currentTimeText.text = "" + CurrentTimelineTime.Hour + ":" + CurrentTimelineTime.Minute;
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

				//Add more tweets if their are more within the time.
				//TweetData LastTweet = tweetsFromFile [tweetsFromFile.Count - 1];
				TweetData LastTweet = (TweetData)tweetsFromFile [0];
				if (LastTweet.DateTime < CurrentTimelineTime && TimerDone()) {
						tweetsFromFile = TweetFactory.nextTweetDatasForTag ("ebola");
						foreach (TweetData tweet in tweetsFromFile){
								addTweetDatasToQueue (tweet);
								numberOfTweets++;
						}
				TimerReset();
				}
				numberOfTweetText.text = "" + numberOfTweets;
		}

		//Returns true if more than @TimerSeconds have passed.
		public bool TimerDone(){
			return (DateTime.Now - StartTime).Seconds > TimerSeconds;
		}

		//Sets Timer to current time.
		private void TimerReset(){
			StartTime = DateTime.Now;
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
