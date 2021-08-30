using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    public UnityEvent openEvent = default;

    private Bag bag;

    private void activate()
    {
        openEvent?.Invoke();
    }
    private void OnEnable()
    {
        bag = gameObject.GetComponentInParent<Bag>();
        gameObject.GetComponentInParent<Bag>().openEvent.AddListener(activate);
    }


    private void OnDisable()
    {
        //gameObject.GetComponentInParent<Bag>().openEvent.RemoveListener(activate);
        bag.openEvent.RemoveListener(activate);
    }
    private void OnDestroy()
    {
        //gameObject.GetComponentInParent<Bag>().openEvent.RemoveListener(activate);
        bag.openEvent.RemoveListener(activate);
    }
}
