using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class santaSkripta : MonoBehaviour {

    // Use this for initialization
    public GameObject[] darila;
    GameObject[] seznamDaril;
    int stevec = 0;

    bool staroStanje = false;
    bool novoStanje = false;

    int stZadetkov = 0;
    int stZgresitev = 0;
    int hp = 1;
    public Text score;
    public Text hpText;

    GameObject hisoDodaj;
    float scit = 0;
    float dvojne = 0;
    float hitrost = 0;
    int rezultat = 0;
    static public bool igranje = false;
	void Start () {
        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", 0);

        }
        zmaga();
        hisoDodaj = GameObject.Find("dodajHiso");
        seznamDaril = new GameObject[30];
        for(int i=0; i < seznamDaril.Length; i++)
        {
            seznamDaril[i] = Instantiate(darila[Random.Range(0,darila.Length)]);
        }
        GetComponent<RectTransform>().localPosition = new Vector3(212,-300,0);
        
        //hpText.text = "HP " + hp;
    }
	
	// Update is called once per frame
	void Update () {
        //foreach (Touch touch in Input.touches)
        //{
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        seznamDaril[stevec].SetActive(true);
        //        seznamDaril[stevec].transform.position = transform.position;
        //        seznamDaril[stevec].GetComponent<dariloSkripta>().speed = 2f;
        //        stevec++;
        //        stevec %= seznamDaril.Length;
        //    }
        //}
        novoStanje = Input.GetMouseButtonDown(0);
        if (novoStanje && !staroStanje && igranje)
        {
            seznamDaril[stevec].SetActive(true);
            seznamDaril[stevec].transform.position = transform.position;
            
            seznamDaril[stevec].GetComponent<dariloSkripta>().speed = 2f;
            seznamDaril[stevec].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            seznamDaril[stevec].GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(4, 0.2f), ForceMode2D.Impulse);
            stevec++;
            stevec %= seznamDaril.Length;
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
    }

    public void zgresitev()
    {
        if(scit <= 0)
        {
            stZgresitev++;
            hp--;
            hpText.text = "HP " + hp;
            if (hp <= 0)
            {
                igranje = false;
                //hisoDodaj.SetActive(false);
                for(int i=0; i < seznamDaril.Length; i++)
                {
                    if(seznamDaril[i].activeSelf)
                        seznamDaril[i].SetActive(false);
                }
                powerSkripta.ponastavi = 3;
                menuSkripta.loose();
                powerSkripta.skalar = 0;

            }
        }
        
    }

    public void zadetek()
    {
        if (dvojne > 0)
        {
            stZadetkov++;
        }
        stZadetkov++;
        score.text = "SCORE: " + stZadetkov;
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
        }
            
    }

    public void ponastavi()
    {
        powerSkripta.skalar = 1;
        stZadetkov = 0;
        stZgresitev = 0;
        hp = 1;
        //hisoDodaj.SetActive(true);
        //hpText.text = "HP " + hp;
        score.text = "SCORE: " + stZadetkov;
    }

    public void zmaga()
    {
        if(PlayerPrefs.GetInt("score") <= rezultat && PlayerPrefs.HasKey("user"))
        {
            PlayerPrefs.SetInt("score", rezultat);
            leaderSkripta.saveScore = true;
        }
        
    }
}
