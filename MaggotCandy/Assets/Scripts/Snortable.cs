using UnityEngine;
using System.Collections;

public class Snortable : MonoBehaviour {

	public AudioClip SnortedSound;

	private bool _stuckToSlime = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GetSnorted()
	{
		if (_stuckToSlime)
		{
			return;
		}

		AudioSource.PlayClipAtPoint (SnortedSound, transform.position);

		Destroy (gameObject);
		ScoreCounter.Add(1);
		StonedBar.Add (0.1f);
	}

	void StickToSlime()
	{
		_stuckToSlime = true;
		rigidbody2D.isKinematic = true;
		collider2D.enabled = false;
	}
}
