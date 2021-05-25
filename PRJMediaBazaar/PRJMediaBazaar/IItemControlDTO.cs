using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Logic;


namespace PRJMediaBazaar
{
    interface IItemControlDTO
    {
        Item GetItemByIdAndName(String idAndName);

        List<Item> GetItems();

        bool UpdateInStockQuantity(String column, int inStock, int itemID );
    }
}
