using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void DefaultItem_DecreasesQualityAndSellin()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Common Turtle Shell", SellIn = 10, Quality = 50 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Common Turtle Shell", Items[0].Name);
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(49, Items[0].Quality);
        }
        [Fact]
        public void DefaultItem_QualityNotBelow0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Common Turtle Shell", SellIn = 10, Quality = 0 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Common Turtle Shell", Items[0].Name);
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }
        [Fact]
        public void DefaultItem_QualityDecreaseDoubleWhenSellInNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Common Turtle Shell", SellIn = -1, Quality = 20 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Common Turtle Shell", Items[0].Name);
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(18, Items[0].Quality);
        }


        [Fact]
        public void AgedBrie_IncreasesQualityAndDecreaseSellin()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(11, Items[0].Quality);
        }
        [Fact]
        public void AgedBrie_QualityNotOver50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(50, Items[0].Quality);
        }
        /// <summary>
        /// This test is here because I found the instructions slightly ambiguous. If you consider the Quality of Aged Brie to "Decrease Negatively" over time
        /// then the proper behaviour is that after Sellin is below 0 it should "Decrease Negatively" twice as fast so it should increase by 2 each day. I realize
        /// that this is potentially not the proper interpretation of these instructions but I thought it made sense. It is an easy fix otherwise.
        /// </summary>
        [Fact]
        public void AgedBrie_QualityIncreasesDoubleAfterSellin()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 20 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(22, Items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_IncreasesQualityAndDecreaseSellin()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 1 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(19, Items[0].SellIn);
            Assert.Equal(2, Items[0].Quality);
        }
        [Fact]
        public void BackstagePasses_IncreasesQualityDoubleAndDecreaseSellin()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 1 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(3, Items[0].Quality);
        }
        [Fact]
        public void BackstagePasses_IncreasesQualityTripleAndDecreaseSellin()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 1 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(4, Items[0].Quality);
        }
        [Fact]
        public void BackstagePasses_QualityUnder50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(50, Items[0].Quality);
        }
        [Fact]
        public void BackstagePasses_Quality0AfterSellin()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 49 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }


        [Fact]
        public void Conjured_DecreasesQualityDoubleAndDecreaseSellin()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 20, Quality = 20 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Conjured Mana Cake", Items[0].Name);
            Assert.Equal(19, Items[0].SellIn);
            Assert.Equal(18, Items[0].Quality);
        }
        [Fact]
        public void Conjured_QualityNeverBelow0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 1 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Conjured Mana Cake", Items[0].Name);
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }
        [Fact]
        public void Conjured_QualityDecreaseDoubleWhenSellinBelow0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 20 } };

            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal("Conjured Mana Cake", Items[0].Name);
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(16, Items[0].Quality);
        }
    }
}
