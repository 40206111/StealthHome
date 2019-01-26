using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerCutScene : MonoBehaviour
{
    public bool begin = false;
    private bool finished = false;

    private Animator anim;
    private Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        trans = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            begin = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(Forward());
        }

        if (finished)
        {
            Vector2 pos = trans.position;
            pos.x += 0.5f * Time.deltaTime;
            trans.position = pos;
        }
    }

    IEnumerator Forward()
    {
        anim.SetBool("Walk", true);
        while (trans.position.y >= -2.3f)
        {
            yield return new WaitForSeconds(0.1f);
            Vector2 pos = trans.position;
            pos.y -= 0.1f;
            pos.x += 0.05f;
            trans.position = pos;
        }

        finished = true;
    }
}
