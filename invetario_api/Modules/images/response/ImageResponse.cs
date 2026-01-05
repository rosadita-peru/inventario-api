using System;

namespace invetario_api.Modules.images.response;

public class ImageResponse
{
    public int imageId { get; set; }

    public string imageName { get; set; }
    public string imageUrl { get; set; }

    public DateTime createdAt { get; set; } = DateTime.UtcNow;

    public static ImageResponse FromEntity(entity.Images image)
    {
        return new ImageResponse
        {
            imageId = image.imageId,
            imageUrl = image.imageUrl,
            createdAt = image.createdAt,
            imageName = image.imageName
        };
    }

    public static List<ImageResponse> FromEntityList(List<entity.Images> images)
    {
        return images.Select(image => FromEntity(image)).ToList();
    }
}
