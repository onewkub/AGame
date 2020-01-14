using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
	public static GameSystem Instance { get; set; }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
	private void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}
	public void DestroyIt()
	{
		Destroy(gameObject);
	}
}
