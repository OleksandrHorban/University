public class BinaryTree<T> where T : IComparable
{
    // Клас з вузлами
    public BinaryTreeNode<T> RootNode { get; set; }

    // Метод для додавання вузла у дерево
    public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
    {
        if (RootNode == null)
        {
            node.ParentNode = null;
            return RootNode = node;
        }

        currentNode = currentNode ?? RootNode;
        node.ParentNode = currentNode;
        int result;
        return (result = node.Data.CompareTo(currentNode.Data)) == 0
            ? currentNode
            : result < 0
                ? currentNode.LeftNode == null
                    ? (currentNode.LeftNode = node)
                    : Add(node, currentNode.LeftNode)
                : currentNode.RightNode == null
                    ? (currentNode.RightNode = node)
                    : Add(node, currentNode.RightNode);
    }

    public BinaryTreeNode<T> Add(T data)
    {
        return Add(new BinaryTreeNode<T>(data));
    }

    public void Remove(BinaryTreeNode<T> node)
    {
        try
        {


            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;

            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        Add(bufLeft, node);
                        break;
                }
            }
        }
        catch (Exception ex) { }
    }

    public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
    {
        startWithNode = startWithNode ?? RootNode;
        int result;
        return (result = data.CompareTo(startWithNode.Data)) == 0
            ? startWithNode
            : result < 0
                ? startWithNode.LeftNode == null
                    ? null
                    : FindNode(data, startWithNode.LeftNode)
                : startWithNode.RightNode == null
                    ? null
                    : FindNode(data, startWithNode.RightNode);
    }
    public void Remove(T data)
    {
        var foundNode = FindNode(data);
        Remove(foundNode);
    }

    private void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null)
    {
        if (startNode != null)
        {
            var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
            Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");

            if (nodeSide.Equals("+"))
                this.Center = startNode.Data;
            else if (nodeSide.Equals("L"))
                this.LeftSide.Add(startNode.Data);
            else if (nodeSide.Equals("R"))
                this.RightSide.Add(startNode.Data);

            indent += new string(' ', 3);
            PrintTree(startNode.LeftNode, indent, Side.Left);
            PrintTree(startNode.RightNode, indent, Side.Right);
        }
    }
    public void PrintTree()
    {
        PrintTree(RootNode);
    }

    public object Center { get; private set; }
    public List<object> LeftSide { get;  private set; } = new List<object>();
    public List<object> RightSide { get; private set; } = new List<object>();
}