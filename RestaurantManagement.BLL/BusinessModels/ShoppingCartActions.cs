using Microsoft.AspNetCore.Http;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.BusinessModels
{
    public class ShoppingCartActions 
    {
        //public string ShoppingCartId { get; set; }

        //private readonly ProjectContext db;
        //public ShoppingCartActions(ProjectContext db)
        //{
        //    this.db = db;
        //}
        //public const string CartSessionKey = "CartId";

        //public void AddToCart(int id)
        //{
        //    // Retrieve the product from the database.           
        //    ShoppingCartId = GetCartId();

        //    var cartItem = db.ShoppingCartItems.SingleOrDefault(
        //        c => c.CartId == ShoppingCartId
        //        && c.MealId == id);
        //    if (cartItem == null)
        //    {
        //        // Create a new cart item if no cart item exists.                 
        //        cartItem = new CartItem
        //        {
        //            ItemId = Guid.NewGuid().ToString(),
        //            MealId = id,
        //            CartId = ShoppingCartId,
        //            Meal = db.Meals.SingleOrDefault(
        //           p => p.MealId == id),
        //            Quantity = 1,
        //            DateCreated = DateTime.Now
        //        };

        //        db.ShoppingCartItems.Add(cartItem);
        //    }
        //    else
        //    {
        //        // If the item does exist in the cart,                  
        //        // then add one to the quantity.                 
        //        cartItem.Quantity++;
        //    }
        //    db.SaveChanges();
        //}

       

        //public string GetCartId()
        //{
        //    if (HttpContext.Current.Session[CartSessionKey] == null)
        //    {
        //        if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
        //        {
        //            HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
        //        }
        //        else
        //        {
        //            // Generate a new random GUID using System.Guid class.     
        //            Guid tempCartId = Guid.NewGuid();
        //            HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
        //        }
        //    }
        //    return HttpContext.Current.Session[CartSessionKey].ToString();
        //}

        //public List<CartItem> GetCartItems()
        //{
        //    ShoppingCartId = GetCartId();

        //    return db.ShoppingCartItems.Where(
        //        c => c.CartId == ShoppingCartId).ToList();
        //}
    }
}
