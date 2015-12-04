using UnityEngine;
using System.Collections;

public class backGroundSkripta : MonoBehaviour {

    // Use this for initialization
    public float speed;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -speed * Time.deltaTime;
	}
}
