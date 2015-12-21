using UnityEngine;
using System.Collections;

public class load_zakasnitev : MonoBehaviour {

    public GameObject LOADING;

    private void Start()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {
        yield return new WaitForSeconds(1.25f);
        LOADING.SetActive(true);
    }
}
