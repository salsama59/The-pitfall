using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private float cameraMovementSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.FollowTarget();
    }

    private void FollowTarget()
    {
        if (TargetTransform != null)
        {
            Vector3 finalTargetPosition = new Vector3(this.transform.position.x, TargetTransform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, finalTargetPosition, CameraMovementSpeed);
        }
    }

    public Transform TargetTransform { get => targetTransform; set => targetTransform = value; }
    public float CameraMovementSpeed { get => cameraMovementSpeed; set => cameraMovementSpeed = value; }
}
