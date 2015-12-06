using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuSkripta : MonoBehaviour {

    // Use this for initialization
    public GameObject playGumb;
    public hiseGenerator hise;

    santaSkripta santa;

    static GameObject playG;
    static GameObject menu;

    AudioListener audio;
    public Toggle zvokTog;

    void Awake()
    {
        audio = gameObject.GetComponent<AudioListener>();
        if (PlayerPrefs.HasKey("zvok"))
        {
            if (PlayerPrefs.GetInt("zvok") > 0)
            {
                //audio.enabled = true;
                //zvokTog.isOn = true;
            }
            else
            {
                //audio.enabled = false;
                PlayerPrefs.SetInt("zvok", 1);
                zvokTog.isOn = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("zvok", 1);
        }
    }
    
	void Start () {
        santa = GameObject.Find("SANTA").GetComponent<santaSkripta>();
        playG = playGumb;
        menu = GameObject.Find("MENU");
        
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
        if(PlayerPrefs.GetInt("zvok") > 0)
        {
            audio.enabled = false;
            PlayerPrefs.SetInt("zvok", 0);
            
        }
        else
        {
            audio.enabled = true;
            PlayerPrefs.SetInt("zvok",1);
        }
        
    }
}
