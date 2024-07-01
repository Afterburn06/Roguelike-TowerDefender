using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Map Size")]
    public int mapSizeX;
    public int mapSizeZ;

    [Header("Nodes")]
    public Node[] nodeObjects;
    public Node[] grassNode;
    public Node[] pathNode;

    [Header("Cells")]
    public Cell cellPrefab;
    [HideInInspector]
    public List<Cell> cells;

    public GameObject environmentHolder;

    void Start()
    {
        GenerateCells();
    }

    void GenerateCells()
    {
        // For each unit of the map
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeZ; z++)
            {
                // Create a new cell under the environment GameObject
                Cell newCell = Instantiate(cellPrefab, new Vector3(x, 0, z), Quaternion.identity);
                newCell.transform.parent = environmentHolder.transform;
                
                // Create the cell with all possible nodes
                newCell.CreateCell(false, nodeObjects);
                
                // Add the new cell to the list of cells
                cells.Add(newCell);
            }
        }

        StartCoroutine(GeneratePath());
    }

    IEnumerator GeneratePath()
    {
        // For each cell
        for (int c = 0; c < cells.Count; c++)
        {
            if (cells[c].transform.position.x == mapSizeX / 2)
            {
                cells[c].nodeOptions = pathNode;
            }
            else
            {
                cells[c].nodeOptions = grassNode;
            }
            
            // Collapse the cell
            CollapseCell(cells[c]);

            yield return new WaitForSeconds(0.05f);
        }
    }

    void CollapseCell(Cell cellToCollapse)
    {
        // Get the node to be created
        Node selectedNode = cellToCollapse.nodeOptions[0];

        // Create the node under the environment GameObject
        Node createdNode = Instantiate(selectedNode, cellToCollapse.transform.position, selectedNode.transform.rotation);
        createdNode.transform.parent = environmentHolder.transform;

        // Destroy the cell
        Destroy(cellToCollapse.gameObject);
    }
}
