using DisjointSet;
using NUnit.Framework;

namespace DisjointSetTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void test_create_disjoint_set()
    {
        var disjointSet = new DisjointSet<int>();
        Assert.That(disjointSet, Is.Empty);
    }
    
    [Test]
    public void test_make_set_new_id()
    {
        var disjointSet = new DisjointSet<int>();
        var node = disjointSet.MakeSet(1);
        Assert.That(node.Id, Is.EqualTo(1));
        Assert.That(node.Rank, Is.EqualTo(0));
        Assert.That(disjointSet.Find(1).Id, Is.EqualTo(1));
    }
    [Test]
    public void test_find_existing_id()
    {
        var disjointSet = new DisjointSet<int>();
        disjointSet.Union(1, 2);
        disjointSet.Union(2, 3);
        Assert.That(disjointSet.Find(1), Is.SameAs(disjointSet.Find(3)));
    }
    
    [Test]
    public void test_find_existing_id_string()
    {
        var disjointSet = new DisjointSet<string>();
        disjointSet.Union("abra", "cadabra");
        disjointSet.Union("cadabra", "bbb");
        Assert.That(disjointSet.Find("abra"), Is.SameAs(disjointSet.Find("bbb")));
    }
    
    [Test]
    public void test_delete_non_existing_id()
    {
        var disjointSet = new DisjointSet<int>();
        disjointSet.Delete(1);
        Assert.That(disjointSet, Is.Empty);
    }
    
    [Test]
    public void test_find_non_existing_id()
    {
        var disjointSet = new DisjointSet<int>();
        var node = disjointSet.Find(1);
        Assert.That(disjointSet.Contains(1));
    }
}