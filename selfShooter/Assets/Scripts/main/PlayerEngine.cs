using UnityEngine;
using System.Collections;

public class PlayerEngine : MonoBehaviour {
	private new Transform transform;
	bool isHidden = false;
	Vector3 v;
	Vector3 vo;


	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
		v = new Vector3(0, 0, -0.02f);
		vo = new Vector3(0, 0, 0.02f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isHidden)
		{
			transform.Translate(v);
			isHidden = true;
		}
		else
		{
			transform.Translate(vo);
			isHidden = false;
		}
	}
}
