using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public int x, y;
    int color;
    Renderer rend;
    // Use this for initialization
	void Start ()
    {
        rend = transform.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetColor(int c)
    {
        color = c;
    }

    public void SwitchColor()
    {
        color += 1;
        color %= 3;
        rend.material = TileManager.instance.colors[color];

    }

    public void OnMouseDown()
    {
        SwitchColor();
        TileManager.instance.SwitchColorsAround(x, y);
    }


   
}
