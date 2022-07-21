using Microsoft.AspNetCore.Mvc;

namespace TriangleFinder.Controllers;

[ApiController]
[Route("[controller]")]
public class TriangleFinderController : ControllerBase
{
  

    private readonly ILogger<TriangleFinderController> _logger;

    public TriangleFinderController(ILogger<TriangleFinderController> logger)
    {
        _logger = logger;
    }



    /// <summary>
    /// webApi to return triangle label based on the coordinate
    /// </summary>
    /// <param name="v1x"></param>
    /// <param name="v1y"></param>
    /// <param name="v2x"></param>
    /// <param name="v2y"></param>
    /// <param name="v3x"></param>
    /// <param name="v3y"></param>
    /// <returns></returns>

    [HttpGet]
    [Route("getTriangleLabel")]
    public Triangle getTriangleLabel(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
    {
        TriangleMapper mapper = new TriangleMapper(new Triangle(v1x, v1y, v2x, v2y, v3x, v3y));
        return mapper.mapbyCoordinates();
    }
    /// <summary>
    /// webApi to return triangle vertices based on the triangle label
    /// </summary>
    /// <param name="triableLabel"></param>
    /// <returns></returns>

    [HttpGet]
    [Route("getTriangleCoordinates")]
    public Triangle getTriangleCoordinates(string triangleLabel)
    {
        if (String.IsNullOrEmpty(triangleLabel))
        {
            throw new ArgumentException("Label cannot be empty or null");
        }
        Console.WriteLine(triangleLabel);
        TriangleMapper mapper = new TriangleMapper(new Triangle(triangleLabel));


        return mapper.mapbyLabel();
    }


}

