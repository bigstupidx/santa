using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class santaSkripta : MonoBehaviour {

    // Use this for initialization
    public AudioClip spustVDimnik;
    public AudioClip spustZgresitev;
    public GameObject[] darila;
    GameObject[] seznamDaril;
    int stevec = 0;

    bool staroStanje = false;
    bool novoStanje = false;

    int stZadetkov = 0;
    int stZgresitev = 0;
    int hp = 1;
    public Text score;
    public Text scoreCas;
    public Text scoreVis;
    public Text hpText;
    public float timeIgre = 60;

    GameObject hisoDodaj;
    menuSkripta menuSkript;
    float scit = 0;
    float dvojne = 0;
    float hitrost = 0;
    int rezultat = 0;
    static public bool igranje = false;
    float casDarila = 0;

    bool vVisave = false;
    bool levo = false;
    float speedLeft=0;
    float casLeft = 0;

    bool desno = false;
    float speedRight = 0;
    float casRight = 0;

    float casIgre = 0;
    public static bool odstevaj = false;

    public static bool prihod = false;
    float speedPrihod = 200;

    float cilj = 0;
    int colStanje = -1;

    void Awake()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(212 - 1000, 13, 0);
        seznamDaril = new GameObject[30];
        
    }
	void Start () {
        casIgre = timeIgre;
        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", 0);

        }
        
        menuSkript = GameObject.Find("Main Camera").GetComponent<menuSkripta>();
        zmaga();
        hisoDodaj = GameObject.Find("dodajHiso");
        
        cilj = GetComponent<RectTransform>().localPosition.y;

        //hpText.text = "HP " + hp;
        colStanje = 0;

        for (int i = 0; i < seznamDaril.Length; i++)
        {
            seznamDaril[i] = Instantiate(darila[Random.Range(0, darila.Length)], new Vector3(30000, 20000 + Random.value * 2000), Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        GetComponent<RectTransform>().localPosition = new Vector3(212 - 1000, 13, 0);
    }
	
	// Update is called once per frame
	void Update () {

        if(gameObject.GetComponent<RectTransform>().localPosition.y < -500)
        {
            GetComponent<RectTransform>().localPosition = new Vector3(212 - 1000, 13, 0);
        }

        if (odstevaj)
        {
            casIgre -= Time.deltaTime;
            if(casIgre < 0 && colStanje < 1)
            {
                desno = true;
            }
            
        }
        novoStanje = Input.GetMouseButtonDown(0);
        if (novoStanje && !staroStanje && igranje && casDarila <= 0)
        {
            seznamDaril[stevec].SetActive(true);
            seznamDaril[stevec].GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;
            
            seznamDaril[stevec].GetComponent<dariloSkripta>().speed = 2f;
            seznamDaril[stevec].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            seznamDaril[stevec].GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(2, 3.2f), ForceMode2D.Impulse);
            stevec++;
            stevec %= seznamDaril.Length;
            casDarila = 0.25f;
        }else if(casDarila > 0)
        {
            casDarila -= Time.deltaTime;
        }
        staroStanje = novoStanje;
        if(scit > 0)
        {
            scit -= Time.deltaTime;
        }
        if(dvojne > 0)
        {
            dvojne -= Time.deltaTime;
        }
        if(hitrost > 0)
        {
            hitrost -= Time.deltaTime;
            hiseGenerator.speedP = 1.3f;
        }

        if (vVisave)
        {
            if(cilj > gameObject.GetComponent<RectTransform>().localPosition.y)
            {
                gameObject.GetComponent<RectTransform>().localPosition += transform.up * Time.deltaTime * 190;
            }
            else
            {
                vVisave = false;
            }
        }else if (levo)
        {
            
            Debug.Log("v levoooooooo");
            casLeft += Time.deltaTime;
            speedLeft = 50 * casLeft;
            gameObject.GetComponent<RectTransform>().localPosition -= transform.right * speedLeft; 
            if(casLeft > 2)
            {
                levo = false;
                casLeft = 0;
            }
        }
        else if (desno)
        {

            Debug.Log("v levoooooooo");
            casRight += Time.deltaTime;
            speedRight = 50 * casRight;
            gameObject.GetComponent<RectTransform>().localPosition += transform.right * speedRight;
            if (casRight > 2)
            {
                desno = false;
                casRight = 0;

            }
        }else if (prihod)
        {
            Vector3 pos = gameObject.GetComponent<RectTransform>().localPosition;
            float dis = (Mathf.Abs(212 - pos.x) / 1) * Time.deltaTime;
            gameObject.GetComponent<RectTransform>().localPosition += transform.right * dis;
            if(pos.x >= -212)
            {
                prihod = false;
            }
        }
    }

    public void zgresitev()
    {
        AudioSource.PlayClipAtPoint(spustZgresitev, Vector3.zero);
        if (scit <= 0)
        {
            //stZgresitev++;
            //hp--;
            //hpText.text = "HP " + hp;
            

            cilj += 100;
            vVisave = true;

        }
        
    }

    public void zadetek()
    {
        AudioSource.PlayClipAtPoint(spustVDimnik, Vector3.zero);
        if (dvojne > 0)
        {
            stZadetkov++;
        }
        stZadetkov++;
        score.text = "" + stZadetkov;
        scoreCas.text = "" + stZadetkov;
        scoreVis.text = "" + stZadetkov;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("power"))
        {
            string status = other.gameObject.GetComponent<subPower>().status;
            other.gameObject.SetActive(false);
            if(status == "hp")
            {
                hp++;
                //hpText.text = "HP " + hp;
            }else if(status == "scit")
            {
                scit = 5;
            }else if(status == "dvojne")
            {
                dvojne = 5;
            }else if(status == "hitrost")
            {
                hitrost = 3;
            }
            other.GetComponent<subPower>().power.nastaviSkalar();
        }else if (other.CompareTag("desniCol") && colStanje == 0)
        {
            hiseGenerator.speedP = 3;
            colStanje = 1;
            zmaga();
            igranje = false;
            //hisoDodaj.SetActive(false);
            for (int i = 0; i < seznamDaril.Length; i++)
            {
                if (seznamDaril[i].activeSelf)
                    seznamDaril[i].SetActive(false);
            }
            powerSkripta.ponastavi = 3;
            menuSkript.looseDesno();
            powerSkripta.skalar = 0;
            odstevaj = false;
        }
        else if (other.CompareTag("zgorniCol") && colStanje == 0)
        {
            hiseGenerator.speedP = 3;
            colStanje = 2;
            zmaga();
            igranje = false;
            //hisoDodaj.SetActive(false);
            for (int i = 0; i < seznamDaril.Length; i++)
            {
                if (seznamDaril[i].activeSelf)
                    seznamDaril[i].SetActive(false);
            }
            powerSkripta.ponastavi = 3;
            menuSkript.loose();
            powerSkripta.skalar = 0;
            cilj += 300;
            vVisave = false;
            levo = true;
            odstevaj = false;
            
        }
            
    }

    public void ponastavi()
    {
        colStanje = 0;
        powerSkripta.skalar = 1;
        stZadetkov = 0;
        stZgresitev = 0;
        hp = 1;
        //hisoDodaj.SetActive(true);
        //hpText.text = "HP " + hp;
        score.text = "" + stZadetkov;
        scoreCas.text = "" + stZadetkov;
        scoreVis.text = "" + stZadetkov;
        GetComponent<RectTransform>().localPosition = new Vector3(212-1000, 13, 0);
        cilj = GetComponent<RectTransform>().localPosition.y;
        reklameSkripta.naloziReklamo = true;

        levo = false;
        casLeft = 0;

        desno = false;
        casRight = 0;

        casIgre = timeIgre;
        odstevaj = true;

    }

    public void zmaga()
    {
        if(Random.value < 0.20f && colStanje != -1)
            reklameSkripta.showReklamoZak = true;
        if(PlayerPrefs.GetInt("score") <= stZadetkov && PlayerPrefs.HasKey("user"))
        {
            PlayerPrefs.SetInt("score", stZadetkov);

            leaderSkripta.saveScore = true;
        }
        
    }
}
