using System.Collections;

namespace DisjointSet;

public class DisjointSet<T> : IEnumerable<DisjointSet<T>.Node<T>>
where T: notnull
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
        if (Nodes.ContainsKey(id))
            return Nodes[id];
        var x = new Node<T>(id);
        Nodes[id] = x;
        x.Parent = x; 
        return x; 
    } 

    public Node<T> Find(T id)
    {
        if (!Nodes.TryGetValue(id, out var x))
            x = MakeSet(id);
        if (x.Parent != x)
            x.Parent = Find(x.Parent); 
        return x.Parent; 
    }

    public void Delete(T id)
    {
        if (Nodes.ContainsKey(id))
            Nodes.Remove(id);
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

    public bool Contains(T id)
    {
        return Nodes.ContainsKey(id);
    }

    IEnumerator<Node<T>> IEnumerable<Node<T>>.GetEnumerator()
    {
        return Nodes.Values.GetEnumerator();
    }

    public IEnumerator GetEnumerator()
    {
        return Nodes.Values.GetEnumerator();
    }
}