using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
	[SerializeField] rho.RuntimeFloat _time;
	[SerializeField] float _initialTime;

	[SerializeField] rho.Event _onTimerDone;

	void Start()
	{
		_time.Value = _initialTime;
	}

    // Update is called once per frame
    void Update()
    {
		if (_time.Value > 0)
		{
			_time.Value = Mathf.Max(_time.Value - Time.deltaTime, 0);

			if (_time.Value <= 0)
			{
				_onTimerDone.Raise();
			}
		}
    }
}
