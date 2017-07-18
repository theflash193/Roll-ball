using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
	private Rigidbody rb;
	public Text CountText;
	public Text WinText;
	public float Speed;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCount ();
		WinText.text = "";
	}

	void FixedUpdate() {
		float MoveHorizontal = -Input.GetAxis("Horizontal");
		float MoveVertical = -Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (MoveHorizontal, 0.0f, MoveVertical);
		rb.AddForce(movement * Speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCount ();
		}
	}

	void setCount() {
		CountText.text = "count : " + count.ToString ();
		if (count == 13)
			WinText.text = "Win !";
	}
}
