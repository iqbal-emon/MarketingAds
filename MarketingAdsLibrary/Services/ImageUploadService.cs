using MarketingAds.Data;
using MarketingAds.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

public class ImageUploadService
{
    private readonly HttpClient _httpClient;
    private readonly Marketing _dbContext;

    public ImageUploadService(HttpClient httpClient, Marketing dbContext)
    {
        _httpClient = httpClient;
        _dbContext = dbContext;
    }

    public async Task<string> UploadImage(Stream fileStream, string fileName)
    {
        var form = new MultipartFormDataContent();
        form.Add(new StreamContent(fileStream), "image", fileName); 

        var response = await _httpClient.PostAsync("https://localhost:7235/api/Image/upload", form);

        if (response.IsSuccessStatusCode)
        {
            var imagePath = await response.Content.ReadAsStringAsync();
            return imagePath;
        }
        else
        {
            throw new HttpRequestException($"Failed to upload image: {response.StatusCode}");
        }
    }
    public async Task DeleteImage(string imageName)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7235/api/Product/delete/{imageName}");
            response.EnsureSuccessStatusCode(); 
                                               
        }
        catch (HttpRequestException ex)
        {
            // Handle exception
            Console.WriteLine($"Error deleting image: {ex.Message}");
        }
    }


    public async Task<Image>GetImagePath(int ListinId)
    {

        return await _dbContext.Images.FirstOrDefaultAsync(I => I.ListingID == ListinId);
    }
    public async Task<bool> UpdateImage(Image image)
    {
        var existingImage = await _dbContext.Images.FirstOrDefaultAsync(I => I.ListingID == image.ListingID);

        if (existingImage != null)
        {
            existingImage.ImageURL = image.ImageURL;
            _dbContext.Images.Update(existingImage);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

}
