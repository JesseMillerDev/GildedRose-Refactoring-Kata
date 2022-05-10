using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case "Aged Brie":
                        Items[i] = IncreaseQuality(Items[i]);
                        Items[i] = DecreaseSellIn(Items[i]);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        Items[i] = IncreaseQuality(Items[i]);
                        Items[i] = DecreaseSellIn(Items[i]);
                        break;
                    case "Conjured Mana Cake":
                        Items[i] = DecreaseQuality(Items[i]);
                        Items[i] = DecreaseSellIn(Items[i]);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        Console.WriteLine("Sulfuras, Hand of Ragnaros remains unchanged through the ages!");
                        break;
                    default:
                        Items[i] = DecreaseQuality(Items[i]);
                        Items[i] = DecreaseSellIn(Items[i]);
                        break;
                }
            }
        }

        private static Item DecreaseSellIn(Item item)
        {
            if (item.SellIn <= 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        item.Quality = DecreaseQuality(item).Quality;
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    IncreaseQuality(item);
                }
            }
            
            item.SellIn--;

            return item;
        }

        private static Item DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.Name == "Conjured Mana Cake" && item.Quality > 1)
                    item.Quality -= 2;
                else
                    item.Quality--;
            }

            return item;
        }

        private static Item IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                }
            }

            return item;
        }
    }
}
