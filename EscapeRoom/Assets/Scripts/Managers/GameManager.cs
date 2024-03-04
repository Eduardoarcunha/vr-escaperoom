using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0 ||
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
        {
            AudioManager.instance.PlaySound("DungeonBGM");
        }
    }

    public void EndGame()
    {
        SceneTransitionManager.singleton.GoToSceneAsync(0);
    }
}
