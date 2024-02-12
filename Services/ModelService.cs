using Core.Application.Responses;
using System.Text.Json;
using WebUIBlazor.Models.ModelModels;

namespace WebUIBlazor.Services;

public class ModelService
{
    private readonly HttpClient _httpClient;

    public ModelService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetListResponse<ModelListItem>> GetModelsAsync(int pageIndex, int pageSize)
    {
        var response = await _httpClient.GetFromJsonAsync<GetListResponse<ModelListItem>>($"api/models?PageIndex={pageIndex}&PageSize={pageSize}");
        return response;
    }

    //public async Task<GetListResponse<ModelListItem>> GetModelsAsync(int pageIndex, int pageSize)
    //{
    //    var httpResponse = await _httpClient.GetAsync($"api/models?PageIndex={pageIndex}&PageSize={pageSize}");

    //    if (!httpResponse.IsSuccessStatusCode)
    //    {
    //        throw new HttpRequestException($"API request failed with status code: {httpResponse.StatusCode}");
    //    }

    //    var content = await httpResponse.Content.ReadAsStringAsync();

    //    try
    //    {
    //        var response = JsonSerializer.Deserialize<GetListResponse<ModelListItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    //        return response;
    //    }
    //    catch (JsonException ex)
    //    {
    //        throw new JsonException("Error deserializing API response", ex);
    //    }
    //}

}
