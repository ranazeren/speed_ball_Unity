using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTansform;
    public Vector3 offset;

    
    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerTansform.position + offset;
    }
}
