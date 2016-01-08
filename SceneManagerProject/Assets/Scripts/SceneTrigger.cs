using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public enum TriggerType { LoadScene, UnloadScene, MoveToScene }
    public TriggerType triggerType;
    public string targetSceneName;

    void OnMouseDown()
    {
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

}
