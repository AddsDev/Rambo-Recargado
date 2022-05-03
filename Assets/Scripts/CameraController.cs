using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (player == null || camera == null)
            return;

        var pos_camera = camera.transform.position;
        pos_camera.x = player.transform.position.x;
        camera.transform.position = pos_camera;
        /*if(player != null)
        {
            
        }*/

    }

}
