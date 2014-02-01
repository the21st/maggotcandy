using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maggot : MonoBehaviour
{
	public GameObject CrushedMaggot;
	public List<AudioClip> SquashSounds;

	private float _movementSpeed;
	private float _rotationSpeed;

	// Use this for initialization
	void Start()
	{
		transform.localRotation = Quaternion.AngleAxis (Random.Range (0, 360f), new Vector3 (0, 0, 1));
		_movementSpeed = Random.Range(0.1f, 0.5f);
		_rotationSpeed = Random.Range(-0.2f, 0.2f);
	}
    
	// Update is called once per frame
	void Update()
	{
		var direction = this.transform.right;

		if (Vector3.Dot(transform.up, Vector3.up) < 0)
		{
			transform.localScale = new Vector3(1, -1, 1);
		} else
		{
			transform.localScale = new Vector3(1, 1, 1);
		}

		transform.position += _movementSpeed * Time.deltaTime * direction;

		transform.Rotate(new Vector3(0, 0, 1), _rotationSpeed);
	}
	
	void Fall(int layerOrder)
	{
		enabled = false;
	}

	void Crush(PushParams pushParams)
	{
		AudioSource.PlayClipAtPoint(SquashSounds.GetRandomElement(), transform.position);

		Instantiate(CrushedMaggot, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
