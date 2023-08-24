using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 3;
	public float smoothMoveTime = 0.1f;
	public float turnSpeed = 2;
	//public float collisionForce = 5;

	Vector3 velocity;
	Vector3 velocitySmoothV;
	public Vector3 faceDir { get; private set; }
	public Rigidbody rb { get; private set; }
	Vector3 externalForce;

	void Start()
	{
		faceDir = transform.forward;
		rb = GetComponent<Rigidbody>();
	}

/*
	void OnCollisionEnter(Collision collision)
	{
		if (collision.rigidbody != null)
		{
			if (!collision.gameObject.CompareTag("IgnoreForce"))
			{
				collision.rigidbody.AddForce((transform.forward + Vector3.up * 1.25f) * collisionForce, ForceMode.VelocityChange);
			}
		}
	}
*/

	void Update()
	{
		Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
		Vector3 targetVelocity = new Vector3(moveDir.x, 0, moveDir.y) * moveSpeed;

		if (targetVelocity != Vector3.zero)
		{
			faceDir = velocity.normalized;
		}

		velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref velocitySmoothV, smoothMoveTime);
	}

	void FixedUpdate()
	{
		Vector3 newVelocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

		rb.velocity = newVelocity + externalForce;
		externalForce -= Time.fixedDeltaTime * externalForce * 5;

		float angle = Mathf.Atan2(faceDir.x, faceDir.z);
		Quaternion targRot = Quaternion.Euler(Vector3.up * angle * Mathf.Rad2Deg);
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targRot, Time.fixedDeltaTime * turnSpeed));

	}
}
