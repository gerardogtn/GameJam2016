using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour {

    [SerializeField]
    Transform platform;
    [SerializeField]
    float platformSpeed;

    [SerializeField]
    Transform[] endPoints;


    int currentPos;
    int dir;

    Vector3 direction;
    Transform destination;

    LineRenderer lineRenderer;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for ( int i = 0; i < endPoints.Length; i++)
        {
            Gizmos.DrawWireCube(endPoints[i].position, platform.localScale);
        }     
    }

    void Start()
    {
        currentPos = 0;
        dir = 1;
        Material mat = Resources.Load<Material>("Materials/line");
        if (!gameObject.GetComponent<LineRenderer>())
        {
            gameObject.AddComponent<LineRenderer>();
            lineRenderer = gameObject.GetComponent<LineRenderer>();
            lineRenderer.SetWidth(0.2f, 0.2f);
            lineRenderer.material = mat;
        }
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        setLines();
        setDestination(endPoints[currentPos]);
    }      

    void setLines()
    {
        List<Vector3> positions = new List<Vector3>();
        foreach (Transform pos in endPoints)
        {            
            positions.Add(pos.position);
        }
        lineRenderer.SetVertexCount(positions.Count);
        lineRenderer.SetPositions(positions.ToArray());
        Vector3 dist = positions[1] - positions[0];
        lineRenderer.materials[0].mainTextureScale = new Vector2(dist.magnitude * 3f, 1f);
    }

    void FixedUpdate()
    {
//        platform.GetComponent<Rigidbody>().MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);
//        platform.position = Vector3.Lerp(platform.position, destination.position, platformSpeed * Time.fixedDeltaTime);
        platform.position = Vector3.MoveTowards(platform.position, destination.position, platformSpeed * Time.fixedDeltaTime);
        if (Vector3.Distance(platform.position, destination.position) <= Time.fixedDeltaTime * platformSpeed * 1.5f)
        {                        
            if (currentPos >= endPoints.Length - 1)
            {
                dir = -1;
            }
            else if (currentPos <= 0)
            {
                dir = 1;
            }
            currentPos += dir;
            Debug.Log(currentPos);
            setDestination(endPoints[currentPos]);
        }
    }

    void setDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized;
    }
}
