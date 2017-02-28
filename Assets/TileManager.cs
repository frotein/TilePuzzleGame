using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject tilePrefab;
    public List<Material> colors;
    List<List<Transform>> tiles;
    public static TileManager instance;
    // Use this for initialization
	void Start ()
    {
        instance = this;
        CreateTiles(5, 5);	

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateTiles(int xLnth, int yLnth)
    {
        float lnth = tilePrefab.transform.lossyScale.x;
        tiles = new List<List<Transform>>();
        for (int x = 0; x < xLnth; x++)
        {
            List<Transform> yList = new List<Transform>();
            for (int y = 0; y < yLnth; y++)
            {
                GameObject newTile = GameObject.Instantiate(tilePrefab);
                newTile.transform.position = new Vector3(transform.position.x + x * lnth, transform.position.y + y * lnth, 0);
                newTile.transform.parent = transform;
                int index = Random.Range(0, colors.Count);
                newTile.GetComponent<Renderer>().material = colors[index];
                newTile.GetComponent<Tile>().SetColor(index);
                newTile.GetComponent<Tile>().x = x;
                newTile.GetComponent<Tile>().y = y;
                yList.Add(newTile.transform);
            }
            tiles.Add(new List<Transform>(yList));
        }
    }

    public void SwitchColorsAround(int x, int y)
    {
        if (x > 0)
        {
            tiles[x - 1][y].GetComponent<Tile>().SwitchColor();
            if(y > 0)
                tiles[x - 1][y - 1].GetComponent<Tile>().SwitchColor();

            if(y < tiles[0].Count - 1)
                tiles[x - 1][y + 1].GetComponent<Tile>().SwitchColor();
        }

        if (y > 0)
            tiles[x][y - 1].GetComponent<Tile>().SwitchColor();

        if (y < tiles[0].Count - 1)
            tiles[x][y + 1].GetComponent<Tile>().SwitchColor();

        if (x < tiles.Count - 1)
        {
            tiles[x + 1][y].GetComponent<Tile>().SwitchColor();
            if (y > 0)
                tiles[x + 1][y - 1].GetComponent<Tile>().SwitchColor();

            if (y < tiles[0].Count - 1)
                tiles[x + 1][y + 1].GetComponent<Tile>().SwitchColor();
        }
    }
}
