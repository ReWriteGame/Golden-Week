using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StartEvent : MonoBehaviour
{
    [Range(0, 30), SerializeField] private float delayActivation = 0;
    public UnityEvent startEvent;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delayActivation);
        startEvent?.Invoke();
        yield break;
    }
}
