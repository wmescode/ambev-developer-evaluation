using Ambev.DeveloperEvaluation.Domain.Entities.External;

namespace Ambev.DeveloperEvaluation.ExternalServices.Mock
{
    /// <summary>
    /// Simulates an external repository
    /// </summary>
    public static class InMemoryDataStore
    {
        public static List<Product> Products = new List<Product>

        {
            new Product { Id = "656565656484564564156", Description = "Air Fryer 220v", Price = 599.45m },
            new Product { Id = "568998484894984984894", Description = "Fogão 5 Bocas", Price = 1299.12m },
            new Product { Id = "454564564654646546546", Description = "Geladeira 550L", Price = 3499.00m },
            new Product { Id = "929829823928329832983", Description = "Air Fryer 220v", Price = 599.85m },
            new Product { Id = "568998484894984984894", Description = "Fogão 5 Bocas", Price = 1299.00m },
            new Product { Id = "454564564654646546546", Description = "Ventilador de Teto", Price = 299.32m },
            new Product { Id = "123456789012345678901", Description = "Micro-ondas 32L", Price = 399.85m },
            new Product { Id = "987654321098765432109", Description = "Lava Louças 14 Pratos", Price = 1999.99m },
            new Product { Id = "425341264312481248914", Description = "Ar Condicionado 12.000 BTUs", Price = 4999.99m },
            new Product { Id = "222222222222222222222", Description = "Forno Elétrico 60L", Price = 699.99m },
            new Product { Id = "333333333333333333333", Description = "Liquidificador 500W", Price = 299.99m },
            new Product { Id = "444444444444444444444", Description = "Batedeira 300W", Price = 399.99m },
            new Product { Id = "555555555555555555555", Description = "Cafeteira 10 Xícaras", Price = 199.99m },
            new Product { Id = "666666666666666666666", Description = "Purificador de Água 12L", Price = 999.10m },
            new Product { Id = "777777777777777777777", Description = "Aspirador de Pó 1200W", Price = 499.66m },
            new Product { Id = "888888888888888888888", Description = "Secadora de Roupas 7Kg", Price = 1299.79m },
            new Product { Id = "999999999999999999999", Description = "Lava Roupas 12Kg", Price = 1499.71m },
            new Product { Id = "1010101010101010101010", Description = "Aquecedor de Água 80L", Price = 699.28m },
            new Product { Id = "1111111111111111111111", Description = "Ventilador 40cm", Price = 199.16m },
            new Product { Id = "1212121212121212121212", Description = "Aerofryer 5,5L", Price = 499.00m },
            new Product { Id = "1313131313131313131313", Description = "Sanduicheira Elétrica", Price = 299.57m },
        };

        public static List<Customer> Customers = new List<Customer>
        {
            new Customer { Id = "4218342183418243812", Name = "Tatiana Azevedo" },
            new Customer { Id = "9128312839128391283", Name = "Leandro Amaral" },
            new Customer { Id = "1232112321213221132", Name = "Cristina Correa" },
            new Customer { Id = "2351243514351243254", Name = "Carlos da Silva" },
            new Customer { Id = "6928391283912839292", Name = "José Nascimento" },
            new Customer { Id = "1231231231231231231", Name = "Maria de Souza" },
            new Customer { Id = "1231231231231231232", Name = "João Pereira" },
            new Customer { Id = "1231231231231231233", Name = "Pedro Santos" },
            new Customer { Id = "1231231231231231234", Name = "Ana Paula" },
            new Customer { Id = "1231231231231231235", Name = "Fernanda Lima" },
            new Customer { Id = "1231231231231231236", Name = "Ricardo Oliveira" },
            new Customer { Id = "1231231231231231237", Name = "Mariana Silva" },
            new Customer { Id = "1231231231231231238", Name = "Lucas Souza" },
            new Customer { Id = "1231231231231231239", Name = "Paulo Pereira" },
            new Customer { Id = "1231231231231231240", Name = "Roberto Santos" },
        };

        public static List<Branch> Branches = new List<Branch>
        {
            new Branch { Id = "1", Name = "Filial São Paulo - Zona Sul" },
            new Branch { Id = "2", Name = "Filial Barigui" },
            new Branch { Id = "3", Name = "Filial Blumenau Rua XV" },            
        };

    }


}
