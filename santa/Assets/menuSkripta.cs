using UnityEngine;
using System.Collections;

public class menuSkripta : MonoBehaviour {

    // Use this for initialization
    public GameObject playGumb;
    public hiseGenerator hise;

    santaSkripta santa;

    static GameObject playG;
	void Start () {
        santa = GameObject.Find("Santa").GetComponent<santaSkripta>();
        playG = playGumb;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void play()
    {
        playGumb.SetActive(false);
        santa.ponastavi();
        hise.dodajPrvoHiso();
        santaSkripta.igranje = true;
    }

    public static void loose()
    {
        playG.SetActive(true);
    }
}
