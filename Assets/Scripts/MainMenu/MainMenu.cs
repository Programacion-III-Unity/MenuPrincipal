using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        GameManager.GM.CurrentScene = "GamePlay";
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }



    public void QuitGame(){
        Application.Quit();
    }

    public void OptionsMenu(){
        SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Additive);
    }
}
