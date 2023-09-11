public class MinHeap
{
  List<int> data;

  public int Count => data.Count;
 
  private int Parent(int i) => (i-1)/2;
  private int Left(int i) => i*2 + 1;
  private int Right(int i) => i*2 + 2;
  
  public void Print()
  {
    foreach(var d in data)
    {
      Console.Write(d + " ");
    }
    System.Console.WriteLine();
  }
  
  public MinHeap()
  {
   data = new List<int>(); 
  }

  public MinHeap(int[] data) : this()
  {
    // this.data = new List<int>(data);
    foreach(var num in data)
    {
      Insert(num);
    }
  }

  public int? Peek()
  {
    if(Count == 0) 
      return null;
    return data[0];
  }

  public void Insert(int num)
  {
    if(data == null)
      return;
    
    data.Add(num);
    PopUp(Count - 1);
  }

  private void PopUp(int i)
  {
     if(i <= 0)
       return;

     int parentInd = Parent(i);
     while(data[i] < data[parentInd])
     {
       (data[i], data[parentInd]) = (data[parentInd], data[i]);
       i = parentInd;
       parentInd = Parent(parentInd);
     }
  }

  private void PopDown(int i)
  {
    if(Count == 0)
      return;
    
    int l = Left(i);
    int r = Right(i);
    int min = i;
    
    if(l < Count && data[min] > data[l])
      min = l; 
    if(r < Count && data[min] > data[r])
      min = r;

    if(min != i)
    {
      int temp = data[i];
      data[i] = data[min];
      data[min] = temp;
      PopDown(min);
    }
  }

  public int? GetMin()
  {
    if(Count == 0)
      return null;
    int result = data[0];
    data[0] = data[Count-1];
    data.RemoveAt(Count-1);
    PopDown(0);
    return result;
  }
}
