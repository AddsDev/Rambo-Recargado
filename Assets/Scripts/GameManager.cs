using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public Renderer backgound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        backgound.material.mainTextureOffset = backgound.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;
    }
}
