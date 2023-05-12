namespace Stack;

#nullable disable

using System.Collections;
using System.Collections.Generic;

public class Node<T>
{
  public T Data {get; set;}
  public Node<T> Next {get; set;}
  public Node(T data)
  {
    Data = data;
  }
}

public class Stack<T>  : IEnumerable<T> 
{
   Node<T> head;
   int count;
    
   public int Count {get {return count;}}
   public bool IsEmpty {get {return count == 0;}}

   public void Push(T data)
   {
     Node<T> node = new Node<T>(data);
     node.Next = head;
     head = node;
     count++;
   }

   public T Pop()
   {
     if(IsEmpty)
        throw new InvalidOperationException("Stack is empty.");
      Node<T> temp = head;
      head = head.Next;
      count--;
      return temp.Data;

   }

   public T Peek()
   {
     if(IsEmpty)
        throw new InvalidOperationException("Stack is empty.");
     return head.Data;
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

