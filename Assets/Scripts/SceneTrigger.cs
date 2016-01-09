using UnityEngine;
using System.Collections;

public class SceneTrigger : MonoBehaviour
{
    public enum TriggerType { LoadScene, UnloadScene, MoveToScene }
    public TriggerType triggerType;
    public string targetSceneName;

    void OnMouseDown()
    {
        StartCoroutine(ClickAnimation());
        switch (triggerType)
        {
            case (TriggerType.LoadScene):
                SceneManagerExample.Instance.LoadScene(targetSceneName);
                break;
            case (TriggerType.UnloadScene):
                SceneManagerExample.Instance.UnloadScene(targetSceneName);
                break;
            case (TriggerType.MoveToScene):
                SceneManagerExample.Instance.MoveToScene(targetSceneName);
                break;
        }
    }

    IEnumerator ClickAnimation()
    {
        transform.localScale = Vector3.one * .45f;
        yield return new WaitForSeconds(.1f);
        transform.localScale = Vector3.one * .5f;
    }
}
