using MrFamilyTree.Models;

namespace Admin.Tests;

public class ModelTests
{
    [Fact]
    public void Person_HasCorrectDefaults()
    {
        var person = new Person();
        Assert.Equal(0, person.Id);
        Assert.False(person.Enabled);
        Assert.False(person.EnabledInWeb);
        Assert.Equal(string.Empty, person.FirstNames);
        Assert.Equal(string.Empty, person.LastName);
    }

    [Fact]
    public void Article_HasCorrectDefaults()
    {
        var article = new Article();
        Assert.Equal(0, article.Id);
        Assert.False(article.Enabled);
        Assert.False(article.EnabledInWeb);
        Assert.Equal(string.Empty, article.Name);
        Assert.Equal(string.Empty, article.Description);
        Assert.Equal(string.Empty, article.Text);
    }

    [Fact]
    public void Keyword_HasCorrectDefaults()
    {
        var keyword = new Keyword();
        Assert.Equal(0, keyword.Id);
        Assert.False(keyword.Enabled);
        Assert.False(keyword.EnabledInWeb);
        Assert.Equal(string.Empty, keyword.Name);
        Assert.Equal(string.Empty, keyword.Description);
    }

    [Fact]
    public void Image_HasCorrectDefaults()
    {
        var image = new Image();
        Assert.Equal(0, image.Id);
        Assert.False(image.Enabled);
        Assert.False(image.EnabledInWeb);
        Assert.Equal(string.Empty, image.Url);
        Assert.Equal(string.Empty, image.Description);
    }

    [Fact]
    public void BirthParish_HasCorrectDefaults()
    {
        var bp = new BirthParish();
        Assert.Equal(0, bp.Id);
        Assert.False(bp.Enabled);
        Assert.False(bp.EnabledInWeb);
        Assert.Equal(string.Empty, bp.Names);
    }

    [Fact]
    public void Message_HasCorrectDefaults()
    {
        var msg = new Message();
        Assert.Equal(string.Empty, msg.ClientUniqueId);
        Assert.Equal(string.Empty, msg.Type);
        Assert.Equal(string.Empty, msg.Content);
    }

    [Fact]
    public void WeatherForecast_CalculatesTemperatureF()
    {
        var forecast = new MrFamilyTree.WeatherForecast { TemperatureC = 0 };
        Assert.Equal(32, forecast.TemperatureF);

        forecast.TemperatureC = 100;
        // The formula uses integer truncation: 32 + (int)(100 / 0.5556) = 211
        Assert.Equal(211, forecast.TemperatureF);
    }
}
