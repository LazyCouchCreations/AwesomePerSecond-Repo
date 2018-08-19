using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private AudioSource audioSource;
	private Animator anim;

	//facing
	private Vector2 worldMousePos;
	private Vector2 myFlatTransform;

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
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		myFlatTransform = new Vector2(transform.position.x, transform.position.y);

		moveInput = Input.GetAxis("Horizontal");

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			isJumping = true;
		}
	}

	private void FixedUpdate()
	{
		if (worldMousePos.x > myFlatTransform.x)
		{
			//look right
			transform.localScale = new Vector3(1.5f, 1.5f, 1);
		}
		else if (worldMousePos.x < myFlatTransform.x)
		{
			//look left
			transform.localScale = new Vector3(-1.5f, 1.5f, 1);
		}

		Debug.DrawRay(feetPos.position, feetPos.right * whiskerLength, Color.magenta);
		isGrounded = Physics2D.OverlapCircle(feetPos.position, whiskerLength, whatIsGround);
		anim.SetBool("isGrounded", isGrounded);

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
		anim.SetFloat("Speed", Mathf.Abs(moveInput));

		if (isJumping)
		{
			Vector2 halfwayVector = (new Vector2(rb.velocity.x, 0) + Vector2.up * jumpForce);
			rb.velocity = halfwayVector;
			isJumping = false;
			audioSource.PlayOneShot(jumpAudioClip);
		}

		anim.SetFloat("vSpeed", rb.velocity.y);
	}
}
