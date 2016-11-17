using System.Collections.Generic;

namespace AlbumList.Objects
{
  public class CD
  {
    private string _description;
    private string _artist;
    private int _id;
    private static List<CD> _instances = new List<CD> {};

    public CD (string description, string artist)
    {
      _description = description;
      _artist = artist;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetArtist() {
      return _artist;
    }
    public void SetArtist(string artist) {
      _artist = artist;
    }

    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }

    public int GetId()
    {
      return _id;
    }
    public static List<CD> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static CD Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
