using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllerFootboard : MonoBehaviour
{
	public enum MovementDirection
	{
		Vertical,
		Forward,
		Right
	}

	public MovementDirection direction;
	public float minPosition;
	public float maxPosition;
	public float speed = .5f;

	Vector3 move = Vector3.zero;

	void Start()
	{
		move = AssignMovement() * speed;
	}

	void FixedUpdate()
	{
		move *= ContinueMovement(transform.position);
		transform.position += move;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
			other.transform.parent = transform;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
			other.transform.parent = null;
	}

	Vector3 AssignMovement()
	{
		switch (direction)
		{
			case MovementDirection.Forward:
				return Vector3.forward;

			case MovementDirection.Right:
				return Vector3.right;

			case MovementDirection.Vertical:
				return Vector3.up;

			default:
				return Vector3.zero;
		}
	}

	float ContinueMovement(Vector3 position)
	{
		switch (direction)
		{
			case MovementDirection.Forward:

				return (position.z <= minPosition || position.z >= maxPosition)
					? -1
					: 1;

			case MovementDirection.Right:

				return (position.x <= minPosition || position.x >= maxPosition)
					? -1
					: 1;

			case MovementDirection.Vertical:
				
				return (position.y <= minPosition || position.y >= maxPosition)
					? -1
					: 1;

			default:
				return 0;
		}
	}
}
