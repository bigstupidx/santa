using UnityEngine;
using System.Collections;

public class loader : MonoBehaviour {

    IEnumerator Start()
    {
        AsyncOperation async = Application.LoadLevelAsync("scenamain");
        yield return async;
    }

}
