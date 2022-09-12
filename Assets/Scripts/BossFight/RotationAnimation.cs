using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    //Rotational Speed
    public float speed = 0f;
    
    [SerializeField] private Vector3 forwardDirection;

    [SerializeField] private Vector3 reverseDirection;
    
    private void Start()
    {

    }

    void Update ()
    {
        var time = Time.deltaTime * speed;
        
        //Forward Direction
        transform.Rotate(time * forwardDirection.x, time * forwardDirection.y, time * forwardDirection.z, Space.Self);
        
        //Reverse Direction
        transform.Rotate(-time * reverseDirection.x, -time * reverseDirection.y, -time * reverseDirection.z, Space.Self);
    }
}