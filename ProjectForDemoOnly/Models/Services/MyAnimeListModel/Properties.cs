using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;

public class Properties
{
    // Thuộc tính này nhận giá trị từ JSON (có thể là string hoặc object)
    [JsonProperty("studio")]
    private JToken studioToken { get; set; }

    // Thuộc tính chính, sẽ được gán giá trị sau khi xử lý trong OnDeserialized
    [JsonIgnore]
    public Studio studio { get; set; } = null;

    public string source { get; set; } = null;
    public Themes themes { get; set; } = null;
    public Demographic demographic { get; set; } = null;
    public Theme theme { get; set; } = null;
    public Studios studios { get; set; } = null;
    public Demographics demographics { get; set; } = null;

    [OnDeserialized]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        if (studioToken != null)
        {
            // Nếu token là chuỗi và bằng "Unknow" (không phân biệt chữ hoa chữ thường)
            if (studioToken.Type == JTokenType.String &&
                studioToken.ToString().Equals("Unknow", StringComparison.OrdinalIgnoreCase))
            {
                studio = null;
            }
            // Nếu token là object thì deserialize bình thường
            else if (studioToken.Type == JTokenType.Object)
            {
                studio = studioToken.ToObject<Studio>();
            }
            else
            {
                // Trong trường hợp khác, có thể xử lý tùy theo yêu cầu
                studio = null;
            }
        }
    }
}
