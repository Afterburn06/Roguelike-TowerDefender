using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool collapsed;
    public Node[] nodeOptions;

    public void CreateCell(bool collapseState, Node[] nodes)
    {
        collapsed = collapseState;
        nodeOptions = nodes;
    }
}
