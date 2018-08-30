using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
	[HideInInspector] public Transform checkpoint;  // Last checkpoint transform
	[HideInInspector] public bool CanMove = true;

	public GameObject bulletPrefab;           // Bullet to shoot
	public Camera cam;                  // Player camera
	public float gravity;               // Gravity value
	public int jumpFrames;              // Duration of a jump (frames)
	public float jumpSpeed;             // Speed of jump
	public float moveSpeed;             // Speed of normal movements
	public float bulletSpeed = 50f;

	// Keywords for key-pressed input
	string getX;
	string getY;
	string getZ;

	// Movement controllers and modifiers
	CharacterController controller;
	Vector3 move = Vector3.zero;
	Vector3 rotate = Vector3.zero;
	int cont = 0;

	[SerializeField] MouseLook mouseLook;   // Mouse controller -- combines movements of player and camera

	void Start ()
	{
		controller = GetComponent<CharacterController> ();
		mouseLook.Init (transform, cam.transform);

		getX = "Horizontal-" + name;
		getY = "Jump-" + name;
		getZ = "Vertical-" + name;
	}

	// Update position and rotation
	void FixedUpdate ()
	{
		if (CanMove)
		{
			controller.Move((transform.forward * move.z + transform.right * move.x + transform.up * move.y) * Time.deltaTime);
			controller.transform.Rotate(rotate * Time.deltaTime); 
		}

		if (controller.transform.position.y <= -37)
			Respawn ();
	}

	void Update ()
	{
		if (CanMove)
		{
			//Keyboard input
			move.x = Input.GetAxis(getX) * moveSpeed;
			move.z = Input.GetAxis(getZ) * moveSpeed;

			CheckForJump();

			//Mouse input throw MouseLook
			mouseLook.LookRotation(transform, cam.transform);

			if (Input.GetButton("Fire1"))
				Fire();

			if (Input.GetButtonDown("Fire2"))
				Zoom();

			if (Input.GetButtonUp("Fire2"))
				UnZoom(); 
		}
	}

	void CheckForJump ()
	{
		if (cont != 0)
			cont--;

		else if (controller.isGrounded)
		{
			// Check for jump input
			if (Input.GetButton (getY))
			{
				cont = jumpFrames;
				move.y = jumpSpeed;
			}

			else
				move.y = 0;
		}

		else
			move.y = -gravity;

	}

	void Fire ()
	{
		GameObject bullet = Instantiate (bulletPrefab, cam.ScreenToWorldPoint (new Vector3 (Screen.width / 2, Screen.height / 2, cam.nearClipPlane + 3)), cam.transform.rotation);
		bullet.GetComponent<Rigidbody> ().velocity = bullet.GetComponent<Rigidbody> ().transform.forward * bulletSpeed;
	}

	void Zoom ()
	{
		cam.fieldOfView /= 2;
	}

	void UnZoom ()
	{
		cam.fieldOfView *= 2;
	}

	public void Respawn ()
	{
		transform.position = checkpoint.position;
		transform.rotation = checkpoint.rotation;
	}
}