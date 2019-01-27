using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField]
    List<GameObject> sky_gameobjects;
    [SerializeField]
    Transform cam_transform;

    SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = sky_gameobjects[0].GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float length = sprite.bounds.size.x;
        float offset = cam_transform.position.x;

        if (cam_transform.position.x > 0)
        {
            int count = 0;
            while (offset > length)
            {
                offset -= length;
                count++;
            }
            if(count%2 == 1)
            {
                offset += length;
            }
            sky_gameobjects[0].transform.position = new Vector3(cam_transform.position.x - offset * 0.5f - length, sky_gameobjects[0].transform.position.y, sky_gameobjects[0].transform.position.z);
            sky_gameobjects[1].transform.position = new Vector3(cam_transform.position.x - offset * 0.5f, sky_gameobjects[1].transform.position.y, sky_gameobjects[1].transform.position.z);
            sky_gameobjects[2].transform.position = new Vector3(cam_transform.position.x - offset * 0.5f + length, sky_gameobjects[2].transform.position.y, sky_gameobjects[2].transform.position.z);
        }
        else
        {
            int count = 0;
            while (offset < -length)
            {
                offset += length;
                count++;
            }
            if (count % 2 == 1)
            {
                offset -= length;
            }

            sky_gameobjects[0].transform.position = new Vector3(cam_transform.position.x - offset * 0.5f + length, sky_gameobjects[0].transform.position.y, sky_gameobjects[0].transform.position.z);
            sky_gameobjects[1].transform.position = new Vector3(cam_transform.position.x - offset * 0.5f, sky_gameobjects[1].transform.position.y, sky_gameobjects[1].transform.position.z);
            sky_gameobjects[2].transform.position = new Vector3(cam_transform.position.x - offset * 0.5f - length, sky_gameobjects[2].transform.position.y, sky_gameobjects[2].transform.position.z);
        }
    }
}
