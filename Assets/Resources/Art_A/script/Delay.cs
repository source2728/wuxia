using UnityEngine;
using System.Collections;

public class Delay : MonoBehaviour
{
    public float delayTime = 1.0f;
    //[SerializeField]
    Animator[] anims;
    [SerializeField]
    ParticleSystem[] delay_Particles;

    void OnEnable()
    {
        if (anims == null)
        {
            anims = GetComponentsInChildren<Animator>();
            //Debug.LogError("animator is null");
        }
        for (int i = 0; anims != null && i < anims.Length; i++)
        {
            anims[i].enabled = false;
        }
        //ps = gameObject.GetComponentsInChildren<ParticleSystem> ();
        foreach (var p in delay_Particles)
        {
            if (p != null)
                p.Stop();
        }

        for (int i = 0, imax = transform.childCount; i < imax; i++)
        {
            var trans = transform.GetChild(i);
            if (trans.GetComponent<Renderer>() != null)
                trans.GetComponent<Renderer>().enabled = false;
        }
        /*
        gameObject.SetActive(false);
*/
        Invoke("DelayFunc", delayTime);
    }

    void DelayFunc()
    {
        for (int i = 0; anims != null && i < anims.Length; i++)
        {
            anims[i].enabled = true;
        }
        for (int i = 0, imax = transform.childCount; i < imax; i++)
        {
            var trans = transform.GetChild(i);
            if (trans.GetComponent<Renderer>() != null)
                trans.GetComponent<Renderer>().enabled = true;
        }

        foreach (var p in delay_Particles)
        {
            if (p != null)
                p.Play();
        }

        /*gameObject.SetActive(true);
        */
    }

}
