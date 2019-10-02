using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CalcFocalPos : MonoBehaviour
{
    [SerializeField]
    private float searchRadius;
    [SerializeField]
    private float enemyWeight;
    public GameObject player;
    public float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gizmos.DrawWireSphere(transform.position, searchRadius);
        Collider2D[] nearUnits = Physics2D.OverlapCircleAll(transform.position, searchRadius);
        Vector3 meanPos = player.transform.position;
        foreach (Collider2D unit in nearUnits)
        {
            if (!unit.transform.CompareTag("Tilemap"))
            {
                meanPos += unit.transform.position * enemyWeight;
            }
        }
        meanPos = meanPos / (nearUnits.Length * enemyWeight + 1);

        transform.position = CamPosSlerp((start, end) => Mathf.Lerp(start, end, followSpeed))(transform.position, meanPos);
    }

    Func<Vector3, Vector3, Vector3> CamPosSlerp(Func<float, float, float > CoordsLerp)
    {
        return (Vector3 start, Vector3 end) => {
            return new Vector3(CoordsLerp(start.x, end.x),
                                CoordsLerp(start.y, end.y), -10);};
    }
}
