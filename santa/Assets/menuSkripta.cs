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
    

    public static bool posodobiLeader = false;

    public Text[] imena;
    public Text[] scori;
    public Text[] mesta;
    public Text rank;
    public Text zadnjaStev;

    public GameObject canvasGumbSound;
    public GameObject[] prviPlayGumb;
    public GameObject leaderTabela;
    public GameObject signIN;
    public GameObject CanvasGamplay;
    public GameObject hiseObjekti;
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

    public Animator image3;
    public Animator image4;

    public GameObject[] napisi;
    public Toggle[] toogliButtoni;

    public Text errorji;
    public static Text errorstat;
    public static bool userVpisan = false;

    List<GameObject> list;
    bool prviStart = false;
   
    void Awake()
    {
        
        //PlayerPrefs.DeleteAll();
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
        //CanvasGamplay.SetActive(false);
        zacCas = cas;
        list = new List<GameObject>();
        leaderSkripta.getUserRank = true;
        spodnjiCol.SetActive(true);
        zgorniCol.SetActive(true);

        
        errorstat = errorji;
        //hiseObjekti.SetActive(true);
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

                if(PlayerPrefs.HasKey("rank") && PlayerPrefs.GetInt("rank") == i + 1)
                {
                    scori[i].color = new Color(1, 108 / 256f, 99 / 256f, 1);
                    imena[i].color = new Color(1, 108 / 256f, 99 / 256f, 1);
                    mesta[i].color = new Color(1, 108 / 256f, 99 / 256f, 1);
                }
                else
                {
                    scori[i].color = new Color(1, 1, 1, 1);
                    imena[i].color = new Color(1, 1, 1, 1);
                    mesta[i].color = new Color(1, 1, 1, 1);
                }
            }

            if(PlayerPrefs.HasKey("rank") && PlayerPrefs.GetInt("rank") > 9)
            {
                scori[scori.Length - 1].text = PlayerPrefs.GetInt("score")+"";
                imena[scori.Length - 1].text = PlayerPrefs.GetString("user");
                zadnjaStev.text = PlayerPrefs.GetInt("rank") + "";
                scori[scori.Length - 1].color = new Color(1, 108 / 256f, 99 / 256f, 1);
                imena[scori.Length - 1].color = new Color(1, 108 / 256f, 99 / 256f, 1);
                mesta[scori.Length - 1].color = new Color(1, 1, 1, 1);

            }
            else
            {
                zadnjaStev.text = "10";
                zadnjaStev.color = new Color(1,1, 1, 1);
                scori[scori.Length - 1].color = new Color(1, 1, 1, 1);
                imena[scori.Length - 1].color = new Color(1, 1, 1, 1);
                mesta[scori.Length - 1].color = new Color(1, 1, 1, 1);
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (leaderTabela.activeSelf || signIN.activeSelf)
            {
                //leaderTabela.SetActive(false);
                for(int i=0; i < toogliButtoni.Length; i++)
                {
                    toogliButtoni[i].isOn = false;
                }
            }
        }
        if (userVpisan)
        {
            userVpisan = false;
            leader();
        }

        


    }

    public void play()
    {



        canvasGumbSound.SetActive(false);
            canvasStatic.SetActive(false);
            image1.enabled = true;
            image2.enabled = true;
        image4.enabled = true;
        image3.enabled = true;
            snezinke1.enabled = true;
            snezinke2.enabled = true;
            playGumb.SetActive(false);
            CanvasAnimacija.SetActive(true);
            CanvasPrviPlay.SetActive(false);
            CanvasGamplay.SetActive(true);

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
        canvasGumbSound.SetActive(true);
        napisi[3].SetActive(false);
        restartVis.SetActive(true);
    }

    public void looseDesno()
    {
        restartCas.SetActive(true);
        napisi[3].SetActive(false);
        canvasGumbSound.SetActive(true);
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
        errorstat.text = "";
        if(leaderTabela.activeSelf || signIN.activeSelf || NoInternet.activeSelf)
        {
            leaderTabela.SetActive(false);
            
                
            NoInternet.SetActive(false);

            foreach (GameObject g in list)
            {
                g.SetActive(true);
            }
            for(int i=0; i < prviPlayGumb.Length; i++)
            {
                prviPlayGumb[i].SetActive(true);
            }
            
            if (signIN.activeSelf)
            {
                signIN.SetActive(false);
                if (PlayerPrefs.HasKey("user"))
                {
                    leader();
                }
                
            }

        }
        else if (PlayerPrefs.HasKey("user") )
        {
            tabelaBoard.SetActive(false);
            signIN.SetActive(false);
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
            
            for (int i = 0; i < prviPlayGumb.Length; i++)
            {
                prviPlayGumb[i].SetActive(false);
            }
        }
        else
        {
            signIN.SetActive(true);
            for (int i = 0; i < prviPlayGumb.Length; i++)
            {
                prviPlayGumb[i].SetActive(false);
            }
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
        canvasGumbSound.SetActive(false);
        image1.enabled = false;
        image2.enabled = false;
        image4.enabled = false;
        image3.enabled = false;

        image1.enabled = true;
        image2.enabled = true;

        image4.enabled = true;
        image3.enabled = true;
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
