using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour {
	public int maxJumpTime;
	public float jumpHeight;
	public float rotateAngle;

	private bool rotating = false;
	private int jumpTimes;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButtonUp (0) && jumpTimes <= maxJumpTime) { 
			JumpUp ();
			Rotate();
			jumpTimes ++; 
		}
		if (rotating) {
			transform.Rotate(0,0,rotateAngle*Time.deltaTime,Space.Self);
		}
	}

	public void Rotate(){
		rotating = true;
	}

	public void JumpUp()
	{
		GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;

	}
	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag == "Floor") {
			jumpTimes = 0;
			rotating = false;
		}
	}
}
