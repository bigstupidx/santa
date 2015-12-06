using UnityEngine;
using System.Collections;

public class canvasSkripta : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;
        

    }
	

}
