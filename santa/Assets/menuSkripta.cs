using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class menuSkripta : MonoBehaviour {

    // Use this for initialization
    public float cas;
    float zacCas;
    public GameObject playGumb;
    public hiseGenerator hise;

    public santaSkripta santa;

    static GameObject playG;
    static GameObject menu;

    AudioListener audio;
    public Toggle zvokTog;

    public static bool posodobiLeader = false;

    public Text[] imena;
    public Text[] scori;

    public GameObject leaderTabela;
    public GameObject signIN;
    public GameObject CanvasGamplay;
    public GameObject CanvasPrviPlay;
    public GameObject CanvasAnimacija;
    public GameObject canvasStatic;
    public GameObject canvasScore;
    public GameObject restartCas;
    public GameObject restartVis;

    public Animator image1;
    public Animator image2;

    public GameObject[] napisi;

    List<GameObject> list;
   
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
        //santa = GameObject.Find("SANTA").GetComponent<santaSkripta>();
        playG = playGumb;
        //menu = GameObject.Find("MENU");
        CanvasGamplay.SetActive(false);
        zacCas = cas;
        list = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (posodobiLeader)
        {
            posodobiLeader = false;
            for(int i=0; i < scori.Length; i++)
            {
                scori[i].text = leaderSkripta.scoreR[i];
                imena[i].text = leaderSkripta.imeR[i];
            }

        }

        if(cas <= 0)
        {
            konecCas();
        }
        if (CanvasGamplay.activeSelf)
        {
            cas -= Time.deltaTime;
        }
        
	}

    public void play()
    {
        canvasStatic.SetActive(false);
        image1.enabled = true;
        image2.enabled = true;
        CanvasAnimacija.SetActive(true);
        CanvasPrviPlay.SetActive(false);
        CanvasGamplay.SetActive(true);
        playGumb.SetActive(false);
        santa.ponastavi();
        hise.dodajPrvoHiso();
        santaSkripta.igranje = true;
        canvasScore.SetActive(true);
        cas = zacCas;
        napisi[3].SetActive(true);
        //menu.SetActive(false);
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
        if(leaderTabela.activeSelf || signIN.activeSelf)
        {
            leaderTabela.SetActive(false);
            signIN.SetActive(false);
            foreach(GameObject g in list)
            {
                g.SetActive(true);
            }
        }
        else if (PlayerPrefs.HasKey("user") )
        {
            leaderTabela.SetActive(true);
            leaderSkripta.getTopNRanks = true;
            for(int i=0; i < napisi.Length; i++)
            {
                if (napisi[i].activeSelf)
                {
                    list.Add(napisi[i]);
                    napisi[i].SetActive(false);
                }
            }
        }
        else
        {
            signIN.SetActive(true);
        }
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

    public void Restart()
    {
        image1.enabled = false;
        image2.enabled = false;

        image1.enabled = true;
        image2.enabled = true;
        CanvasAnimacija.SetActive(false);
        CanvasAnimacija.SetActive(true);
        canvasScore.SetActive(false);
        cas = zacCas;
        santa.ponastavi();
        hise.dodajPrvoHiso();
        santaSkripta.igranje = true;
        canvasScore.SetActive(true);
        napisi[3].SetActive(true);
        CanvasGamplay.SetActive(true);
        restartCas.SetActive(false);
        restartVis.SetActive(false);
        
    }

    public void konecCas()
    {
        napisi[3].SetActive(false);
        CanvasPrviPlay.SetActive(false);
        restartCas.SetActive(true);
    }
}
