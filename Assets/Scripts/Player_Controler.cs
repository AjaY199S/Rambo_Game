using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Controler : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb;
	public Text Scoretext;
	public Text Healthtext;
	public Text Scoretext1;
	public Text Healthtext1;
	public Text Scoretext2;
	public Text Healthtext2;
	public GameObject current;
	public GameObject next;
	public GameObject win;

	public int Score = 0;

	[SerializeField]
	private float mspeed;

	[SerializeField]
	private Transform[] groundponts;

	[SerializeField]
	private float groundradiuos;

	[SerializeField]
	private LayerMask whatIsground;

	private bool Isgrounded;

	[SerializeField]
	private float jumpfroce;

	private bool jump;

	public int health = 5;
	private bool Dead_Is;

	private bool facingRight;
	// Use this for initialization
	void Start () {
		facingRight = true;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		if (Dead_Is == false) {
			HandelInput ();
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Dead_Is == false) {

			Isgrounded = Isgrounded1 ();
			float horizontal = Input.GetAxis ("Horizontal");
			HandelMovemenet (horizontal);
			Flip (horizontal);
			ResetValues ();
		}
	}

	private void HandelMovemenet(float horizontal)
	{
		rb.velocity = new Vector2 (horizontal * mspeed, rb.velocity.y);
		anim.SetFloat ("run", Mathf.Abs(horizontal));

		if (Isgrounded && jump) {
		
			Isgrounded = false;
			rb.AddForce (new Vector2 (0, jumpfroce));
		}
	}

	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) 
		{

			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	private bool Isgrounded1()
	{
		if (rb.velocity.y <= 0) {
			foreach (Transform point in groundponts) {
			
				Collider2D[] collider = Physics2D.OverlapCircleAll (point.position,groundradiuos, whatIsground);
			   
				for (int i = 0; i < collider.Length; i++) {
					
					if (collider [i].gameObject != gameObject) {
					
						return true;
					}
				}
			}
		}
		return false;
	}

	private void HandelInput()
	{
		if (Input.GetKey (KeyCode.Space)) {
			jump = true;
		}
	}

	private void ResetValues()
	{
		jump = false;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "coin") {
			Destroy (other.gameObject);
			Score++;
			Score_text ();

		}
		if (other.gameObject.tag == "Helth_D") {
			health--;
		    Health_text ();
			if (health == 0) {
				anim.SetTrigger ("Dead");
				current.SetActive (false);
				next.SetActive (true);
				Score_text1 ();
				Health_text1 ();
				Dead_Is = true;

			}
		}
		if (other.gameObject.tag == "Dead_line") {
			anim.SetTrigger ("Dead");
			current.SetActive (false);
			next.SetActive (true);
			Score_text1 ();
			Health_text1 ();
			Dead_Is = true;
		}
		if (other.gameObject.tag == "finsh") {
		
			win.SetActive (true);
			current.SetActive (false);
			Health_text2();
			Score_text2();
		}


	}

	public void Score_text()
	{
		Scoretext.text = " Score :- " + Score.ToString ();
	}
	public void Health_text()
	{
		Healthtext.text = " Helth Score :- " + health.ToString ();
	}

	public void Score_text1()
	{
		Scoretext1.text = " Score :- " + Score.ToString ();
	}
	public void Health_text1()
	{
		Healthtext1.text = " Helth Score :- " + health.ToString ();
	}
	public void Score_text2()
	{
		Scoretext2.text = " Score :- " + Score.ToString ();
	}
	public void Health_text2()
	{
		Healthtext2.text = " Helth Score :- " + health.ToString ();
	}
		
	}