using UnityEngine;
using System.Collections;

public class Snortable : MonoBehaviour {

	public AudioClip SnortedSound;

	public float AddStonedPercent = 10f;

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
		ScoreCounter.Add(Random.Range(25, 40));
		StonedBar.Add(0.01f * AddStonedPercent);
	}

	void StickToSlime()
	{
		_stuckToSlime = true;
		rigidbody2D.isKinematic = true;
		collider2D.enabled = false;
	}
}
