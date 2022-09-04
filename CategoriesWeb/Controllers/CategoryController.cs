namespace CategoriesWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        return View(_db.Categories);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
            ModelState.AddModelError("name", "The Display order cannot be equal name");
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "category create succefully";
        }
        return RedirectToAction(nameof(Index));
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id is null || id <= 0) return NotFound();
        var category = _db.Categories.Find(id);
        if (category is null) return NotFound();
        return View(category);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
            ModelState.AddModelError("name", "The Display order cannot be equal name");
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "category updated succefully";

        }
        return RedirectToAction(nameof(Index));
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id is null || id <= 0) return NotFound();
        var category = _db.Categories.Find(id);
        if (category is null) return NotFound();
        return View(category);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        if (id is null || id <= 0) return NotFound();
        var obj = _db.Categories.Find(id);
        if (obj is null) return NotFound();
        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "category deleted succefully";


        return RedirectToAction(nameof(Index));
    }


}
