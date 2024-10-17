using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool collapsed;
    public Node[] nodeOptions;

    public void CreateCell(bool collapseState, Node[] nodes)
    {
        // Set the collapsed variable of this script to the one passed in when this method was called
        collapsed = collapseState;
        // Fill the options this cell can become with the ones passed in when this method was called
        nodeOptions = nodes;
    }
}
