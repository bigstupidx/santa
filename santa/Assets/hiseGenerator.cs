using UnityEngine;
using System.Collections;

public class hiseGenerator : MonoBehaviour {

    // Use this for initialization
    public GameObject[] Hise;
    GameObject[] seznamHis;
    int stevec = 0;
    Vector3 zacetnaPos;
    public float speed = 0;
    public static float speedP = 0;
    RectTransform parentC;

 

    int idHis = 0;
	void Start () {
        parentC = transform.parent.GetComponent<RectTransform>();
        
        
        seznamHis = new GameObject[100];
        
        for (int i=0; i < seznamHis.Length; i++)
        {
            seznamHis[i] = Instantiate(Hise[Random.Range(0, Hise.Length)]);
            seznamHis[i].transform.SetParent(transform,false);

        }
        zacetnaPos = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -speed * speedP* Time.deltaTime;

	}

    public void dodajHiso(Transform t, int idx)
    {
        if(idx == idHis && santaSkripta.igranje)
        {
            GameObject zac = seznamHis[stevec % seznamHis.Length];
            Vector3 pos = t.GetComponent<RectTransform>().localPosition;
            pos.x += (t.GetComponent<RectTransform>().sizeDelta.x / 2 + zac.GetComponent<RectTransform>().sizeDelta.x / 2);
            t.GetComponent<RectTransform>();
            zac.GetComponent<RectTransform>().localPosition = pos;
            zac.SetActive(true);
            zac.GetComponent<hisaSkripta>().IdHisa = idx;
            stevec++;
        }

        
    }

    public void dodajPrvoHiso()
    {
        speedP = 1;
        idHis++;
        if (stevec == 0 || !seznamHis[(stevec-1) % seznamHis.Length].GetComponent<hisaSkripta>().vCol)
        {
            GameObject zac = seznamHis[stevec % seznamHis.Length];
            zac.SetActive(true);
            RectTransform rt = zac.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(parentC.sizeDelta.x/2 + rt.sizeDelta.x/2, -parentC.sizeDelta.y/2 + rt.sizeDelta.y/2);
            
            zac.GetComponent<hisaSkripta>().IdHisa = idHis;
        }
        else
        {
            seznamHis[(stevec - 1) % seznamHis.Length].GetComponent<hisaSkripta>().IdHisa = idHis;
        }
        stevec++;
        
    }
}
