using System.Xml.Serialization;
using SteamCommon;
using SteamCommon.Models;

namespace SteamCommonTests.UnitTests;

public class XmlHelperTests
{
    const string RawXml = @"<?xml version=""1.0""?>
    <OrderedItem xmlns:inventory=""http://www.cpandl.com"" xmlns:money=""http://www.cohowinery.com"">
        <inventory:ItemName>Widget</inventory:ItemName>
        <inventory:Description>Regular Widget</inventory:Description>
        <money:UnitPrice>2.3</money:UnitPrice>
        <inventory:Quantity>10</inventory:Quantity>
        <money:LineTotal>23</money:LineTotal>
    </OrderedItem>";

    [Fact]
    public void TestReadAs()
    {
        var item = XmlHelpers.ReadAs<OrderedItem>(RawXml);

        Assert.NotNull(item);
        Assert.True(item.ItemName == "Widget");
        Assert.True(item.Description == "Regular Widget");
        Assert.True(item.UnitPrice == (decimal)2.3);
        Assert.True(item.Quantity == 10);
    }
}

public class OrderedItem
{
    [XmlElement(Namespace = "http://www.cpandl.com")]
    public string ItemName;

    [XmlElement(Namespace = "http://www.cpandl.com")]
    public string Description;

    [XmlElement(Namespace = "http://www.cohowinery.com")]
    public decimal UnitPrice;

    [XmlElement(Namespace = "http://www.cpandl.com")]
    public int Quantity;

    [XmlElement(Namespace = "http://www.cohowinery.com")]
    public decimal LineTotal;

    // A custom method used to calculate price per item.
    public void Calculate()
    {
        LineTotal = UnitPrice * Quantity;
    }
}
