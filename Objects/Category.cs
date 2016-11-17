using System.Collections.Generic;

namespace AlbumList.Objects
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    private string _name;
    private int _id;
    private List<CD> _CDs;

    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _id = _instances.Count;
      _CDs = new List<CD>{};
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public List<CD> GetCDs()
    {
      return _CDs;
    }
    public void AddCD(CD CD)
    {
      _CDs.Add(CD);
    }
    public static List<Category> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
