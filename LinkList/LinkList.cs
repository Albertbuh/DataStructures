using System.Collections;

namespace LinkList;

#nullable disable
   
internal class Node<T>
{
  public Node(T data)
  {
    Data = data;
  }
  public T Data {get; set;}
  public Node<T> Next {get; set;}
}

public class LinkList<T> : IEnumerable<T> {

  Node<T> head;
  Node<T> tail;
  int count;

  public void Add(T data){
    Node<T> node = new Node<T>(data);

    if(head==null)
      head = node;
    else
      tail.Next = node;
    tail = node;

    count++;
  }
  
  public bool Remove(T data)
  {
    Node<T> current = head;
    Node<T> previous = null;
    
    while(current != null)
    {
      if(current.Data.Equals(data))
      {
        if(previous != null)
        {
          previous.Next = current.Next; 
          
          if(current.Next == null) //list tail
          {
            tail = previous;
          }
        }
        else
        {
          head = head.Next;
          
          if(head == null)
            tail=null;
        }
        count--;
        return true;
      }

      previous = current;
      current = current.Next;
    }
    return false;
  }

  public int Count {get {return count;} }

  public bool IsEmpty{ get {return count == 0;}}

  public void Clear()
  {
    head = tail = null;
    count = 0;
  }

  public bool Contains(T data){
    Node<T> current = head;
    while(current != null)
    {
      if(current.Data.Equals(data))
        return true;

      current = current.Next;
    }
    return false;    
  }

  public void AppendFirst(T data)
  {
    Node<T> node = new Node<T>(data);

    node.Next=head;
    head = node;
    if(count == 0)
      tail = head;
    count++;
  }
  
  IEnumerator IEnumerable.GetEnumerator()
  {
    return ((IEnumerable)this).GetEnumerator();
  }

  IEnumerator<T> IEnumerable<T>.GetEnumerator()
  {
    Node<T> current = head;
    while(current != null)
    {
      yield return current.Data;
      current = current.Next;
    }
  }
}
