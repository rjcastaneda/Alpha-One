using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour
{
    //Singleton
    private static MusicSingleton _instance;
    public static MusicSingleton Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
