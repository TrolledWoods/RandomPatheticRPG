using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour {

    public Texture2D roomDesign;
    public ColorToTile[] dictionary;

	// Use this for initialization
	void Start () {
		
        for(int i = 0; i < roomDesign.width; i++)
        {
            for(int j = 0; j < roomDesign.height; j++)
            {
                Color c = roomDesign.GetPixel(i, j);

                for(int d = 0; d < dictionary.Length; d++)
                {
                    Color dColor = dictionary[d].color;
                    if(dColor.r == c.r && dColor.g == c.g && dColor.b == c.b)
                    {
                        Instantiate(dictionary[d].models[Random.Range(0, dictionary[d].models.Length)], 
                                            new Vector3(i, 0, j), Quaternion.identity);
                    }
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
