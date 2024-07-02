using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class MapGenerator : MonoBehaviour
{
    [Header("Map Size")]
    public int mapSizeX;
    public int mapSizeZ;

    [Header("Nodes")]
    public Node[] nodeObjects;
    public Node[] grassNode;
    public Node[] pathNode;
    public Node[] startNode;
    public Node[] endNode;

    [Header("Cells")]
    public Cell cellPrefab;
    [HideInInspector]
    public List<Cell> cells;

    [Header("NavMesh")]
    public NavMeshSurface surface;
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

        StartCoroutine(GenerateNodes());
    }

    IEnumerator GenerateNodes()
    {
        // For each cell
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].transform.position.z == 0 && cells[i].transform.position.x == mapSizeX / 2)
            {
                cells[i].nodeOptions = startNode;
            }
            else if (cells[i].transform.position.z == mapSizeZ - 1 && cells[i].transform.position.x == mapSizeX / 2)
            {
                cells[i].nodeOptions = endNode;
            }
            else if (cells[i].transform.position.x == mapSizeX / 2)
            {
                cells[i].nodeOptions = pathNode;
            }
            else
            {
                cells[i].nodeOptions = grassNode;
            }
            
            // Collapse the cell
            CollapseCell(cells[i]);

            yield return new WaitForSeconds(0.05f);
        }

        surface.BuildNavMesh();
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
