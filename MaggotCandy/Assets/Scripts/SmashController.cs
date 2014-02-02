using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PushParams
{
	public float SmashPower;
	public Vector2 ImpactPos;
	public float SmashRadius;

	public PushParams (float smashPower, Vector2 impactPos, float smashRadius)
	{
		SmashPower = smashPower;
		ImpactPos = impactPos;
		SmashRadius = smashRadius;
	}
}

public class SmashController : MonoBehaviour {

	enum FistState
	{
		Idle,
		Smashing,
		Smashed
	}

	public float FallLength;
	public float FallSpeed = 100;

	public float StaySmashed;
	public float SmashRadius;
	public float CrushRadius;
	public float SmashPower;

	public List<AudioClip> SmashSounds;

	private float _currentFallLength;
	private FistState _state;
	private float _fallSpeed;
	private float _smashedTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (_state)
		{
		case FistState.Idle:
			transform.position = Extensions.GetMousePosition2D();
			if (Input.GetMouseButtonDown(0))
			{
				_currentFallLength = 0;
				_fallSpeed = 4;
				_state = FistState.Smashing;
			}
			break;
		case FistState.Smashing:
			if (_currentFallLength >= FallLength)
			{
				Smash();
			}
			else
			{
				var tempPos = transform.position;
				var deltaFall = Time.deltaTime * _fallSpeed;
				tempPos.y -= deltaFall;
				_currentFallLength += deltaFall;
				_fallSpeed += FallSpeed * Time.deltaTime;
				transform.position = tempPos;
			}
			break;
		case FistState.Smashed:
			if (_smashedTime >= StaySmashed)
			{
				_state = FistState.Idle;
			}
			else
			{
				_smashedTime += Time.deltaTime;
			}
			break;
		default:
			throw new System.ArgumentOutOfRangeException ();
		}
	}

	void Smash ()
	{
		_state = FistState.Smashed;
		_smashedTime = 0;

		audio.clip = SmashSounds.GetRandomElement();
		audio.Play();

		var smashCollider = this.GetComponent<CircleCollider2D>();

		var impactPos = new Vector2(transform.position.x, transform.position.y) + smashCollider.center;

		var crushColliders = Physics2D.OverlapCircleAll (impactPos, CrushRadius);

		foreach (var crushObject in crushColliders)
		{
			if (crushObject)
			{
				crushObject.SendMessage("Crush", new PushParams(SmashPower, impactPos, SmashRadius), SendMessageOptions.DontRequireReceiver);
			}
		}

		// Applies an explosion force to all nearby rigidbodies
		var repulseColliders = Physics2D.OverlapCircleAll(impactPos, SmashRadius);
		
		foreach (var hitObject in repulseColliders)
		{
			if (hitObject && hitObject.rigidbody2D)
			{
				hitObject.rigidbody2D.AddExplosionForce(SmashPower, impactPos, SmashRadius);
			}
		}
	}
}
