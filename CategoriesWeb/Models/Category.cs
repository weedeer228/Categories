namespace CategoriesWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [DisplayName(nameof(DisplayOrder))]
    [Range(1, 100, ErrorMessage = "Display order must be beetween 1 and 100")]
    public int DisplayOrder { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}
