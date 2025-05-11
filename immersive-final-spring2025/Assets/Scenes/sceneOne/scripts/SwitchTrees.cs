using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchTrees : MonoBehaviour
{
    public GameObject[] healthyTree;

    public GameObject[] tree2;
    public GameObject[] tree3;

    public GameObject[] deadTree;

    void Start()
    {
        //PlayerPrefs.DeleteKey("TreeSet"); // 🔁 Reset for testing

        int currentSet = PlayerPrefs.GetInt("TreeSet", 0);

        Debug.Log("Tree set loaded from PlayerPrefs: " + currentSet);

        ReplaceTreesWithSet(currentSet);
    }

    void ReplaceTreesWithSet(int setIndex)
    {
        //gets the terrain that is in scene rn
        Terrain terrain = Terrain.activeTerrain;
        if (terrain == null) return;


        //all data fronthy terraiin
        TerrainData terrainData = terrain.terrainData;



        GameObject[] chosenSet = healthyTree; // default tree


        switch (setIndex)
        {
            case 1: chosenSet = tree2; break;
            case 2: chosenSet = tree3; break;

            case 3: chosenSet = deadTree; break;
            case 4: chosenSet = healthyTree; break;
        }


        // Create the neq tree prototypes
        TreePrototype[] newPrototypes = new TreePrototype[chosenSet.Length];

        for (int i = 0; i < chosenSet.Length; i++)
        {
            newPrototypes[i] = new TreePrototype();


            newPrototypes[i].prefab = chosenSet[i];
        }

        terrainData.treePrototypes = newPrototypes;

        // Update  tree prefanbs  to match new trrees fro listr

        TreeInstance[] instances = terrainData.treeInstances;

        for (int i = 0; i < instances.Length; i++)
        {
            instances[i].prototypeIndex = instances[i].prototypeIndex % chosenSet.Length;
        }

        terrainData.treeInstances = instances;
    }
}
