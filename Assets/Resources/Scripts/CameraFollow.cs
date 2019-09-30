using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public GameObject focalPoint;
    [SerializeField]
    private float followSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CamPosSlerp((start, end) => Mathf.Lerp(start, end, followSpeed))(transform.position, focalPoint.transform.position);
    }

    Func<Vector3, Vector3, Vector3> CamPosSlerp(Func<float, float, float > CoordsLerp)
    {
        return (Vector3 start, Vector3 end) => {
            return new Vector3(CoordsLerp(start.x, end.x),
                                CoordsLerp(start.y, end.y), -10);};
    }
}
