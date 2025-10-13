using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrappers.Page
{
    public class ShopPage
    {
        private readonly string ButtonAddToCartLocatorFormat = "//a[contains(text(),'{0}')]/ancestor::div[@class='inventory_item_description']//button[contains(@data-test,'add-to-cart')]";

    }
}
