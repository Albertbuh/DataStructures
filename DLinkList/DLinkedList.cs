namespace DLinkList;

using System.Collections;
#nullable disable

public class Node<T>
{
  public T Value {get; set;}
  public Node<T> Next {get; set;} = null;
  public Node<T> Prev {get; set;} = null;
  public Node(T value)
  {
    Value = value;
  }
}

public class DLinkedList<T> : IEnumerable<T>
{
  Node<T> head;
  Node<T> tail;
  int count;

  public DLinkedList()
  {}
  public DLinkedList(T[] data)
  {
    foreach(var val in data)
      this.AddLast(val);
  }

  public void AddLast(T value)
  {
    Node<T> node = new Node<T>(value);
    if(head is null)
    {
      head = node;
    }
    else
    {
      tail.Next = node;
      node.Prev = tail;
    }
    tail = node;
    count++;
  }
  
  public void AddFirst(T value)
  {
    Node<T> node = new Node<T>(value);
    Node<T> temp = head;
    head = node;
    node.Next = temp;
    if(count == 0)
      tail = head;
    else
      temp.Prev = node;
    count++;
  }

  public void AddBefore(Node<T> node, T value)
  {
     Node<T> newNode = new Node<T>(value);
     Node<T> prev = node.Prev;
     node.Prev = newNode;
     newNode.Next = node;

     prev.Next = newNode;
     newNode.Prev = prev;
  }

  public bool Remove(T value)
  {
    if(IsEmpty)
      throw new InvalidOperationException("List is empty");
    Node<T> current = head;
    //find neccessary node
    while(current != null && !current.Value.Equals(value))
    {
      current = current.Next;
    }
    if(current == null) return false;

    if(current.Next == null) // it is a tail
       tail = current.Prev; 
    else
      current.Next.Prev = current.Prev;

    if(current.Prev == null) // it is a head
      head = current.Next;
    else
      current.Prev.Next = current.Next;

    return true;
  }

  public void RemoveLast()
  {
    if(IsEmpty)
      throw new InvalidOperationException("List is empty");
    if(count == 1)
      this.Clear();
    else{
      tail = tail.Prev;
      tail.Next = null;
      count--;
    }
  }

  public int Count {get {return count;}}
  public bool IsEmpty {get {return count == 0;}}

  public void Clear()
  {
    head = null;
    tail = null;
    count = 0;
  }

  public bool Contain(T value)
  {
    Node<T> current = head;
    while(current != null)
    {
      if(current.Value.Equals(value))
        return true;
      current = current.Next;
    }
    return false;
  }



  IEnumerator IEnumerable.GetEnumerator()
  {
    return ((IEnumerable)this).GetEnumerator();
  }

  IEnumerator<T> IEnumerable<T>.GetEnumerator()
  {
    Node<T> current = head;
    while(current is not null)
    {
      yield return current.Value;
      current = current.Next;
    }
  }

  public IEnumerable<T> BackEnumerator()
  {
      Node<T> current = tail;
      while(current != null)
      {
        yield return current.Value;
        current = current.Prev;
      }
  }
 
}

