using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    void Awake()
    {
        if (GM != null) GameObject.Destroy(GM);
        else GM = this;
        DontDestroyOnLoad(this);
    }
}
