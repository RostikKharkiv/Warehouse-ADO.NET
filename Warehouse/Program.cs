using System;
using System.Collections.Generic;
using Warehouse.DAO;
using Warehouse.Models;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Provider.CountId = 1000;
            Product.CountId = 1000;

            string provider = "Поставщик1";
            ProviderLogic providers = new ProviderLogic();
            providers.AddProvider(provider);
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Выберите действие:" +
                "\n1)Просмотреть все товары на складе" +
                "\n2)Добавить новый товар на склад" +
                "\n3)Найти товар по Id" +
                "\n4)Найти товар по названию" +
                "\n5)Найти товары по количеству" +
                "\n6)Удалить товар по Id" +
                "\n7)Изменить товар по Id" +
                "\n\n8)Просмотреть всех поставщиков" +
                "\n9)Добавить поставщика" +
                "\n10)Найти поставщика по Id" +
                "\n11)Найти поставщика по названию" +
                "\n12)Удалить поставщика по Id" +
                "\n13)Изменить поставщика по Id" +
                "\n\n0)Очистить вывод в консоль" +
                "\n99)Завершить программу");

            string symbol = Console.ReadLine();

            ProductLogic products = new ProductLogic();
            ProviderLogic providers = new ProviderLogic();

            switch(symbol)
            {
                case "0":
                    Console.Clear();
                    Menu();
                    break;
                case "99":
                    break;
                case "1":
                    products.ShowAll();
                    Console.WriteLine();
                    Menu();
                    break;
                case "2":
                    Console.Write("Введите название товара: ");
                    string name = Console.ReadLine();

                    Console.Write("Введите Id поставщика: ");
                    int idProvider = int.Parse(Console.ReadLine());

                    Console.Write("Введите категорию товара: ");
                    string category = Console.ReadLine();

                    Category categoryToAdd = new Category();
                    if (category.ToLower().Equals("furniture"))
                        categoryToAdd = Category.Furniture;
                    else if (category.ToLower().Equals("decor"))
                        categoryToAdd = Category.Decor;
                    else if (category.ToLower().Equals("lighting"))
                        categoryToAdd = Category.Lighting;
                    else 
                        categoryToAdd = Category.None;

                    Console.Write("Введите стоимость товара: ");
                    double cost = double.Parse(Console.ReadLine());

                    Console.Write("Введите количество товара: ");
                    int count = int.Parse(Console.ReadLine());

                    products.AddProduct(name, idProvider, categoryToAdd, cost, count);
                    Console.WriteLine("Товар успешно добавлен!");
                    Console.WriteLine();
                    Menu();
                    break;
                case "3":
                    Console.Write("Введите Id товара: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine(products.FindProductByID(id));
                    Console.WriteLine();
                    Menu();
                    break;
                case "4":
                    Console.Write("Введите название товара: ");
                    string nameProduct = Console.ReadLine();

                    List <Product> productListByName = products.FindByProductName(nameProduct);

                    foreach (var product in productListByName)
                    {
                        Console.WriteLine(product);
                    }
                    Console.WriteLine();
                    Menu();
                    break;
                case "5":
                    Console.Write("Введите количество товара: ");
                    int countProduct = int.Parse(Console.ReadLine());

                    List<Product> productByCount = products.FindProductByCount(countProduct);

                    foreach (var product in productByCount)
                    {
                        Console.WriteLine(product);
                    }

                    Console.WriteLine();
                    Menu();
                    break;
                case "6":
                    Console.Write("Введите Id товара: ");
                    int idProduct = int.Parse(Console.ReadLine());

                    products.RemoveByID(idProduct);
                    Console.WriteLine("Товар успешно удалён!");
                    Console.WriteLine();
                    Menu();
                    break;
                case "7":
                    Console.Write("Введите Id товара: ");
                    idProduct = int.Parse(Console.ReadLine());

                    Console.Write("Введите название товара: ");
                    name = Console.ReadLine();

                    Console.Write("Введите Id поставщика: ");
                    idProvider = int.Parse(Console.ReadLine());

                    Console.Write("Введите категорию товара: ");
                    category = Console.ReadLine();

                    categoryToAdd = new Category();
                    if (category.ToLower().Equals("furniture"))
                        categoryToAdd = Category.Furniture;
                    else if (category.ToLower().Equals("decor"))
                        categoryToAdd = Category.Decor;
                    else if (category.ToLower().Equals("lighting"))
                        categoryToAdd = Category.Lighting;
                    else
                        categoryToAdd = Category.None;

                    Console.Write("Введите стоимость товара: ");
                    cost = double.Parse(Console.ReadLine());

                    Console.Write("Введите количество товара: ");
                    count = int.Parse(Console.ReadLine());

                    products.UpdateById(idProduct, name, idProvider, categoryToAdd, cost, count);
                    Console.WriteLine("Товар успешно обновлён!");
                    Console.WriteLine();
                    Menu();
                    break;
                case "8":
                    providers.ShowAll();
                    Console.WriteLine();
                    Menu();
                    break;
                case "9":
                    Console.Write("Введите название поставщика: ");
                    string provider = Console.ReadLine();
                    providers.AddProvider(provider);
                    Console.WriteLine("Поставщик был успешно добавлен");
                    Console.WriteLine();
                    Menu();
                    break;
                case "10":
                    Console.Write("Введите Id поставщика: ");
                    idProvider = int.Parse(Console.ReadLine());
                    Console.WriteLine(providers.FindProviderByID(idProvider));
                    Console.WriteLine();
                    Menu();
                    break;
                case "11":
                    Console.Write("Введите название поставщика: ");
                    string nameProvider = Console.ReadLine();
                    Console.WriteLine(providers.FindByProviderName(nameProvider));
                    Console.WriteLine();
                    Menu();
                    break;
                case "12":
                    Console.Write("Введите Id поставщика: ");
                    idProvider = int.Parse(Console.ReadLine());
                    providers.RemoveByID(idProvider);

                    Console.WriteLine("Поставщик успешно удалён");
                    Console.WriteLine();
                    Menu();
                    break;
                case "13":
                    Console.Write("Введите Id поставщика: ");
                    idProvider = int.Parse(Console.ReadLine());
                    Console.Write("Введите название поставщика: ");
                    nameProvider = Console.ReadLine();

                    providers.UpdateById(idProvider, nameProvider);

                    Console.WriteLine("Поставщик успешно обновлён");
                    Console.WriteLine();
                    Menu();
                    break;
            }
        }
    }
}
