public enum Side // Зробив пречислення для позначення вузлів дерева
{
    Left,
    Right
}

//Створюю сам клас для опису вузла дерева
public class BinaryTreeNode<T> where T : IComparable
{
    // Конструктор для ініціалізаціїї
    public BinaryTreeNode(T data)
    {
        this.Data = data;
    }

    public T Data { get; set; }

    public BinaryTreeNode<T> LeftNode { get; set; }

    public BinaryTreeNode<T> RightNode { get; set; }

    public BinaryTreeNode<T> ParentNode { get; set; }

    public Side? NodeSide =>
        ParentNode == null
        ? (Side?)null
        : ParentNode.LeftNode == this
            ? Side.Left
            : Side.Right;
    public override string ToString() => Data.ToString();
}