using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class hiseGenerator : MonoBehaviour {

    // Use this for initialization
    public GameObject[] Hise;
    public GameObject[] seznamHis;
    int stevec = 0;
    Vector3 zacetnaPos;
    public float speed = 0;
    public static float speedP = 0;
    RectTransform parentC;

    float posTime = 0;

    int idHis = 0;
    public static bool dodajHis = false;
    Transform trZadnja;
    int iDzadnja = 0;
   

	void Start () {
        parentC = transform.parent.GetComponent<RectTransform>();
        stevec = 0;//Random.Range(0, 1000);
        
        //seznamHis = new GameObject[Hise.Length*4];
        
        //for (int i=0; i < Hise.Length; i++)
        //{
        //    for(int j=0; j < 4; j++)
        //    {
        //        seznamHis[i*4 + j] = Instantiate(Hise[i], new Vector3(70000, 40000 + Random.value * 2000), Quaternion.Euler(0, 0, 0)) as GameObject;
        //        seznamHis[i*4+j].transform.SetParent(transform, false);
        //    }
        //    //
        //    //seznamHis[i].GetComponent<RectTransform>().position = new Vector3(20000, 20000, 1);
        //    //seznamHis[i] = transform.GetChild(i).gameObject;

        //}
        seznamHis = shuffle(seznamHis);
        zacetnaPos = transform.position;
        
	}

    public static GameObject[] shuffle(GameObject[] tab)
    {
        for(int i=0; i < tab.Length; i++)
        {
            int ink = Random.Range(0,tab.Length);
            GameObject pom = tab[i];
            tab[i] = tab[ink];
            tab[ink] = pom;
        }
        return tab;
    }

    


    // Update is called once per frame
    void Update () {
        transform.position += transform.right * -speed * speedP* Time.deltaTime;
        if (dodajHis)
        {
            
            dodajHiso(trZadnja);
            dodajHis = false;
        }
	}

    public void dodajHiso(Transform t)
    {
        if(santaSkripta.igranje)
        {
            GameObject zac = seznamHis[stevec % seznamHis.Length];
            Vector3 pos = t.GetComponent<RectTransform>().localPosition;
            pos.x += (t.GetComponent<RectTransform>().sizeDelta.x / 2 + zac.GetComponent<RectTransform>().sizeDelta.x / 2);
            t.GetComponent<RectTransform>();
            zac.GetComponent<RectTransform>().localPosition = pos;
            zac.SetActive(true);
            zac.GetComponent<hisaSkripta>().IdHisa = iDzadnja;
            stevec++;
            
            
            //zac.GetComponent<Collider2D>().enabled = true;
            trZadnja = zac.transform;
            posTime = Time.time;
        }

        
    }

    public void dodajPrvoHiso()
    {

        speedP = 1;
        idHis++;
        
        
        GameObject zac = seznamHis[stevec % seznamHis.Length];
        zac.SetActive(true);
            
        RectTransform rt = zac.GetComponent<RectTransform>();
        Vector3 pos = new Vector3(parentC.sizeDelta.x / 2 + rt.sizeDelta.x / 2, -parentC.sizeDelta.y / 2 + rt.sizeDelta.y / 2);
        pos.x += (parentC.localPosition - transform.localPosition).x;
        rt.localPosition = pos;
            
        zac.GetComponent<hisaSkripta>().IdHisa = idHis;
        //zac.GetComponent<Collider2D>().enabled = true;
        trZadnja = zac.transform;
        posTime = Time.time;
        Debug.Log(posTime + "time");

        iDzadnja = idHis;
        stevec++;
        

    }
}
