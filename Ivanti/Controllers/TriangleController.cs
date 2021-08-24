using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ivanti.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        const int F = 70;
        [Route("GetTriangleCoordinates")]
        [HttpGet]
        public TriangleCoordinates GetTriangleCoordinates(string triangle) {
            if (triangle == null)
            {
                return null;
            }
           var row = Encoding.ASCII.GetBytes(triangle.Substring(0, 1)?.ToUpperInvariant())[0];
           var column = Convert.ToInt32(triangle.Substring(1));
           var y1 = (F - row) * 10;
           var y2 = y1 + 10;
           var x1 = Convert.ToInt32(Math.Ceiling(column/ 2f) * 10);
           var x2 = x1 - 10;
           var trianglecoordinates = new TriangleCoordinates
            {
                point1 = new int[2],
                point2 = new int[2],
                point3 = new int[2],

            };
            if (column % 2 == 0) {
                trianglecoordinates.point1[0] = x1;
                trianglecoordinates.point1[1] = y1;
                trianglecoordinates.point2[0] = x1;
                trianglecoordinates.point2[1] = y2;
                trianglecoordinates.point3[0] = x2;
                trianglecoordinates.point3[1] = y2;
            }
            else {
                trianglecoordinates.point1[0] = x2;
                trianglecoordinates.point1[1] = y1;
                trianglecoordinates.point2[0] = x1;
                trianglecoordinates.point2[1] = y1;
                trianglecoordinates.point3[0] = x2;
                trianglecoordinates.point3[1] = y2;
            }

            return trianglecoordinates;
        }

        [Route("GetTriangleRowAndColumn")]
        [HttpPost]

        public string GetTriangleRowAndColumn(TriangleCoordinates triangleCoordinates)
        {
            if (triangleCoordinates?.point1?.Length > 0 && triangleCoordinates?.point2?.Length > 0
                && triangleCoordinates?.point1?.Length > 0)
            {

                var xCoordinates = new int[3];
                xCoordinates[0] = triangleCoordinates.point1[0];
                xCoordinates[1] = triangleCoordinates.point2[0];
                xCoordinates[2] = triangleCoordinates.point3[0];

                var yCoordinates = new int[3];
                yCoordinates[0] = triangleCoordinates.point1[1];
                yCoordinates[1] = triangleCoordinates.point2[1];
                yCoordinates[2] = triangleCoordinates.point3[1];

                int max = xCoordinates.Max();
                int minpointx = 0, minpointy = 0;
                int maxpointx = 0, maxpointy = 0;
                var count = 0;
                for (var i = 0; i < xCoordinates.Length; i++)
                {
                    if (xCoordinates[i] == max)
                    {
                        count++;
                        maxpointx = xCoordinates[i];
                        maxpointy = yCoordinates[i];
                    }
                    else
                    {
                        minpointx = xCoordinates[i];
                        minpointy = yCoordinates[i];
                    }

                }
                var row = string.Empty;
                var column = string.Empty;
                if (count == 2)
                {
                    var x2 = minpointx;
                    var y2 = minpointy;
                    var x1 = x2 + 10;
                    var y1 = y2 - 10;
                    row = char.ConvertFromUtf32(F - (y1 / 10));
                    column = ((x1 / 10) * 2).ToString();
                }
                else
                {
                    var x1 = maxpointx;
                    var y1 = maxpointy;
                    //var x1 = x2 + 10;
                    //var y1 = y2 - 10;
                    row = char.ConvertFromUtf32(F - (y1 / 10));
                    column = (((x1 / 10) * 2) - 1).ToString(); ;

                }
                var triangle = row + column;
                return triangle;
            }
            else
            {
                return string.Empty;
            }
        }


    }

}