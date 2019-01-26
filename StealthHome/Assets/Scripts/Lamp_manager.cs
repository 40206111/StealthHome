using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_manager : MonoBehaviour
{
    private List<Transform> lights;
    private Material material;
    [SerializeField]
    Camera cam;
    private List<Vector4> l_pos;
    [SerializeField]
    Texture screen;

    // Start is called before the first frame update
    void Start()
    {
        lights = new List<Transform>();
        l_pos = new List<Vector4>();
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("light");
        foreach (GameObject g in gameObjects)
        {
            lights.Add(g.GetComponent<Transform>());
            l_pos.Add(new Vector2());
        }
        material = new Material(Shader.Find("Custom/Light_shader"));
    }

    void Update()
    {
        for (int i = 0; i < l_pos.Count; i++)
        {
            Vector4 v = new Vector4(lights[i].position.x, lights[i].position.y, lights[i].position.z, 1.0f);
            l_pos[i] = cam.projectionMatrix * cam.worldToCameraMatrix * lights[i].localToWorldMatrix * v;
            l_pos[i] /= l_pos[i].w;
        }
        material.SetVectorArray("light_pos", l_pos);
        //Graphics.Blit(screen, null, -1);
    }

    //// Postprocess the image
    //void OnRenderImage(RenderTexture source, RenderTexture destination)
    //{
    //    print("sadasdasdsasdds");
    //    for (int i = 0; i < l_pos.Count; i++)
    //    {
    //        l_pos[i] = cam.projectionMatrix * cam.worldToCameraMatrix * lights[i].localToWorldMatrix * new Vector4(lights[i].position.x, lights[i].position.y, lights[i].position.z, 1.0f);
    //    }
    //    material.SetVectorArray("light_pos", l_pos);
    //    Graphics.Blit(source, destination, material);
    //}
}
