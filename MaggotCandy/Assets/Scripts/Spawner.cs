using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
	public GameObject FallingObject;

	public AudioClip MaggotSpawnSound;
	public AudioClip CandySpawnSound;

	public List<Color> CandyColors;

	public List<GameObject> CandyToSpawn;
	public List<GameObject> MaggotsToSpawn;
	public float CandyFallPeriod = 3;
	public float SneezePeriod = 7;
	private float _candyFallTimer;
	private float _sneezeTimer;

	// Use this for initialization
	void Start()
	{
	}

	Vector2 GenerateSpawnPos()
	{
		var boxCollider = GetComponent<BoxCollider2D>();
		var x = Random.Range(-0.5f * boxCollider.size.x, 0.5f * boxCollider.size.x);
		var y = Random.Range(-0.5f * boxCollider.size.y, 0.5f * boxCollider.size.y);
		var position = transform.position.To2D() + new Vector2(x, y);
		return position;
	}

	void Sneeze()
	{
		audio.clip = MaggotSpawnSound;
		audio.Play();

		var position = GenerateSpawnPos();

		var fallingObject = (GameObject) Instantiate(FallingObject);
		var fallingScript = fallingObject.GetComponent<FallingSpawner>();
		fallingScript.PrefabToCreate = MaggotsToSpawn.GetRandomElement();
		fallingScript.Target = position;
	}

	public void SpawnCandy(bool sound)
	{
		if (sound)
		{
			audio.clip = CandySpawnSound;
			audio.Play();
		}

		var position = GenerateSpawnPos();

		var fallingObject = (GameObject) Instantiate(FallingObject);
		fallingObject.GetComponent<SpriteRenderer>().color = CandyColors.GetRandomElement();
		var fallingScript = fallingObject.GetComponent<FallingSpawner>();
		fallingScript.PrefabToCreate = CandyToSpawn.GetRandomElement();
		fallingScript.Target = position;
	}
	
	// Update is called once per frame
	void Update()
	{
		_candyFallTimer += Time.deltaTime;
		if (_candyFallTimer > CandyFallPeriod)
		{
			_candyFallTimer = 0;
			SpawnCandy(true);
		}

		_sneezeTimer += Time.deltaTime;
		if (_sneezeTimer > SneezePeriod)
		{
			_sneezeTimer = 0;
			Sneeze();
		}
	}
}
