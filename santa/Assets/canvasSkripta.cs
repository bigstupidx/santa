using UnityEngine;
using System.Collections;

public class canvasSkripta : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        gameObject.GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;
    }
	void Start () {
        
        

    }
	

}
