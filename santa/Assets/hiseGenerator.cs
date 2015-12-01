using UnityEngine;
using System.Collections;

public class hiseGenerator : MonoBehaviour {

    // Use this for initialization
    public GameObject[] Hise;
    GameObject[] seznamHis;
    int stevec = 0;
    Vector3 zacetnaPos;
    float speed = 0;
    public static float speedP = 1;

    int idHis = 0;
	void Start () {
        seznamHis = new GameObject[100];
        
        for (int i=0; i < seznamHis.Length; i++)
        {
            seznamHis[i] = Instantiate(Hise[Random.Range(0, Hise.Length)]);
            seznamHis[i].transform.SetParent(transform);
            
        }
        zacetnaPos = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -speed * speedP* Time.deltaTime;
        speedP = 1;
	}

    public void dodajHiso(Transform t, int idx)
    {
        if(idx == idHis && santaSkripta.igranje)
        {
            GameObject zac = seznamHis[stevec % seznamHis.Length];
            Vector3 pos = t.transform.localPosition;
            pos.x += t.transform.localScale.x / 2 + zac.transform.localScale.x / 2;
            zac.transform.localPosition = pos;
            zac.SetActive(true);
            zac.GetComponent<hisaSkripta>().IdHisa = idx;
            stevec++;
        }

        
    }

    public void dodajPrvoHiso()
    {
        idHis++;
        if (stevec == 0 || !seznamHis[(stevec-1) % seznamHis.Length].GetComponent<hisaSkripta>().vCol)
        {
            GameObject zac = seznamHis[stevec % seznamHis.Length];
            zac.SetActive(true);
            zac.transform.position = zacetnaPos;
            zac.GetComponent<hisaSkripta>().IdHisa = idHis;
        }
        else
        {
            seznamHis[(stevec - 1) % seznamHis.Length].GetComponent<hisaSkripta>().IdHisa = idHis;
        }
        stevec++;
        speed = 3;
    }
}
