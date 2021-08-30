using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A flexible handler for void events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>
public class VoidEventListener : MonoBehaviour
{
	[SerializeField] private VoidEventChannelSO _channel = default;
    [SerializeField, Range(0, 30)] private float delayActivation = 0;


    public UnityEvent OnEventRaised;

	private void OnEnable()
	{
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	private void OnDisable()
	{
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	private void Respond()
	{
        StartCoroutine(RespondCor());
	}
    private void Activate()
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke();
    }
    

    private IEnumerator RespondCor()
    {
        yield return new WaitForSeconds(delayActivation);
        Activate();
        yield break;
    }
}
