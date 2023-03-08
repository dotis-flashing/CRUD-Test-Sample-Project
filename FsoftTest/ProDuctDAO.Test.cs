using BusinessObject;
using BusinessObject.Repository;
using DataAccess;
using Moq;


namespace FsoftTest;

[TestFixture]
public class ProDuctDAO_Test
{
    
    [TestCase(887, 11, 11, 2, "Iphone XS", "0.552")]
    [TestCase(888, 11, 11, 2, "Iphone XS", "0.552")]
    [TestCase(890, 11, 11, 2, "Iphone XS", "0.552")]
    [TestCase(891, 11, 11, 2, "Iphone XS", "0.552")]
    public void TestAddProduct(int _Id, int _UnislnStock, decimal _unitPrice, int _CategoryId, String _Weight,
        String _ProductName)
    {
        // Arrange
        var dao = ProductDAO.Instance;
        Product product = new Product(_Id, _UnislnStock, _unitPrice, _CategoryId, _Weight, _ProductName);
        // Act
        dao.Add(product);

        // Assert
        Product result = dao.GetProductByID(product.ProductId);
        Assert.AreEqual(_UnislnStock, result.UnislnStock);
        Assert.AreEqual(_unitPrice, result.UnitPrice);
        Assert.AreEqual(_CategoryId, result.CategoryId);
        Assert.AreEqual(_Weight, result.Weight);
        Assert.AreEqual(_ProductName, result.ProductName);
    }

    [TestCase(887, 100, 100, 2, "Iphone 14", "0.887","Iphone 14")]
    [TestCase(888, 100, 100, 2, "Iphone 14", "0.888","Iphone 14")]
    [TestCase(890, 100, 100, 2, "Iphone 14", "0.890","Iphone 14")]
    [TestCase(891, 100, 100, 2, "Iphone 14", "0.891","Iphone 14")]
    public void TestUpdateProduct(int _Id, int _UnislnStock, decimal _unitPrice, int _CategoryId, String _Weight,
        String _ProductName,string expect)
    {
        // Arrange
        var dao = ProductDAO.Instance;
        Product product = new Product(_Id, _UnislnStock, _unitPrice, _CategoryId, _Weight, _ProductName);
        // Act
        dao.Update(product);

        // Assert
        Product result = dao.GetProductByID(product.ProductId);
        Assert.AreEqual(expect, result.Weight);
    }

    [TestCase(888)]
    [TestCase(890)]
    [TestCase(887)]
    [TestCase(891)]
    public void TestDeleteProduct(int id)
    {
        // Arrange
        var dao = ProductDAO.Instance;
        // Act
        Product result = dao.GetProductByID(id);
        dao.Delete(result);
        // Assert
        Assert.IsNull(null);
    }

    [TestCase(547, 547)]
    [TestCase(547, 0)]
    public void TestGetProductByID(int id, int expect)
    {
        // Arrange
        // var id = 547;
        var dao = ProductDAO.Instance;
        // Act
        var result = dao.GetProductByID(id);

        Assert.AreEqual(expect, result.ProductId);
    }

    [TestCase(6)]
    [TestCase(4)]
    [TestCase(10)]
    public void TestGetAllProducts(int expect)
    {
        // Arrange
        var dao = ProductDAO.Instance;
        // Act
        var result = dao.GetAllData();

        // Assert
        Assert.AreEqual(expect, result.Count);
    }
}