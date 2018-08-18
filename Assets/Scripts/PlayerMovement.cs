using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private AudioSource audioSource;

	//walking
	private float moveInput;
	public float walkSpeed;

	//jumping
	private bool isJumping = false;
	private bool isGrounded = false;
	public LayerMask whatIsGround;
	public Transform feetPos;
	public float whiskerLength;
	public float jumpForce;
	public AudioClip jumpAudioClip;
	public AudioClip landAudioClip;
	private bool landed = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		moveInput = Input.GetAxis("Horizontal");

		if (moveInput == 0)
		{
			//stop walking animation
			//animator.SetBool("isWalking", false);
		}
		else
		{
			//start walk animation
			//animator.SetBool("isWalking", true);
			//animator.SetFloat("walkSpeed", moveInput);
		}

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			isJumping = true;
		}
	}

	private void FixedUpdate()
	{
		Debug.DrawRay(feetPos.position, feetPos.right * whiskerLength, Color.magenta);
		isGrounded = Physics2D.Raycast(feetPos.position, feetPos.right, whiskerLength, whatIsGround);
		if (isGrounded && !landed)
		{
			landed = true;
			audioSource.PlayOneShot(landAudioClip);
		}

		if (!isGrounded)
		{
			landed = false;
		}

		rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);

		if (isJumping)
		{
			Vector2 halfwayVector = (new Vector2(rb.velocity.x, 0) + Vector2.up * jumpForce);
			rb.velocity = halfwayVector;
			isJumping = false;
			audioSource.PlayOneShot(jumpAudioClip);
		}
	}
}
