using System;
using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Dtos
{
    public record ItemDto(Guid Id, String Name, String Description, decimal Price, DateTimeOffset CreatedTime);


    public record CreateItemDto([Required] String Name, String Description, [Range(0, 1000)] decimal Price);


    public record UpdateItemDto(Guid Id, [Required] String Name, String Description, [Range(0, 1000)] decimal Price);
}

