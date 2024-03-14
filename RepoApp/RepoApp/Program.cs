using RepoApp;

var productRepo=new GenericRepository<Product>();

productRepo.Add(new Product { ID = 1, Name = "Banana", Price = 2 });
productRepo.Add(new Product { ID = 2, Name = "Pineapple", Price = 5 });

Console.WriteLine("The products are:");
foreach(var product in productRepo.GetAll())
{
    Console.WriteLine($"ID: {product.ID}, Name: {product.Name}, Price: {product.Price}");
}

var updatedProduct=productRepo.GetById(1);
if (productRepo != null) {
    updatedProduct.Name = "Celery";
    productRepo.Update(updatedProduct);
} else
{
    Console.WriteLine("Product not found");
}
Console.WriteLine("Updated Product is:");
Console.WriteLine($"ID: {productRepo.GetById(1).ID}, Name: {productRepo.GetById(1).Name}, Price {productRepo.GetById(1).Price}");
var deletedProduct = productRepo.GetById(2);
if (deletedProduct != null) { 
    productRepo.Delete(deletedProduct);
}
Console.WriteLine("After deleting the products are:");
foreach (var product in productRepo.GetAll())
{
    Console.WriteLine($"ID: {product.ID}, Name: {product.Name}, Price: {product.Price}");
}
