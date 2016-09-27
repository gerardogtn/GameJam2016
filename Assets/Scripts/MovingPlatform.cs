using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    [SerializeField]
    Transform platform;
    [SerializeField]
    Transform startTransform;
    [SerializeField]
    Transform endTransform;
    [SerializeField]
    float platformSpeed;

    Vector3 direction;
    Transform destination;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startTransform.position, platform.localScale);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endTransform.position, platform.localScale);       
    }

    void Start()
    {
        setDestination(endTransform);
    }          

    void FixedUpdate()
    {
        platform.GetComponent<Rigidbody>().MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);
        if (Vector3.Distance(platform.position, destination.position) < Time.fixedDeltaTime * platformSpeed)
        {
            setDestination(destination == startTransform ? endTransform : startTransform);
        }
    }

    void setDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized;
    }
}
