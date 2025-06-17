using UnityEngine;

public class RatoteObject : MonoBehaviour
{
    
   
    void Update()
    {
        transform.Rotate(0, 0, 180f * Time.deltaTime);
    }
}
