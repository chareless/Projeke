using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject cam;
    public GameObject play;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = play.transform.position.x;
        float y = play.transform.position.y;
        float z = cam.transform.position.z;
        cam.transform.position = new Vector3(x, y,z);
    }
}
