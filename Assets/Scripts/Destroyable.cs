using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour
{
    public bool canDestroyable = true;
    public UnityEvent OnDestroyObject;

    public void destroy(float dalay = 0)
    {
        if (dalay < 0) return;
        if(canDestroyable) StartCoroutine(destroyCor(dalay));
    }

    private IEnumerator destroyCor(float dalay = 0)
    {
        yield return new WaitForSeconds(dalay);
        Destroy(gameObject);
        yield break;
    }

    private void OnDestroy()// public?
    {
        OnDestroyObject?.Invoke();
    }
}
