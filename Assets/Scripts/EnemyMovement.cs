using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D rb;
	public float walkSpeed;
	private bool isGrounded = false;
	public LayerMask whatIsGround;
	public Transform feetPos;
	public float whiskerLength;
	private bool landed = false;
	//private AudioSource source;
	//public AudioClip landAudioClip;
	private Transform target;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindGameObjectWithTag("Target").transform;
		//source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		Debug.DrawRay(feetPos.position, feetPos.right * whiskerLength, Color.magenta);
		isGrounded = Physics2D.OverlapCircle(feetPos.position, whiskerLength, whatIsGround);
		if (isGrounded && !landed)
		{
			landed = true;
			//source.PlayOneShot(landAudioClip);
		}

		if (!isGrounded)
		{
			landed = false;
		}

		float moveInput = 0;
		if (transform.position.x <= target.position.x)
		{
			moveInput = 1;
		}
		else
		{
			moveInput = -1;
		}

		if (isGrounded)
		{
			rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
		}		
	}
}
