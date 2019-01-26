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
            while (offset > length)
                offset -= length;

            sky_gameobjects[0].transform.position = new Vector3(cam_transform.position.x - offset * 0.5f - length, sky_gameobjects[0].transform.position.y, sky_gameobjects[0].transform.position.z);
            sky_gameobjects[1].transform.position = new Vector3(cam_transform.position.x - offset * 0.5f, sky_gameobjects[1].transform.position.y, sky_gameobjects[1].transform.position.z);
            sky_gameobjects[2].transform.position = new Vector3(cam_transform.position.x - offset * 0.5f + length, sky_gameobjects[2].transform.position.y, sky_gameobjects[2].transform.position.z);
            if (sky_gameobjects[1].transform.position.x - cam_transform.position.x > length / 2.0f)
            {
                GameObject g = sky_gameobjects[0];
                sky_gameobjects[0] = sky_gameobjects[1];
                sky_gameobjects[1] = sky_gameobjects[2];
                sky_gameobjects[2] = sky_gameobjects[0];
            }
        }
        else
        {
            while (offset < -length)
                offset += length;

            sky_gameobjects[0].transform.position = new Vector3(cam_transform.position.x + offset * 0.5f + length, sky_gameobjects[0].transform.position.y, sky_gameobjects[0].transform.position.z);
            sky_gameobjects[1].transform.position = new Vector3(cam_transform.position.x + offset * 0.5f, sky_gameobjects[1].transform.position.y, sky_gameobjects[1].transform.position.z);
            sky_gameobjects[2].transform.position = new Vector3(cam_transform.position.x + offset * 0.5f - length, sky_gameobjects[2].transform.position.y, sky_gameobjects[2].transform.position.z);
            if (cam_transform.position.x - sky_gameobjects[1].transform.position.x > length / 2.0f)
            {
                GameObject g = sky_gameobjects[0];
                sky_gameobjects[0] = sky_gameobjects[2];
                sky_gameobjects[1] = sky_gameobjects[0];
                sky_gameobjects[2] = sky_gameobjects[1];
            }
        }
    }
}
