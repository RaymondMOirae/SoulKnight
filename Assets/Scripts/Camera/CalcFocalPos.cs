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
    private int calcUnits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gizmos.DrawWireSphere(transform.position, searchRadius);
        Collider2D[] nearUnits = Physics2D.OverlapCircleAll(transform.position, searchRadius);
        Vector3 meanPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        foreach (Collider2D unit in nearUnits)
        {
            if (unit.transform.CompareTag("Enemy"))
            {
                calcUnits += 1;
                meanPos += new Vector3(unit.transform.position.x, unit.transform.position.y, -10) * enemyWeight;
            }
        }
        meanPos = meanPos / (calcUnits * enemyWeight + 1);
        calcUnits = 0;  
        transform.position = CamPosSlerp((start, end) => Mathf.Lerp(start, end, followSpeed))(transform.position, meanPos);
    }

    Func<Vector3, Vector3, Vector3> CamPosSlerp(Func<float, float, float > CoordsLerp)
    {
        return (Vector3 start, Vector3 end) => {
            return new Vector3(CoordsLerp(start.x, end.x),
                                CoordsLerp(start.y, end.y), -10);};
    }
}
