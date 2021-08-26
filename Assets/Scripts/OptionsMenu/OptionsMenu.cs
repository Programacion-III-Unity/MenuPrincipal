using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;

    void Start(){
        loadResolutionDropDown();
    }

    void loadResolutionDropDown(){
        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(getScreenResolutions());
        resolutionDropDown.value = getCurrentResolutionIndex();
        resolutionDropDown.RefreshShownValue();
    }

    List<string> getScreenResolutions(){
        List<string> options = new List<string>();
        for (int i = 0; i < Screen.resolutions.Length; i++)
            options.Add(Screen.resolutions[i].width + " x " + Screen.resolutions[i].height);
        return options;
    }

    int getCurrentResolutionIndex(){
        int resolutionIndex = 0;
        for (int i = 0; i < Screen.resolutions.Length; i++)
            if (isCurrentResolution(i)) resolutionIndex = i;
        return resolutionIndex;
    }

    // Usamos esta funcion para comparar resoluciones ya que
    // Unity no permite comparar resoluciones directamente, sino
    // que solo permite comparar ancho y alto de forma independiente.
    // Queda mas entendible evaluar ese if en una funcion aparte.
    bool isCurrentResolution(int i){
        if (Screen.resolutions[i].width == Screen.currentResolution.width &&
           Screen.resolutions[i].height == Screen.currentResolution.height)
            return true;
        return false;
    }

    public void SetResolution(int resolutionIndex){
        Screen.SetResolution(
            Screen.resolutions[resolutionIndex].width,
            Screen.resolutions[resolutionIndex].height,
            Screen.fullScreen
            );
    }

    public void SetVolume(float volume) {
        // Calculamos logaritmos, porque los dB del AudioMixer
        // no son lineales, sino que logaritmicos. Esto da como
        // resultado que al mover levemente el slider se llegue 
        // a un volumen nulo. Mathf.Log convierte el valor del 
        // slider a un valor logaritmico correcto. 

        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20); 
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool fullscreen){
        Screen.fullScreen = fullscreen;
    }
    public void ExitMenu(){
        SceneManager.UnloadSceneAsync("OptionsMenu");

    }
}
