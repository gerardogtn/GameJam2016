using UnityEngine;
using System.Collections;

public class Constants: MonoBehaviour {
    public static Constants instance = null;
    public string switchControllerMessage = "Press \"Rt\" to toggle.";
    public string switchKeyboardMessage = "Press \"Mouse 1\" to toggle.";

    public float switchMessageDuration = 0.5f;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
