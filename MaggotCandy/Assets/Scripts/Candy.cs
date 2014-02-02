using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Candy : MonoBehaviour {

	public List<GameObject> CandyPrefabs;

	public List<AudioClip> CrushSounds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//var scale = (10 - transform.position.y) / 10;
		//transform.localScale = new Vector3 (scale, scale, scale);
	}

	void Crush(PushParams pushParams)
	{
		var clip = CrushSounds.GetRandomElement();
		AudioSource.PlayClipAtPoint (clip, transform.position);

		var position = transform.position;
		Destroy (gameObject);
		
		var candyPrefab = CandyPrefabs [Random.Range (0, CandyPrefabs.Count)];
		var posOffset = Random.insideUnitSphere;
		var candy1 = (GameObject) Instantiate(candyPrefab, Extensions.To3D(position + posOffset), Quaternion.identity);
		candy1.rigidbody2D.AddExplosionForce(pushParams.SmashPower, pushParams.ImpactPos, pushParams.SmashRadius);
		candy1.rigidbody2D.AddTorque (Random.Range (-20, 20));
		candy1.collider2D.enabled = true;
		
		
		candyPrefab = CandyPrefabs [Random.Range (0, CandyPrefabs.Count)];
		posOffset = Random.insideUnitSphere;
		var candy2 = (GameObject) Instantiate(candyPrefab, Extensions.To3D(position + posOffset), Quaternion.identity);
		candy2.rigidbody2D.AddExplosionForce(pushParams.SmashPower, pushParams.ImpactPos, pushParams.SmashRadius);
		candy1.rigidbody2D.AddTorque (Random.Range (-10, 10));
		candy2.collider2D.enabled = true;
	}
}
