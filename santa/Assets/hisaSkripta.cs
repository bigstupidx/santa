using UnityEngine;
using System.Collections;

public class hisaSkripta : MonoBehaviour {

    // Use this for initialization
    hiseGenerator mapGenerator;
    public int IdHisa = -1;
    public float speed;
    public bool vCol = false;
	void Start () {
        mapGenerator = GameObject.Find("Hise").GetComponent<hiseGenerator>();
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -speed * Time.deltaTime;
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("dodajHiso"))
        {
            vCol = false;
            mapGenerator.dodajHiso(transform, IdHisa);
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dodajHiso"))
        {
            vCol = true;
        }
    }


}
