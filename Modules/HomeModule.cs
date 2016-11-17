using Nancy;
using AlbumList.Objects;
using System.Collections.Generic;

namespace AlbumList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        var allCategories = Category.GetAll();
        return View["index.cshtml", allCategories];
      };
      Get["/categories"] = _ => {
        var allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/new"] = _ => {
        return View["category_form.cshtml"];
      };
      Post["/categories"] = _ => {
        var newCategory = new Category (Request.Form["category-name"]);
        var allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedCategory = Category.Find(parameters.id);
        var categoryCDs = selectedCategory.GetCDs();
        model.Add("category", selectedCategory);
        model.Add("CDs", categoryCDs);
        return View["/category.cshtml", model];
      };
      Get["/categories/{id}/CDs/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<CD> allCDs = selectedCategory.GetCDs();
        model.Add("category", selectedCategory);
        model.Add("CDs", allCDs);
        return View["category_CDs_form.cshtml", model];
      };
      Post["/CDs"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(Request.Form["category-id"]);
        List<CD> categoryCDs = selectedCategory.GetCDs();
        string CDDescription = Request.Form["CD-description"];
        string CDArtist = Request.Form["CD-artist"];
        CD newCD = new CD(CDDescription, CDArtist);
        categoryCDs.Add(newCD);
        model.Add("CDs", categoryCDs);
        model.Add("category", selectedCategory);
        return View["category.cshtml", model];
      };
      Get["/search"] = _ => {
        return View["search.cshtml"];
      };
      Post["/searchResults"] = _ =>
      {
        string userInput = Request.Form["CD-search"];
        userInput = userInput.ToLower();
        System.Console.WriteLine(userInput);
        List<CD> results = new List<CD>();
        var allCategories = Category.GetAll();
        foreach (var category in allCategories)
        {
          System.Console.WriteLine("For each category");
          List<CD> allAlbums = category.GetCDs();
          foreach (var album in allAlbums)
          {
            System.Console.WriteLine("For each album");
            string artistName = album.GetArtist().ToLower();
            System.Console.WriteLine(artistName);
            System.Console.WriteLine(userInput);
            if (artistName.Contains(userInput))
            {
              System.Console.WriteLine("Album added");
              results.Add(album);
            }
          }
        }
        return View["resultPage.cshtml", results];
      };
    }
  }
}
