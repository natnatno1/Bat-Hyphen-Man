using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Collision : MonoBehaviour
{
    public float MinDistance = 1.0f;
    public float MaxDistance = 4.0f;
    public float Smooth = 10.0f;
    Vector3 DollyDirection;
    public Vector3 DollyDirectionAdjusted;
    public float Distance;


    // Start is called before the first frame update
    void Awake()
    {

        DollyDirection = transform.localPosition.normalized;
        Distance = transform.localPosition.magnitude;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DesiredCameraPosition = transform.parent.TransformPoint(DollyDirection * MaxDistance);
        RaycastHit Hit;

        if (Physics.Linecast(transform.parent.position, DesiredCameraPosition, out Hit))
        {
            Distance = Mathf.Clamp((Hit.distance * 0.87f), MinDistance, MaxDistance);

        }

        else
        {
            Distance = MaxDistance;
        }

        DollyDirectionAdjusted.Set(DollyDirection.x * Distance, 1.5f, DollyDirection.z * Distance);

        transform.localPosition = Vector3.Lerp(transform.localPosition, DollyDirectionAdjusted, Time.deltaTime * Smooth);

    }
}
