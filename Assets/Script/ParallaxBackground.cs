using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject cam;
    [SerializeField] private float parallexEffect;

    private float xposition;
    private float length;
    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xposition = transform.position.x;

    }
    private void Update()
    {
        float distanceMoved = cam.transform.position.x * (1 - parallexEffect);
        float distancToMove = cam.transform.position.x * parallexEffect;

        transform.position = new Vector3(xposition + distancToMove, transform.position.y);

        if (distanceMoved > xposition + length)
            xposition = xposition + length;
        else if (distanceMoved < xposition - length)
            xposition = xposition - length; 
    }
}
