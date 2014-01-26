using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	enum FistState
	{
		Idle,
		Smashing,
		Smashed
	}

	public float FallLength;
	public float StaySmashed;

	private float _currentFallLength;
	private FistState _state;
	private Vector2 _fallStartPosition;
	private float _fallSpeed;
	private float _smashedTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (_state)
		{
		case FistState.Idle:
			transform.position = Extensions.To2D(Camera.main.ScreenToWorldPoint(Input.mousePosition));
			if (Input.GetMouseButtonDown(0))
			{
				_currentFallLength = 0;
				_fallSpeed = 4;
				_state = FistState.Smashing;
				_fallStartPosition = transform.position;
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
				_fallSpeed += 100 * Time.deltaTime;
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
		// TODO physics, breakup candy, etc.
	}
}
