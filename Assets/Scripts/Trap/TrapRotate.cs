using System.Collections;
using UnityEngine;

public class TrapRotate : MonoBehaviour
{
    [SerializeField] private Animator _trapKnife1;
    [SerializeField] private Animator _trapKnife2;
    [SerializeField] private Animator _trapSaw1;
    [SerializeField] private Animator _trapSaw2;
    [SerializeField] private Animator _trapSaw3;

    private void Start()
    {
        _trapKnife1.GetComponent<Animator>();
        _trapKnife2.GetComponent<Animator>();

        _trapSaw1.GetComponent<Animator>();
        _trapSaw2.GetComponent<Animator>();
        _trapSaw3.GetComponent<Animator>();

        StartCoroutine(AnimationStart());
    }

    private IEnumerator AnimationStart()
    {
        float pause = 1f;

        var wait = new WaitForSeconds(pause);

        _trapKnife1.SetBool("isStart", true);
        yield return wait;

        _trapKnife2.SetBool("isStart", true);
        yield return wait;

        _trapSaw1.SetBool("isStart", true);
        yield return wait;

        _trapSaw2.SetBool("isStart", true);
        yield return wait;

        _trapSaw3.SetBool("isStart", true);
    }
}
