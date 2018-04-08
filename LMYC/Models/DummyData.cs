using LMYC.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMYC.Models
{
    public class DummyData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            if (!db.Boats.Any())
            {
                var dateTime = DateTime.Now;
                string dateFormat = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                db.Boats.Add(new Boat
                {
                    BoatName = "Boaty McBoatface",
                    Picture = "http://www.lonelyplanet.com/news/wp-content/uploads/2015/06/lemur1.jpg",
                    LengthInFeet = 50,
                    Make = "Speedboat",
                    Year = 2014,
                    RecordCreationDate = dateFormat,
                    //CreatedBy = "1",
                });

                db.Boats.Add(new Boat
                {
                    BoatName = "Boaty McBoatface Jr.",
                    Picture = "https://media.mnn.com/assets/images/2016/08/sclaters-lemur-closeup.jpg.653x0_q80_crop-smart.jpg",
                    LengthInFeet = 35,
                    Make = "Medium Speedboat",
                    Year = 2016,
                    RecordCreationDate = dateFormat,
                    //CreatedBy = "1",
                });

                db.Boats.Add(new Boat
                {
                    BoatName = "Boaty McBoatface Sr.",
                    Picture = "https://haydensanimalfacts.files.wordpress.com/2015/11/red-ruffed-lemur.jpg",
                    LengthInFeet = 70,
                    Make = "Maximum Speedboat",
                    Year = 2004,
                    RecordCreationDate = dateFormat,
                    //CreatedBy = "2",
                });

                db.SaveChanges();
            }
        }
    }
}
