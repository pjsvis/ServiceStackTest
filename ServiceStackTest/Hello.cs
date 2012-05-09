using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ServiceStack.ServiceHost;

namespace ServiceStackTest
{

    #region Hello

    public class Hello
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }

    public class HelloService : IService<Hello>
    {
        #region IService<Hello> Members

        public object Execute(Hello request)
        {
            return new HelloResponse {Result = "Hello, " + request.Name};
        }

        #endregion
    }

    #endregion

    #region Product

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductResponse
    {
        public Product Result { get; set; }
    }

    public class ProductService : IService<Product>
    {
        #region IService<Product> Members

        public object Execute(Product request)
        {
            using (var conn = Dal.OpenConnection("SportStore"))
            {
                const string sql = "select * from products where productid=@ProductId";
                return conn.Query<Product>(sql, new {request.ProductId}).First();
            }
        }

        #endregion      
    }

    #endregion

    #region Dog

    public class Dog
    {
        public int? Age { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }

        public int IgnoredProperty
        {
            get { return 1; }
        }
    }

    public class DogResponse
    {
        public Dog Result { get; set; }
    }

    public class DogService : IService<Dog>
    {
        #region IService<Dog> Members

        public object Execute(Dog request)
        {
            var dog = new Dog {Age = 10, Name = "Fido", Weight = 4};

            return new DogResponse {Result = dog};
        }

        #endregion
    }

    #endregion
}