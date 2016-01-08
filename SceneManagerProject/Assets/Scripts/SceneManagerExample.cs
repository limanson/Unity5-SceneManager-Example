using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerExample : MonoBehaviour
{
    public static SceneManagerExample Instance = null;
    public TextMesh currentSceneTextMesh;
    public TextMesh warningTextMesh;
    public GameObject player;
    public GameObject[] moveObjects;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DisplayCurrentSceneName();
    }

    public void LoadScene(string loadSceneName)
    {
        Scene targetScene = SceneManager.GetSceneByName(loadSceneName);
        if (!targetScene.isLoaded)
        {
            StartCoroutine(LoadSceneAsync(loadSceneName));
        }
        else
        {
            warningTextMesh.text = loadSceneName + " has already loaded !";
        }
    }

    IEnumerator LoadSceneAsync(string loadSceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(loadSceneName, LoadSceneMode.Additive);
        yield return async;
        DisplayCurrentSceneName();
    }
    
    public void UnloadScene(string unloadSceneName)
    {
        Scene targetScene = SceneManager.GetSceneByName(unloadSceneName);
        if (targetScene.isLoaded)
        {
            if (targetScene == SceneManager.GetActiveScene())
            {
                warningTextMesh.text = "Unload current scene will destroy your GameObjects";
            }
            else
            {
                StartCoroutine(UnloadSceneYield(unloadSceneName));
            }
        }
        else
        {
            warningTextMesh.text = unloadSceneName + " does not loaded !";
        } 
    }

    IEnumerator UnloadSceneYield(string unloadSceneName)
    {
        yield return null;
        SceneManager.UnloadScene(unloadSceneName);
        DisplayCurrentSceneName();
    }

    public void MoveToScene(string sceneName)
    {
        Scene targetScene = SceneManager.GetSceneByName(sceneName);
        if (targetScene.IsValid())
        {
            foreach (GameObject ele in moveObjects)
                SceneManager.MoveGameObjectToScene(ele, targetScene);
            SceneManager.SetActiveScene(targetScene);
            DisplayCurrentSceneName();
            MovePlayerPosition();
        }
        else
        {
            warningTextMesh.text = sceneName + " is not valid !";
        }
    }

    void DisplayCurrentSceneName()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        currentSceneTextMesh.text = "Current Scene : " + currentSceneName;
        warningTextMesh.text = "";
    }

    //This is not important just to view easier.
    void MovePlayerPosition()
    {
        Vector2 targetPos = new Vector2(-3.5f, 3.5f);
        targetPos.y = (SceneManager.GetActiveScene().buildIndex - 1) * -2.5f + 1.5f;
        player.transform.position = targetPos;
    }
}
