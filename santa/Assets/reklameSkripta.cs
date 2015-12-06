using UnityEngine;
using System.Collections;


public class reklameSkripta : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UnityPluginForWindowsPhone.Class1.konstruktor("ca-app-pub-6604259944075538/1324230402", true);
        UnityPluginForWindowsPhone.Class1.loadCelozaslonsko();
        
    }
	
	// Update is called once per frame
	void Update () {
        UnityPluginForWindowsPhone.Class1.showCelozaslonsko();
	}
}
