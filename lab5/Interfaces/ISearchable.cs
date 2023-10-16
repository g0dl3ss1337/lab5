namespace lab5;
public interface ISearchable
{
    List<Product> SearchByPrice(double minPrice, double maxPrice);
    List<Product> SearchByCategory(string category);
    List<Product> SearchByRating(double minRating);
}

