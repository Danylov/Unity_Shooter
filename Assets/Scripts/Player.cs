using UnityEngine;

public class Player : MonoBehaviour
{
   void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) || 
            (Input.GetKeyDown(KeyCode.Space)))
        {
            
        }
    }
}
