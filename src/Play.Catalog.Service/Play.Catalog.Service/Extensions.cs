using System;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service
{
	public static class Extensions
	{
		public static ItemDto AsDto(this Item ItemDto)
		{
			return new ItemDto(ItemDto.Id, ItemDto.Name, ItemDto.Description, ItemDto.Price, ItemDto.CreatedTime);
		}
	}
}

