using UnityEngine;
using System.Collections;

public class Constants: MonoBehaviour {
    public static Constants instance = null;
    public string switchMessage = "Press \"Rt\" to toggle.";
    public float switchMessageDuration = 0.5f;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            switchMessage = "Press \"Rt\" to toggle.";

        }
        else
        {
            switchMessage = "Press \"Mouse 1\" to toggle.";
        }
    }
}
