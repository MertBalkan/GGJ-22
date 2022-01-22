using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        MakeSingletonObject();
    }
    public void LoadNextSceneWithID(int nextSceneId)
    {
        SceneManager.LoadScene(nextSceneId); //loads next scene by given buildIndex value...
    }

    public void LoadNextSceneWithAutomatic()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene automaticly... maybe we can use
    }

    private void MakeSingletonObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
