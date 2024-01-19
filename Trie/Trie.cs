namespace MyDataStructures.Trie;

public class Trie
{
  private TrieNode root;
  public Trie()
  {
    root = new TrieNode();
  }

  public void Insert(string word)
  {
    var cur = root;
    foreach(var c in word)
    {
      if(!cur.childrenMap.ContainsKey(c))
        cur.childrenMap.Add(c, new TrieNode());
      
      cur = cur.childrenMap[c];
    }
    cur.isMarked = true;
  }

  public bool Search(string word)
  {
    var node = Traverse(word);
    return node != null && node.isMarked;
  }

  public bool StartsWith(string prefix)
  {
    var node = Traverse(prefix);
    return node != null;
  }

  private TrieNode? Traverse(string word)
  {
    var cur = root;
    foreach(var c in word)
    {
      if(cur.childrenMap.ContainsKey(c))
        cur = cur.childrenMap[c];
      else 
        return null;
    }
    return cur;
  }
}

public class TrieNode
{
  public Dictionary<char, TrieNode> childrenMap {get; set;}
  public bool isMarked {get; set;} 
  public TrieNode()
  {
    childrenMap = new Dictionary<char, TrieNode>();
    isMarked = false;
  }
}

