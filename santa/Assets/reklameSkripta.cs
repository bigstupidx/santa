using UnityEngine;
using System.Collections;


public class reklameSkripta : MonoBehaviour {

	// Use this for initialization


    public static bool showReklamo = false;
    public static bool naloziReklamo = false;

	void Start () {
        UnityPluginForWindowsPhone.Class1.konstruktor("ca-app-pub-6604259944075538/1324230402", true);
        
        UnityPluginForWindowsPhone.Class1.loadCelozaslonsko();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (showReklamo)
        {
            showReklamo = false;
            UnityPluginForWindowsPhone.Class1.showCelozaslonsko();
            Debug.Log("show celo");
        }

        if (naloziReklamo)
        {
            naloziReklamo = false;
            UnityPluginForWindowsPhone.Class1.loadCelozaslonsko();
            Debug.Log("nalozi reklamo");
        }
       
	}
}
