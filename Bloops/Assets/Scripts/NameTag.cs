using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTag : MonoBehaviour
{
	public Text nameLabel;
	public float yModify;
	public float xModify;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 namePos = Camera.main.WorldToScreenPoint(transform.position);
		namePos[1] += yModify;
		namePos[0] += xModify;
		nameLabel.transform.position = namePos;
    }
}
