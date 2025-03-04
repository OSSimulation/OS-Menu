using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
	[SerializeField]
	private Text _title;
	
    // Start is called before the first frame update
    void Start()
    {
        _title.text = "23:00";
    }

    // Update is called once per frame
    void Update()
    {
        _title.text = System.DateTime.Now.ToString("HH:mm");
    }
}
