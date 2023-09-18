using BookStore.Models;

namespace BookStore.DTOs;

/// <summary>
/// 
/// </summary>
public class CartItemsDto
{
    /// <summary>
    /// 
    /// </summary>
    public List<CartItem>? Items {  get; set; }
}