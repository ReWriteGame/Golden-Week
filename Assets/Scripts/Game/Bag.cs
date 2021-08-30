using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] private SpriteRenderer openSprite;
    [SerializeField] private SpriteRenderer closeSprite;

    public UnityEvent openEvent = new UnityEvent();
    public UnityEvent closeEvent = new UnityEvent();
    private void Start()
    {
        if (openEvent == null)
            openEvent = new UnityEvent();
        if (closeEvent == null)
            closeEvent = new UnityEvent();

        Reset();
    }
    public void open()
    {
        closeSprite.enabled = false;
        openSprite.enabled = true;
        openEvent.Invoke();
    }
    public void close()
    {
        closeSprite.enabled = true;
        openSprite.enabled = false;
        closeEvent?.Invoke();
    }
    public void Reset()
    {
        close();
    }
}
