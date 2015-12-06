using UnityEngine;
using System.Collections;

public class menuSkripta : MonoBehaviour {

    // Use this for initialization
    public GameObject playGumb;
    public hiseGenerator hise;

    santaSkripta santa;

    static GameObject playG;
    static GameObject menu;

    AudioListener audio;
    
	void Start () {
        santa = GameObject.Find("SANTA").GetComponent<santaSkripta>();
        playG = playGumb;
        menu = GameObject.Find("MENU");
        audio = gameObject.GetComponent<AudioListener>();
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
        menu.SetActive(false);
    }

    public static void loose()
    {
        playG.SetActive(true);
        menu.SetActive(true);
    }

    public void RATE()
    {
        UnityPluginForWindowsPhone.Class1.prizgiRate();
    }

    public void FB()
    {
        Application.OpenURL("https://www.facebook.com/mordenkul");
    }

    public void leader()
    {

    }

    public void ZVOK()
    {
        audio.enabled = !audio.enabled;
        Debug.Log("zvok");
    }
}
