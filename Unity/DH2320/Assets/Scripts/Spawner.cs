using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Dot;

	// Use this for initialization
	void Start () {
		GameObject o = (GameObject)Instantiate(Dot);
		o.GetComponentInChildren<Tweet>().Build(35.21,53.22);
		o = (GameObject)Instantiate(Dot);
		o.GetComponentInChildren<Tweet>().Build(21.21,43.22);
		o = (GameObject)Instantiate(Dot);
		o.GetComponentInChildren<Tweet>().Build(-31.21,-21.22);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
