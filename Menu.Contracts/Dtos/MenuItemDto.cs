﻿namespace Menu.Contracts.Dtos;

public class MenuItemDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; }

    public List<MenuModificationDto> MenuModifications { get; set; }

}