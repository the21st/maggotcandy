﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public List<GameObject> CandyToSpawn;
	public List<GameObject> MaggotsToSpawn;

	public float CandyFallPeriod = 3;
	public float SneezePeriod = 7;

	private float _candyFallTimer;
	private float _sneezeTimer;

	// Use this for initialization
	void Start () {
	
	}

	Vector3 GenerateSpawnPos()
	{
		var boxCollider = GetComponent<BoxCollider2D>();
		var x = Random.Range(-0.5f * boxCollider.size.x, 0.5f * boxCollider.size.x);
		var y = Random.Range(-0.5f * boxCollider.size.y, 0.5f * boxCollider.size.y);
		var position = transform.position + new Vector3(x, y, 0);
		return position;
	}

	void Sneeze()
	{
		audio.Play();

		var position = GenerateSpawnPos();

		Instantiate(MaggotsToSpawn.GetRandomElement(), position, Quaternion.identity);
	}

	void SpawnCandy()
	{
		var position = GenerateSpawnPos();
		
		Instantiate(CandyToSpawn.GetRandomElement(), position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
	{
		_candyFallTimer += Time.deltaTime;
		if (_candyFallTimer > CandyFallPeriod)
		{
			_candyFallTimer = 0;
			SpawnCandy();
		}

		_sneezeTimer += Time.deltaTime;
		if (_sneezeTimer > SneezePeriod)
		{
			_sneezeTimer = 0;
			Sneeze();
		}
	}
}