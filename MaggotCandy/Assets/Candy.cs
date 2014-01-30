using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {

	public GameObject CandyPrefab;

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
		var position = transform.position;
		Destroy (gameObject);

		var posOffset = Random.insideUnitSphere;

		var candy1 = (GameObject) Instantiate(CandyPrefab, Extensions.To2D(position + posOffset), Quaternion.identity);
		candy1.rigidbody2D.AddExplosionForce(pushParams.SmashPower, pushParams.ImpactPos, pushParams.SmashRadius);
		candy1.collider2D.enabled = true;
		
		posOffset = Random.insideUnitSphere;

		var candy2 = (GameObject) Instantiate(CandyPrefab, Extensions.To2D(position + posOffset), Quaternion.identity);
		candy2.rigidbody2D.AddExplosionForce(pushParams.SmashPower, pushParams.ImpactPos, pushParams.SmashRadius);
		candy2.collider2D.enabled = true;
	}
}
