using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class PlayerCutScene : MonoBehaviour
{
    public bool begin = false;
    private bool finished = false;

    private Animator anim;
    [SerializeField]
    private Animator[] houseAnim;
    [SerializeField]
    private Animator[] IconAnim;
    private Transform trans;

    [SerializeField]
    private string scn = "Cut";

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        trans = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Crouch") > 0)
        {
            SceneManager.LoadScene(scn);
        }

        if (begin)
        {
            begin = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(Forward());
        }

        if (finished && trans.position.x >= GameObject.FindGameObjectWithTag("Camera").GetComponent<Transform>().position.x)
        {
            finished = false;
            anim.SetBool("Walk", false);
            anim.SetBool("Crouch", true);
            StartCoroutine(Alert());
        }

        if (finished)
        {
            Vector2 pos = trans.position;
            pos.x += 0.5f * Time.deltaTime;
            trans.position = pos;
        }
    }

    IEnumerator Alert()
    {
        GameObject[] icons = GameObject.FindGameObjectsWithTag("icons");

        foreach (Animator a in IconAnim)
        {
            a.SetBool("Sleep", false);
        }

        yield return new WaitForSeconds(0.5f);

        foreach (GameObject i in icons)
        {
            i.GetComponent<SpriteRenderer>().enabled = true;
            i.GetComponentInChildren<Light>().intensity = 0.05f;
        }

        foreach (Animator a in houseAnim)
        {
            a.SetInteger("Stage", 1);
        }

        yield return new WaitForSeconds(2);

        foreach (Animator a in IconAnim)
        {
            a.SetBool("Wake", true);
        }
        foreach (Animator a in houseAnim)
        {
            a.SetInteger("Stage", 2);
        }
        foreach (GameObject i in icons)
        {
            i.GetComponentInChildren<Light>().intensity = 0.2f;
        }

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scn);
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
