using UnityEngine;
using System.Collections;

public class SceneInitialize : MonoBehaviour
{
	// Use this for initialization
	IEnumerator Start ()
    {
        SceneManagerExample.Instance.LoadScene("SceneA");
        yield return new WaitForSeconds(1f);
        SceneManagerExample.Instance.MoveToScene("SceneA");
        yield return new WaitForSeconds(1f);
        SceneManagerExample.Instance.UnloadScene("SceneInit");
    }	
}
