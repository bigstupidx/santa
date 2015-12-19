using UnityEngine;
using System.Collections;

public class hisaSkripta : MonoBehaviour {

    // Use this for initialization
    hiseGenerator mapGenerator;
    public int IdHisa = -1;
    public float speed;
    public bool vCol = false;
    RectTransform rectCanvas;
    RectTransform rectMe;
    Animator animator;

    public GameObject kapa;
    public AudioClip kapaZvok;

    public int hp;
    public int stariHp;
    void Awake()
    {
        rectMe = GetComponent<RectTransform>();
        rectCanvas = GameObject.Find("Canvas GAMEPLAY").GetComponent<RectTransform>();
        mapGenerator = GameObject.Find("Hise").GetComponent<hiseGenerator>();
        //gameObject.SetActive(false);
        animator = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Animator>();
        kapa = transform.GetChild(1).gameObject;
        kapa.SetActive(false);
    }
    void Start () {
        if(Random.value < 0.21)
        {
            kapa.SetActive(true);
            stariHp = 2;
            hp = 2;
        }
        else
        {
            stariHp = 1;
            hp = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += transform.right * -speed * Time.deltaTime;
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("canvas"))
        {
            gameObject.SetActive(false);
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("canvas"))
        {
            hiseGenerator.dodajHis = true;
            Debug.Log("dodaj hiso");
        }
        
    }

    public void nastaviKapo()
    {
        kapa.SetActive(true);
        hp = 2;
        stariHp = hp;
    }

    public void ponastavi()
    {
        hp = stariHp;
        if(hp > 1)
        {
            kapa.SetActive(true);
        }
    }

    public void zadektek()
    {

        if(hp <= 1)
        {
            sproziAnimator();
            Debug.Log("sprozi animator");

        }
        else
        {
            if(hp == 2)
            {
                AudioSource.PlayClipAtPoint(kapaZvok, Vector3.zero);
                kapa.SetActive(false);
            }
            hp--;

        }
    }
    public void sproziAnimator()
    {
        if(animator != null)
        {
            animator.enabled = false;
            animator.enabled = true;
        }
        
    }


}
