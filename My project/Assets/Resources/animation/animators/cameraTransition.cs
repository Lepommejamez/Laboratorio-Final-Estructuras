using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class cameraTransition : MonoBehaviour
{
    public UnityEvent onTransition;
    public UnityEvent onTransitionFinish;
    public static cameraTransition camTransition;
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        camTransition = this;
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterAndExitDelayed(float delay)
    {
        StartCoroutine(toggle(delay));
    }

    IEnumerator toggle(float delay)
    {
        anime.SetTrigger("start");
        yield return new WaitForSeconds(delay/2);
        onTransition.Invoke();
        yield return new WaitForSeconds(delay/2);
        anime.SetTrigger("end");
        onTransitionFinish.Invoke();
    }
}
