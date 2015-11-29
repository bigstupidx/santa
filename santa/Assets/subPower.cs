using UnityEngine;
using System.Collections;

public class subPower : MonoBehaviour {

    // Use this for initialization
    public string status = "";
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -3f * Time.deltaTime;
	}
}
