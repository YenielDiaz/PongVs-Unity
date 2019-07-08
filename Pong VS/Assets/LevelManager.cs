using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] bool isWon;

    //cachedReference
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        isWon = false;
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWon)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void SetIsWon(bool isWon)
    {
        this.isWon = isWon;
    }
}
