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

    AudioListener audioB;
    public Toggle zvokTog;
    public Toggle zvokTog2;
    public Toggle zvokTog3;

    public static bool posodobiLeader = false;

    public Text[] imena;
    public Text[] scori;
    public Text rank;
    

    public GameObject prviPlayGumb;
    public GameObject leaderTabela;
    public GameObject signIN;
    public GameObject CanvasGamplay;
    public GameObject CanvasPrviPlay;
    public GameObject CanvasAnimacija;
    public GameObject canvasStatic;
    public GameObject canvasScore;
    public GameObject restartCas;
    public GameObject restartVis;
    public GameObject NoInternet;
    public GameObject tabelaBoard;

    public GameObject spodnjiCol;
    public GameObject zgorniCol;
    

    public Animator image1;
    public Animator image2;

    public Animator snezinke1;
    public Animator snezinke2;

    public GameObject[] napisi;
    public Toggle[] toogliButtoni;

    List<GameObject> list;
   
    void Awake()
    {

        audioB = gameObject.GetComponent<AudioListener>();
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
                zvokTog2.isOn = false;
                zvokTog3.isOn = false;

            }
        }
        else
        {
            PlayerPrefs.SetInt("zvok", 0);
        }
    }
    
	void Start () {
        //santa = GameObject.Find("SANTA").GetComponent<santaSkripta>();
        playG = playGumb;
        //menu = GameObject.Find("MENU");
        //CanvasGamplay.SetActive(false);
        zacCas = cas;
        list = new List<GameObject>();
        leaderSkripta.getUserRank = true;
        spodnjiCol.SetActive(true);
        zgorniCol.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (posodobiLeader)
        {
            NoInternet.SetActive(false);
            tabelaBoard.SetActive(true);
            
            
            posodobiLeader = false;
            for(int i=0; i < scori.Length; i++)
            {
                scori[i].text = leaderSkripta.scoreR[i];
                imena[i].text = leaderSkripta.imeR[i];
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (leaderTabela.activeSelf)
            {
                //leaderTabela.SetActive(false);
                for(int i=0; i < toogliButtoni.Length; i++)
                {
                    toogliButtoni[i].isOn = false;
                }
            }
        }


    }

    public void play()
    {
        canvasStatic.SetActive(false);
        image1.enabled = true;
        image2.enabled = true;
        snezinke1.enabled = true;
        snezinke2.enabled = true;
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
        santaSkripta.odstevaj = true;
        santaSkripta.prihod = true;
        //menu.SetActive(false);
    }

    public void loose()
    {
        napisi[3].SetActive(false);
        restartVis.SetActive(true);
    }

    public void looseDesno()
    {
        restartCas.SetActive(true);
        napisi[3].SetActive(false);
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
        if(leaderTabela.activeSelf || signIN.activeSelf || NoInternet.activeSelf)
        {
            leaderTabela.SetActive(false);
            signIN.SetActive(false);
            NoInternet.SetActive(false);

            foreach (GameObject g in list)
            {
                g.SetActive(true);
            }
            prviPlayGumb.SetActive(true);
            
        }
        else if (PlayerPrefs.HasKey("user") )
        {
            tabelaBoard.SetActive(false);
            NoInternet.SetActive(true);
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
            prviPlayGumb.SetActive(false);
        }
        else
        {
            signIN.SetActive(true);
            prviPlayGumb.SetActive(false);
        }
    }

    public void ZVOK()
    {
        if(PlayerPrefs.GetInt("zvok") > 0)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("zvok", 0);
            
        }
        else
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("zvok",1);
        }
        
    }

    public void Restart()
    {
        image1.enabled = false;
        image2.enabled = false;

        image1.enabled = true;
        image2.enabled = true;
        snezinke1.enabled = false;
        snezinke1.enabled = true;
        snezinke2.enabled = false;
        snezinke2.enabled = true;
        CanvasAnimacija.SetActive(false);
        CanvasAnimacija.SetActive(true);
        canvasScore.SetActive(false);
        //CanvasGamplay.SetActive(false);
        //CanvasGamplay.SetActive(true);
        restartCas.SetActive(false);
        restartVis.SetActive(false);
        cas = zacCas;
        santa.ponastavi();
        hise.dodajPrvoHiso();
        santaSkripta.igranje = true;
        santaSkripta.prihod = true;
        canvasScore.SetActive(true);
        napisi[3].SetActive(true);
        
        
    }

    public void konecCas()
    {
        napisi[3].SetActive(false);
        CanvasPrviPlay.SetActive(false);
        restartCas.SetActive(true);
    }
}
