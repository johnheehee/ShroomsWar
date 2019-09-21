using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    public SpriteRenderer Background;
    // Start is called before the first frame update
    void Start()
    {
        float orthoSize = Background.bounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthoSize;
    }
    
}
