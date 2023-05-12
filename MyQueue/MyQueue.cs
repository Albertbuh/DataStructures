namespace MyQueue;

using System.Collections;

public class Node<T>
{
  public T Value {get; set;}
  public Node<T>? Next{get; set;}
  public Node(T value) => Value = value;
}

public class MyQueue<T> : IEnumerable<T>
{
  private Node<T>? head;
  private Node<T>? tail;
  int count;

  public void Enqueue(T value)
  {
    Node<T> node = new Node<T>(value);
    Node<T>? temp = tail;
    tail = node;
    if(IsEmpty)
     head = tail;
    else
      if(temp is not null)
        temp.Next = tail;
    count++;
  }

  public T Dequeue()
  {
      if(head is not null)
      {
        T result = head.Value;
        head = head.Next;
        count--;
        return result;
      }
      else
        throw new InvalidOperationException("Queue is empty.");
  }

  public T Peek()
  {
    return head is not null ? head.Value : throw new InvalidOperationException("Queue is Empty");
  }

  public bool Contains(T value)
  {
    Node<T>? current = head;
    while(current != null)
    {
      #nullable disable
      if(current.Value.Equals(value))
        return true;
      #nullable restore
      current = current.Next;
    }
   return false; 
  }

  public void Clear()
  {
    head = null; 
    tail = null;
    count = 0;
  }

  public int Count {get {return count;}}
  public bool IsEmpty{get {return count == 0;}}

  IEnumerator IEnumerable.GetEnumerator()
  {
    return ((IEnumerable)this).GetEnumerator();
  }

  IEnumerator<T> IEnumerable<T>.GetEnumerator()
  {
    Node<T>? current = head;
    while(current is not null)
    {
      yield return current.Value;
      current = current.Next;
    }
  }
}


