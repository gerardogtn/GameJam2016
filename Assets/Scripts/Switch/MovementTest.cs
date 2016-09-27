using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementTest : MonoBehaviour {
    public float moveSpeed;
    List<Collider> inColliders = new List<Collider>();
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        if (Input.GetButtonDown("Fire1"))
        {
            inColliders.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver));
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enter Collider");
        inColliders.Add(col);
    }

    void OnTriggerExit(Collider col)
    {
        inColliders.Remove(col);
    }
}