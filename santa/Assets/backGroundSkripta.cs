using UnityEngine;
using System.Collections;

public class backGroundSkripta : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -0.5f * Time.deltaTime;
	}
}
