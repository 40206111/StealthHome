using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_player : MonoBehaviour
{
    [SerializeField]
    Transform player_transform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x - player_transform.position.x > 1.0f)
            gameObject.transform.position = new Vector3(player_transform.position.x - 1.0f, 0.0f);
        else if(player_transform.position.x > 1.0f - gameObject.transform.position.x)
            gameObject.transform.position = new Vector3(player_transform.position.x + 1.0f, 0.0f);
    }
}
