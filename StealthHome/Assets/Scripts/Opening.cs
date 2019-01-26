using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Opening : MonoBehaviour
{
    [SerializeField]
    private Sprite Bump;

    private Transform trans;
    private bool begin = true;
    private float yStart;

    [SerializeField]
    SpriteRenderer legsSr;

    PlayerCutScene pcs;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        yStart = trans.position.y;
        pcs = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCutScene>();
    }

    void Update()
    {
        if (!begin) return;

        begin = false;
        StartCoroutine(Begin());
    }


    IEnumerator Up()
    {
        while (trans.position.y <= -1.42f)
        {
            Vector2 pos = trans.position;
            pos.y += 0.1f;
            trans.position = pos;
            yield return new WaitForSeconds(0.1f);
        }

        pcs.begin = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        legsSr.enabled = false;
    }

    IEnumerator Begin()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<SpriteRenderer>().sprite = Bump;
        StartCoroutine(Up());
    }
}
