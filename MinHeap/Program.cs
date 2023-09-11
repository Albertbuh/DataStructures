MinHeap heap = new MinHeap(new int[] {-3, 5, 6, 1, -2});

while(heap.Peek() != null)
{
  Console.WriteLine(heap.GetMin());
}
