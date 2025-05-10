using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeSwitch2 : MonoBehaviour
{
    public int treeSetIndex; // Set this in the inspector per button

    public void BuyAndLoadScene()
    {
        Debug.Log($"Setting TreeSet to {treeSetIndex}");
        PlayerPrefs.SetInt("TreeSet", treeSetIndex);
        PlayerPrefs.Save();

        if (Fog.Instance != null)
        {
            Fog.Instance.SetFogLevel(treeSetIndex);
        }

        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene("sceneOne");
    }
}
