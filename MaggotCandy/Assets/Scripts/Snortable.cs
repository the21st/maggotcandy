using UnityEngine;
using System.Collections;

public class Snortable : MonoBehaviour {

	public AudioClip SnortedSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GetSnorted()
	{
		AudioSource.PlayClipAtPoint (SnortedSound, transform.position);

		Destroy (gameObject);
		ScoreCounter.Add(1);
		StonedBar.Add (0.1f);
	}
}
