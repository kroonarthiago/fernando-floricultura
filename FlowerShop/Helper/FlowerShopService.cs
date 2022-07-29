using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerShop.Models.Entity;

namespace FlowerShop.Helper
{
    public class FlowerShopService
    {
        public class Customer
        {
            public CustomerModel Get(int CustomerId)
            {
                var CustomerModel = new CustomerModel();
                try
                {

                    using (var Context = new FlowerShopEntities())
                    {
                        var Customer = Context.Customer.FirstOrDefault(f => f.Id == CustomerId);

                        if (Customer == null)
                            throw new Exception("Ocorreu um erro ao requisitar os dados de usuário.");

                        CustomerModel.Id = Customer.Id;
                        CustomerModel.Name = Customer.Name;
                        CustomerModel.Rg = Customer.Rg;
                        CustomerModel.Phone = Customer.Phone;
                        CustomerModel.StreetName = Customer.StreetName;
                        CustomerModel.HouseNumber = Customer.HouseNumber;

                    }
                }
                catch (Exception Ex)
                {
                    CustomerModel.Id = -1;
                }

                return CustomerModel;
            }

            public bool Update(CustomerModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities() )
                    {
                        var Entity = Context.Customer.FirstOrDefault(f => f.Id == Request.Id);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Entity.Name = Request.Name;
                        Entity.Rg = Request.Rg;
                        Entity.Phone = Request.Phone;
                        Entity.StreetName = Request.StreetName;
                        Entity.HouseNumber = Request.HouseNumber;

                        Response = true;

                        Context.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public bool Add(CustomerModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {

                        var NewCustomer = new Models.Entity.Customer
                        {
                            Name = Request.Name,
                            Rg = Request.Rg,
                            Phone = Request.Phone,
                            StreetName = Request.StreetName,
                            HouseNumber = Request.HouseNumber
                        };

                        Context.Customer.Add(NewCustomer);

                        Context.SaveChanges();

                        Response = true;

                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public List<CustomerModel> List()
            {
                var Response = new List<CustomerModel>();

                using (var Context = new FlowerShopEntities())
                {
                    Response = Context
                                .Customer
                                .Select(s => new CustomerModel
                                {
                                    Id = s.Id,
                                    Name = s.Name,
                                    Rg = s.Rg,
                                    Phone = s.Phone,
                                    StreetName = s.StreetName,
                                    HouseNumber = s.HouseNumber
                                }).ToList();
               
                }

                return Response;
            }

            public bool Remove(int CustomerId)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {
                        var Entity = Context.Customer.FirstOrDefault(f => f.Id == CustomerId);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");


                        Context.Customer.Remove(Entity);

                        Context.SaveChanges();

                        Response = true;
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }
        }

        public class Order
        {
            public OrderModel Get(int OrderId)
            {
                var OrderModel = new OrderModel();
                try
                {

                    using (var Context = new FlowerShopEntities())
                    {
                        var Order = Context.Order.FirstOrDefault(f => f.Id == OrderId);

                        if (Order == null)
                            throw new Exception("Ocorreu um erro ao requisitar os dados de usuário.");

                        OrderModel.Id = Order.Id;
                        OrderModel.CustomerId = Order.CustomerId;
                        OrderModel.PurchaseDate = Order.PurchaseDate;
                        OrderModel.TotalPrice = Order.TotalPrice;

                    }
                }
                catch (Exception Ex)
                {
                    OrderModel.Id = -1;
                }

                return OrderModel;
            }

            public bool Update(OrderModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities() )
                    {
                        var Entity = Context.Order.FirstOrDefault(f => f.Id == Request.Id);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Entity.CustomerId = Request.CustomerId;
                        Entity.PurchaseDate = Request.PurchaseDate;
                        Entity.TotalPrice = Request.TotalPrice;

                        Response = true;

                        Context.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public bool Add(OrderModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {

                        var NewOrder = new Models.Entity.Order
                        {
                            CustomerId = Request.CustomerId,
                            PurchaseDate = Request.PurchaseDate,
                            TotalPrice = Request.TotalPrice,
                        };

                        Context.Order.Add(NewOrder);

                        Context.SaveChanges();

                        Response = true;

                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public List<OrderModel> List()
            {
                var Response = new List<OrderModel>();

                using (var Context = new FlowerShopEntities())
                {
                    Response = Context
                                .Order
                                .Select(s => new OrderModel
                                {
                                    Id = s.Id,
                                    CustomerId = s.CustomerId,
                                    PurchaseDate = s.PurchaseDate,
                                    TotalPrice = s.TotalPrice,
                                }).ToList();

                }

                return Response;
            }

            public bool Remove(int OrderId)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {
                        var Entity = Context.Order.FirstOrDefault(f => f.Id == OrderId);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");


                        Context.Order.Remove(Entity);

                        Context.SaveChanges();

                        Response = true;
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }
        }

        public class Product
        {
            public ProductModel Get(int ProductId)
            {
                var ProductModel = new ProductModel();
                try
                {

                    using (var Context = new FlowerShopEntities())
                    {
                        var Product = Context.Product.FirstOrDefault(f => f.Id == ProductId);

                        if (Product == null)
                            throw new Exception("Ocorreu um erro ao requisitar os dados de usuário.");

                        ProductModel.Id = Product.Id;
                        ProductModel.Name = Product.Name;
                        ProductModel.Type = Product.Type;
                        ProductModel.Price = Product.Price;
                        ProductModel.Quantity = Product.Quantity;

                    }
                }
                catch (Exception Ex)
                {
                    ProductModel.Id = -1;
                }

                return ProductModel;
            }

            public bool Update(ProductModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {
                        var Entity = Context.Product.FirstOrDefault(f => f.Id == Request.Id);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Entity.Name = Request.Name;
                        Entity.Type = Request.Type;
                        Entity.Price = Request.Price;
                        Entity.Quantity = Request.Quantity;

                        Response = true;

                        Context.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public bool Add(ProductModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {

                        var NewProduct = new Models.Entity.Product
                        {
                            Name = Request.Name,
                            Type = Request.Type,
                            Price = Request.Price,
                            Quantity = Request.Quantity,
                        };

                        Context.Product.Add(NewProduct);

                        Context.SaveChanges();

                        Response = true;

                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public List<ProductModel> List()
            {
                var Response = new List<ProductModel>();

                using (var Context = new FlowerShopEntities())
                {
                    Response = Context
                                .Product
                                .Select(s => new ProductModel
                                {
                                    Id = s.Id,
                                    Name = s.Name,
                                    Type = s.Type,
                                    Price = s.Price,
                                    Quantity = s.Quantity,
                                }).ToList();

                }

                return Response;
            }

            public bool Remove(int ProductId)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {
                        var Entity = Context.Product.FirstOrDefault(f => f.Id == ProductId);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");


                        Context.Product.Remove(Entity);

                        Context.SaveChanges();

                        Response = true;
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }
        }

        public class Order_Product
        {
            public Order_ProductModel Get(int Order_ProductId)
            {
                var Order_ProductModel = new Order_ProductModel();
                try
                {

                    using (var Context = new FlowerShopEntities())
                    {
                        var Order_Product = Context.Order_Product.FirstOrDefault(f => f.Id == Order_ProductId);

                        if (Order_Product == null)
                            throw new Exception("Ocorreu um erro ao requisitar os dados de usuário.");

                        Order_ProductModel.Id = Order_Product.Id;
                        Order_ProductModel.OrderId = Order_Product.OrderId;
                        Order_ProductModel.ProductId = Order_Product.ProductId;

                    }
                }
                catch (Exception Ex)
                {
                    Order_ProductModel.Id = -1;
                }

                return Order_ProductModel;
            }

            public bool Update(Order_ProductModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {
                        var Entity = Context.Order_Product.FirstOrDefault(f => f.Id == Request.Id);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Entity.OrderId = Request.OrderId;
                        Entity.ProductId = Request.ProductId;

                        Response = true;

                        Context.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public bool Add(Order_ProductModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {

                        var NewOrder_Product = new Models.Entity.Order_Product
                        {
                            OrderId = Request.OrderId,
                            ProductId = Request.ProductId,

                        };

                        Context.Order_Product.Add(NewOrder_Product);

                        Context.SaveChanges();

                        Response = true;

                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public List<Order_ProductModel> List()
            {
                var Response = new List<Order_ProductModel>();

                using (var Context = new FlowerShopEntities())
                {
                    Response = Context
                                .Order_Product
                                .Select(s => new Order_ProductModel
                                {
                                    Id = s.Id,
                                    OrderId = s.OrderId,
                                    ProductId = s.ProductId,
                                }).ToList();

                }

                return Response;
            }

            public bool Remove(int Order_ProductId)
            {
                var Response = false;

                try
                {
                    using (var Context = new FlowerShopEntities())
                    {
                        var Entity = Context.Order_Product.FirstOrDefault(f => f.Id == Order_ProductId);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");


                        Context.Order_Product.Remove(Entity);

                        Context.SaveChanges();

                        Response = true;
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }

                return Response;
            }
        }
    }
}