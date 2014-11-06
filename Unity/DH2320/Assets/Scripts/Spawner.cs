using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{

		public GameObject TweetDot;
	
		private Queue<TweetData> tweetDatasToBeSpawned;
	
	

		// Use this for initialization
		void Start ()
		{
//for now, spawner decides when to add stuff.
				tweetDatasToBeSpawned = new Queue<TweetData> ();
				GameObject factoryGO = GameObject.Find ("TweetFactory");
				TweetFactory tweetFactory = factoryGO.GetComponentInChildren<TweetFactory> ();
				ArrayList testTweets = tweetFactory.testTweetDatas ();
				foreach (TweetData data in testTweets) {
						tweetDatasToBeSpawned.Enqueue (data);
				}

		}
	
		// Update is called once per frame
		void Update ()
		{
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
