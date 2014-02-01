using UnityEngine;
using System.Collections;

public class Snortable : MonoBehaviour {

	public ScoreCounter Score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GetSnorted()
	{
		Destroy (gameObject);
		ScoreCounter.Add(1);
		StonedBar.Add (0.1f);
	}
}
