using MyList;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyListTests;

public class MyListLests
{
    [Fact]
    public void CreateEmptyList()
    {
        MyList<string> list;

        list = new MyList<string>();

        Assert.Equal(0, list.Count);
        Assert.Empty(list);
    }

    [Fact]
    public void AddElementToEmptyList()
    {
        var list = new MyList<int>();

        list.Add(5);

        Assert.NotEmpty(list);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void GetElementByIndex()
    {
        var list = new MyList<int> { 1, 2, 3 };

        var item = list[1];

        Assert.Equal(2, item);
    }

    [Fact]
    public void AddElementToEnd()
    {
        var list = new MyList<int> { 1, 2, 3 };

        list.Add(4);

        Assert.Equal(4, list.Count);
        Assert.Equal(4, list.Last());
    }

    [Fact]
    public void AddElementToHead()
    {
        var list = new MyList<int> { 1, 2, 3 };

        list.AddFirst(8);

        Assert.Equal(4, list.Count);
        Assert.Equal(8, list.First());
        Assert.Equal(8, list.First());
    }

    [Fact]
    public void CheackElementContainsInList()
    {
        var list = new MyList<string> { "1", "2", "3" };

        Assert.Contains("1", list);
        Assert.DoesNotContain("foo", list);
    }

    [Fact]
    public void UpdateValueIntoMiddle()
    {
        var list = new MyList<int> { 1, 3 };

        list[1] = 3;

        Assert.Equal(2, list.Count);
        Assert.Equal(3, list[1]);
        Assert.Equal(3, list.Last());
    }

    [Fact]
    public void InsertIntoMiddle()
    {
        var list = new MyList<int> { 1, 3 };

        list.Insert(1, 2);

        Assert.Equal(3, list.Count);
        Assert.Equal(1, list[0]);
        Assert.Equal(2, list[1]);
        Assert.Equal(3, list[2]);
    }

    [Fact]
    public void InsertIntoEmptyList()
    {
        var list = new MyList<string>();

        list.Insert(0, "foo");

        Assert.Equal(1, list.Count);
        Assert.Equal("foo", list[0]);
    }

    [Fact]
    public void InsertIntoHead()
    {
        var list = new MyList<int> { 1, 3 };

        list.Insert(0, 2);

        Assert.Equal(3, list.Count);
        Assert.Equal(2, list[0]);
        Assert.Equal(1, list[1]);
        Assert.Equal(3, list[2]);
    }

    [Fact]
    public void InsertOutOfRange()
    {
        var list = new MyList<int> { 1 };

        Assert.Throws<ArgumentOutOfRangeException>(() => list[2]);
    }

    [Fact]
    public void CreateListByMyList()
    {
        var list = new MyList<int> { 1, 3 };

        var a = new MyList<int>(list);

        Assert.Equal(1, a[0]);
        Assert.Equal(3, a[1]);
    }

    [Fact]
    public void CreateListByList()
    {
        var list = new List<int> { 1, 3 };
        var a = new MyList<int>(list);

        Assert.Equal(1, a[0]);
        Assert.Equal(3, a[1]);
    }

    [Fact]
    public void GetReverseList()
    {
        var list = new MyList<int> { 1, 3 };

        var rev = list.CustomReverse();

        Assert.Equal(3, rev.First());
        Assert.Equal(1, rev.Last());
    }

    [Fact]
    public void GetReverseListAndCreateList()
    {
        var list = new MyList<int> { 1, 3 };

        var rev = new MyList<int>(list.CustomReverse());

        Assert.Equal(3, rev[0]);
        Assert.Equal(1, rev[1]);
    }

    [Fact]
    public void RemoveElementIntoMiddle()
    {
        var list = new MyList<int> { 1, 4, 3 };

        list.RemoveAt(1);

        Assert.Equal(2, list.Count);
        Assert.Equal(1, list[0]);
        Assert.Equal(3, list[1]);
    }

    [Fact]
    public void RemoveElementByEmptyList()
    {
        var list = new MyList<int>();

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(0));
    }
}
