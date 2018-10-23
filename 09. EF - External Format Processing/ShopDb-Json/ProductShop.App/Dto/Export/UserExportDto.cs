namespace ProductShop.App.Dto.Export
{
    using System.Collections;
    using System.Collections.Generic;

    public class UserExportDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public SoldProductsDto[] SoldProducts { get; set; } 
    }
}
