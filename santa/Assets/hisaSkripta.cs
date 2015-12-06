using UnityEngine;
using System.Collections;

public class hisaSkripta : MonoBehaviour {

    // Use this for initialization
    hiseGenerator mapGenerator;
    public int IdHisa = -1;
    public float speed;
    public bool vCol = false;
    RectTransform rectCanvas;
    RectTransform rectMe;
    void Start () {
        rectMe = GetComponent<RectTransform>();
        rectCanvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        mapGenerator = GameObject.Find("Hise").GetComponent<hiseGenerator>();
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += transform.right * -speed * Time.deltaTime;
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("canvas"))
        {
            gameObject.SetActive(false);
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("canvas"))
        {
            hiseGenerator.dodajHis = true;
        }
    }


}
