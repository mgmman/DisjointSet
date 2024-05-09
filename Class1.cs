namespace DisjointSet;

public class DisjointSet<T>
{
    private Dictionary<T, Node<T>> Nodes = new();
    public class Node<T>
    {
        public readonly T Id;
        public Node<T> Parent;
        public int Rank;

        public Node(T id)
        {
            Id = id;
            Rank = 0;
            Parent = this;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
    
    public Node<T> MakeSet(T id)
    {
        var x = new Node<T>(id);
        Nodes[id] = x;
        x.Parent = x; 
        return x; 
    } 

    public Node<T> Find(T id)
    {
        var x = Nodes[id];
        if (x.Parent != x)
            x.Parent = Find(x.Parent); 
        return x.Parent; 
    }
    
    public Node<T> Find(Node<T> x)
    {
        if (x.Parent != x)
            x.Parent = Find(x.Parent); 
        return x.Parent; 
    }
    
    public void Union(T id1, T id2)
    {
        var x = Find(id1); 
        var y = Find(id2); 
        if (x == y) 
            return; 
        if (x.Rank <= y.Rank) 
            x.Parent = y; 
        else 
            y.Parent = x;
        if (x.Rank == y.Rank) 
            y.Rank++; 
    }
}