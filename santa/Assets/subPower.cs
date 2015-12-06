using UnityEngine;
using System.Collections;

public class subPower : MonoBehaviour {

    // Use this for initialization
    public string status = "";
    public powerSkripta power;
    RectTransform rectCanvas;
    RectTransform rectMe;
	void Start () {
        rectMe = GetComponent<RectTransform>();
        rectCanvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -30f * Time.deltaTime;
        if(gameObject.activeSelf && rectMe.localPosition.x+rectMe.sizeDelta.x/2 < -rectCanvas.sizeDelta.x / 2)
        {
            gameObject.SetActive(false);
            power.nastaviSkalar();
        }
	}


}
