using UnityEngine;
using System.Collections;

public class dariloSkripta : MonoBehaviour {

    // Use this for initialization
    GameObject mapGenerator;
    public santaSkripta santa;
    public float speed = 5;
    void Awake()
    {
        //gameObject.SetActive(false);
        mapGenerator = GameObject.Find("Hise");
        //santa = GameObject.Find("SANTA").GetComponent<santaSkripta>();
        //transform.parent = mapGenerator.transform.parent;
        //transform.SetParent(mapGenerator.transform.parent, false);
        //GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //gameObject.SetActive(false);
    }
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -speed * Time.deltaTime;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "hisa")
        {
            speed = coll.gameObject.GetComponent<hisaSkripta>().speed;
            if(santa != null)
            {
                santa.zgresitev();
            }
            
        }

     }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "dimnik")
        {
            hisaSkripta zac = other.transform.parent.GetComponent<hisaSkripta>();
            if(zac.hp <= 1)
            {
                santa.zadetek();
                gameObject.SetActive(false);
            }
            zac.zadektek();
            
        }else if(other.tag == "spodniCol")
        {
            santa.zgresitev();
            gameObject.SetActive(false);
        }
    }
}
