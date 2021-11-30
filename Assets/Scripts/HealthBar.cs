using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	public Transform bar;
	void Start()
    {
	
	}

    public void SetSize(float sizeNormalized)
	{
		bar.localScale = new Vector3(sizeNormalized, 1f);
	}
}
