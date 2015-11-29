using UnityEngine;
using System.Collections;

public class hisaSkripta : MonoBehaviour {

    // Use this for initialization
    hiseGenerator mapGenerator;
	void Start () {
        mapGenerator = GameObject.Find("Hise").GetComponent<hiseGenerator>();
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("dodajHiso"))
            mapGenerator.dodajHiso(transform);
    }

    
}
