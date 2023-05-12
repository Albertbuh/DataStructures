namespace Deque;
using System.Collections;
#nullable disable

public class Node<T>
{
  public T Data { get; set; } 
  public Node<T> Next { get; set; }
  public Node<T> Prev { get; set; }
  public Node(T data) => Data = data;
}

public class Deque<T> : IEnumerable<T>
{
  private Node<T> head;
  private Node<T> tail;
  private int count;

  public void AddLast(T data)
  {
    Node<T> node = new Node<T>(data);
    if(head is null)
      head = node;
    else
    {
      tail.Next = node;
      node.Prev = tail;
    }
    tail = node;
    count++;
  }
  
  public void AddFirst(T data)
  {
    Node<T> node = new Node<T>(data);
    Node<T> temp = head;
    node.Next = head;
    head = node;
    if(count == 0)
      tail = node;
    else
      temp.Prev = node;
   count++;
  }

  public T RemoveLast() 
  {
    if(count == 0)
      throw new InvalidOperationException("Deq is empty");
    T result = tail.Data;
    if(count == 1)
      tail = head = null;
    else
    {
      tail = tail.Prev;
      tail.Next = null;
    }
    count--;
    return result;
  }

  public T RemoveFirst()
  {
    if(count == 0)
      throw new InvalidOperationException("Deq is empty");
    T result = head.Data;
    if(count == 1)
      tail = head = null;
    else
    {
      head = head.Next;
      head.Prev = null;
    }
    count--;
    return result;
  }
   
  public T PeekFirst()
  {
    if(IsEmpty)
      throw new InvalidOperationException("Deq is empty");
    return head.Data;
  }
  public T PeekLast()
  {
    if(IsEmpty)
      throw new InvalidOperationException("Deq is empty");
    return tail.Data;

  } 

  public void Clear()
  {
    head = null;
    tail = null;
    count = 0;
  }

  public bool Contains(T data)
  {
    Node<T> current = head;
    while(current != null)
    {
      if(current.Data.Equals(data))
        return true;
      current = current.Next;
    }
    return false;
  }
  
  public int Count { get { return count; } }
  public bool IsEmpty { get { return count == 0;} } 
  IEnumerator IEnumerable.GetEnumerator()
  {
    yield return ((IEnumerable)this).GetEnumerator();
  }

  IEnumerator<T> IEnumerable<T>.GetEnumerator()
  {
    Node<T> current = head;
    while(current is not null)
    {
      yield return current.Data;
      current = current.Next;
    }
  }

  public IEnumerable<T> BackEnumerator(){
    Node<T> current = tail;
    while(current != null)
    {
      yield return current.Data;
      current = current.Prev;
    }
  }
}
