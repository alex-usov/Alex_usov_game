using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void SceneShop()
    {
        SceneManager.LoadScene(0);

    }
    public void ScenePlay()
    {
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("coins") < 0)
        {
            SceneShop();
            PlayerPrefs.SetInt("coins", 0);
        }
    }
}
