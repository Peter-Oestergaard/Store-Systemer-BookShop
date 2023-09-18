using BookStore.DTOs;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CartController : ControllerBase
{
    /// <summary>
    /// Get user cart
    /// </summary>
    /// <param name="id">Id of cart to get</param>
    /// <returns>A cart</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Cart), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCart(int id)
    {
        return id == 0 ? NotFound() : Ok(new Cart());
    }

    /// <summary>
    /// Put items in cart
    /// </summary>
    /// <param name="id">Id of cart to put items into</param>
    [HttpPost("{id}/items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PutItemsInCart(int id, [FromBody] CartItemsDto items)
    {
        return Ok(id);
    }

    /// <summary>
    /// Update item in cart
    /// </summary>
    /// <param name="cartId">Id of cart with item to update</param>
    /// <param name="itemId">Id of item to update</param>
    /// <param name="itemData">JSON with item data</param>
    [HttpPut("{cartId}/items/{itemId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetItemsInCart(int cartId, int itemId, [FromBody] CartItemDto itemData)
    {
        return Ok();
    }

    /// <summary>
    /// Delete item from cart
    /// </summary>
    /// <param name="cartId">Id of cart with item to delete</param>
    /// <param name="itemId">Id of item to delete</param>
    [HttpDelete("{cartId}/items/{itemId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteItemFromCart(int cartId, int itemId)
    {
        return Ok();
    }
}
